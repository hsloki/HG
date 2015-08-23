using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDomain;

namespace DBRepository
{
    public static class Repo
    {
        public static int AddUser(User user)
        {
            return DBRepo.AddUser(user);
           
        }

        public static User GetUserByID(int UserID)
        {
            return DBRepo.GetUserByID(UserID);
        }

        public static User UserUserByUserName(string UserName)
        {
            return DBRepo.UserUserByUserName(UserName);
        }

        public static List<User> GetAllUsers()
        {
            return DBRepo.GetAllUsers();
        }

        public static List<UserRole> GetRolesOfUser(int UserID)
        {
            return DBRepo.GetRolesOfUser(UserID);
            
        }

        public static int AddUserRole(UserRole role)
        {
            return DBRepo.AddUserRole(role);
        }

        public static int AssignRoleToUser(int UserID, int RoleID)
        {
            return DBRepo.AssignRoleToUser(UserID, RoleID);
        }

        public static int RemoveRoleFromUser(int UserID, int RoleID)
        {
            return DBRepo.RemoveRoleFromUser(UserID, RoleID);
        }

        public static int UpdateUser(User UpdatedUser)
        {
            return DBRepo.UpdateUser(UpdatedUser);
        }

        public static int UpdateRole(UserRole UpdatedRole)
        {
            return DBRepo.UpdateRole(UpdatedRole);
        }
    }
}
