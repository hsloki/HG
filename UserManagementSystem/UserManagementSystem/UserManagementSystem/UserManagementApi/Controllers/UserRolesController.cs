using DataDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBRepository;

namespace UserManagementApi.Controllers
{
    public class UserRolesController : ApiController
    {
        [HttpPost]
        public int AddUser(User user)
        {
            return DBRepo.AddUser(user);
        }


        [HttpGet]
        public User GetUserByID(int id)
        {
            return DBRepo.GetUserByID(id);
        }

        [HttpGet]
        public User GetUserByUserName(string UserName)
        {
            return DBRepo.GetUserByUserName(UserName);
        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            return DBRepo.GetAllUsers();
        }

        [HttpGet]
        public List<UserRole> GetAllRoles()
        {
            return DBRepo.GetAllRoles();
        }

        [HttpGet]
        public List<UserRole> GetRolesOfUser(int UserID)
        {
            return DBRepo.GetRolesOfUser(UserID);

        }

        public int AddUserRole(UserRole role)
        {
            return DBRepo.AddUserRole(role);
        }

        public int AssignRoleToUser(int UserID, int RoleID)
        {
            return DBRepo.AssignRoleToUser(UserID, RoleID);
        }

        [HttpGet]
        public int RemoveRoleFromUser(int UserID, int RoleID)
        {
            return DBRepo.RemoveRoleFromUser(UserID, RoleID);
        }

        public int UpdateUser(User UpdatedUser)
        {
            return DBRepo.UpdateUser(UpdatedUser);
        }

        public int UpdateRole(UserRole UpdatedRole)
        {
            return DBRepo.UpdateRole(UpdatedRole);
        }

        [HttpGet]
        public UserRole GetUserRole(int id)
        {
            return DBRepo.GetUserRole(id);
        }

        [HttpGet]
        public int DeleteUser(int id)
        {
            return DBRepo.DeleteUser(id);
        }
        [HttpGet]
        public int DeleteRole(int id)
        {
            return DBRepo.DeleteRole(id);
        }
    }
}
