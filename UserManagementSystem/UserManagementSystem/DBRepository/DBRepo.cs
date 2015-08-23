using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository
{
    public static class DBRepo
    {
        public static int AddUser(User user)
        {
            try
            {
                using (UsersDBEntities db = new UsersDBEntities())
                {
                    db.Users.Add(user);
                    return db.SaveChanges();
                }

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
                using (UsersDBEntities db = new UsersDBEntities())
                {
                    User u = db.Users.Single(user => user.UserID == UserID);
                    //var u = (from user in db.Users
                    //         where user.UserID == UserID
                    //         select user);
                    return u;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static User GetUserByUserName(string  UserName)
        {
            try
            {
                using (UsersDBEntities db = new UsersDBEntities())
                {
                    var u = (from user in db.Users
                             where user.UserName == UserName
                             select user);
                    return (User)u;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<User> GetAllUsers()
        {
            using (UsersDBEntities db = new UsersDBEntities())
            {
                return (from users in db.Users
                        select users).ToList<User>();
            }
        }

        public static List<UserRole> GetRolesOfUser(int UserID)
        {
            using (UsersDBEntities db = new UsersDBEntities())
            {
                //List<int> roleIDs = (from urMap in db.UsersRolesMappings
                //                     where urMap.UserID == UserID
                //                     select urMap.UserRoleID).ToList<int>();








                List<UserRole> listofRoles = (from rmap in db.UsersRolesMappings
                                   join usr in db.Users on rmap.UserID equals usr.UserID
                                   join rol in db.UserRoles on rmap.UserRoleID equals rol.UserRoleID

                                   where usr.UserID == UserID
                                   select rol
                                    ).ToList<UserRole>();




                return listofRoles;
            }
        }

        public static int AddUserRole(UserRole role)
        {
            try
            {
                using (UsersDBEntities db = new UsersDBEntities())
                {
                    db.UserRoles.Add(role);
                    return db.SaveChanges();
                }
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
                using (UsersDBEntities db = new UsersDBEntities())
                {
                    UsersRolesMapping mapTableObj = new UsersRolesMapping()
                    {
                        UserID = UserID,
                        UserRoleID = RoleID,
                    };
                    db.UsersRolesMappings.Add(mapTableObj);
                    return db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        

        public static int UpdateUser(User UpdatedUser)
        {
            using (UsersDBEntities db = new UsersDBEntities())
            {
                User u = db.Users.Single(user => user.UserID == UpdatedUser.UserID);
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
        }

        public static int UpdateRole(UserRole UpdatedRole)
        {
            using (UsersDBEntities db = new UsersDBEntities())
            {
                UserRole r = db.UserRoles.Single(role => role.UserRoleID == UpdatedRole.UserRoleID); 
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

        public static List<UserRole> GetAllRoles()
        {
            using (UsersDBEntities db = new UsersDBEntities())
            {
                return (from roles in db.UserRoles
                        select roles).ToList<UserRole>();
            }
        }

        public static int DeleteUser(int id)
        {
            try
            {
                using (UsersDBEntities db = new UsersDBEntities())
                {
                    User u = db.Users.Single(user => user.UserID == id);
                    if (u != null)
                    {
                        db.Users.Remove(u);
                        return db.SaveChanges();
                    }
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        public static int DeleteRole(int id)
        {
            try
            {
                using (UsersDBEntities db = new UsersDBEntities())
                {
                    UserRole r = db.UserRoles.Single(role => role.UserRoleID == id);
                    if (r != null)
                    {
                        db.UserRoles.Remove(r);
                        return db.SaveChanges();
                    }
                    else
                        return 0;
                }
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
                using (UsersDBEntities db = new UsersDBEntities())
                {
                    if (db.UsersRolesMappings.Any(m => m.UserID == UserID & m.UserRoleID == RoleID))
                    {
                        UsersRolesMapping mapObj = db.UsersRolesMappings.Single(m => m.UserID == UserID & m.UserRoleID == RoleID);
                        db.UsersRolesMappings.Remove(mapObj);
                        return db.SaveChanges();
                    }
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        public static UserRole GetUserRole(int id)
        {
            try
            {
                using (UsersDBEntities db = new UsersDBEntities())
                {
                    UserRole role = db.UserRoles.Single(r => r.UserRoleID == id);
                    //var u = (from user in db.Users
                    //         where user.UserID == UserID
                    //         select user);
                    return role;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
