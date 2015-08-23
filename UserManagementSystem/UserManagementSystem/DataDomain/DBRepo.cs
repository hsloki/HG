using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public static class DBRepo
    {
        public static int AddUser(User user)
        {
            try
            {
                UsersDBEntities db = new UsersDBEntities();
                db.Users.Add(user);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        public static User GetUserByID(int UserID)
        {
            try
            {
                UsersDBEntities db = new UsersDBEntities();
                var u = (from user in db.Users
                         where user.UserID == UserID
                         select user);
                return (User)u;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static User UserUserByUserName(string  UserName)
        {
            try
            {
                UsersDBEntities db = new UsersDBEntities();
                var u = (from user in db.Users
                         where user.UserName == UserName
                         select user);
                return (User)u;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<User> GetAllUsers()
        {
            UsersDBEntities db = new UsersDBEntities();
            return (List<User>)(from users in db.Users
                                select users);
        }

        public static List<UserRole> GetRolesOfUser(int UserID)
        {
            UsersDBEntities db = new UsersDBEntities();
            List<int> roleIDs = (List<int>)(from urMap in db.UsersRolesMappings
                                    where urMap.UserID == UserID
                                select urMap.UserRoleID);
            //List<UserRole> allRoles = (from roles in db.UserRoles
            //                           where roles.UserRoleID == roleIDs
            //                           select roles).ToList<UserRole>();
            return new List<UserRole>();
        }

        public static int AddUserRole(UserRole role)
        {
            try
            {
                UsersDBEntities db = new UsersDBEntities();
                db.UserRoles.Add(role);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        public static int AssignRoleToUser(int UserID, int RoleID)
        {
            try
            {
                UsersDBEntities db = new UsersDBEntities();
                UsersRolesMapping mapTableObj = new UsersRolesMapping()
                {
                    UserID = UserID,
                    UserRoleID = RoleID,
                };
                db.UsersRolesMappings.Add(mapTableObj);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        public static int RemoveRoleFromUser(int UserID, int RoleID)
        {
            try
            {
                UsersDBEntities db = new UsersDBEntities();
                if (db.UsersRolesMappings.Any(m => m.UserID == UserID & m.UserRoleID == RoleID))
                {
                    UsersRolesMapping mapObj = db.UsersRolesMappings.Single(m => m.UserID == UserID & m.UserRoleID == RoleID);
                    db.UsersRolesMappings.Remove(mapObj);
                    return db.SaveChanges();
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        public static int UpdateUser(User UpdatedUser)
        {
            UsersDBEntities db = new UsersDBEntities();
            User u = (User)(from user in db.Users
                     where user.UserID == UpdatedUser.UserID
                     select user);
            if (u != null)
            {
                u.FirstName = UpdatedUser.FirstName;
                u.LastName = UpdatedUser.LastName;
                u.Password = UpdatedUser.Password;
                u.UserName = UpdatedUser.UserName;
                u.EmailAddress = UpdatedUser.EmailAddress;
                return db.SaveChanges();
            }
            else
                return 0;
        }

        public static int UpdateRole(UserRole UpdatedRole)
        {
            UsersDBEntities db = new UsersDBEntities();
            UserRole r = (UserRole)(from user in db.Users
                            where user.UserID == UpdatedRole.UserRoleID
                            select user);
            if (r != null)
            {
                r.UserRoleName = UpdatedRole.UserRoleName;
                r.UserRoleDescription = UpdatedRole.UserRoleDescription;
                return db.SaveChanges();
            }
            else
                return 0;
        }
    }
}
