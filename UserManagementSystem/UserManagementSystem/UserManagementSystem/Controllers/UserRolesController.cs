using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataDomain;
using RestSharp;
using System.Configuration;

namespace UserManagementSystem.Controllers
{
    public class UserRolesController : Controller
    {
        //static string ServerBaseUrl = "http://localhost/webapi/api/UserRoles";
        string ServerBaseUrl = ConfigurationManager.AppSettings.Get("ServerBaseUrl");
        //
        // GET: /UserRoles/
        public ActionResult Index()
        { 
            
            return View();
        }

        public ActionResult AllUsers()
        {
            
            var client = new RestClient(ServerBaseUrl + "/GetAllUsers");
            RestRequest request = new RestRequest(Method.GET);
            var response = client.Execute<List<User>>(request);
            return View(response.Data);
        }

        public ActionResult User(string id)
        {
            var client = new RestClient(ServerBaseUrl + "/GetUserByID");
            RestRequest request = new RestRequest(Method.GET);
            request.AddParameter("id", id);
            var response = client.Execute<User>(request);
            return View(response.Data);
        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            var client = new RestClient(ServerBaseUrl + "/GetUserByID");
            RestRequest request = new RestRequest(Method.GET);
            request.AddParameter("id", id);
            var response = client.Execute<User>(request);
            return View(response.Data);
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            // get user to update db using api. 
            var client = new RestClient(ServerBaseUrl + "/UpdateUser");
            RestRequest request = new RestRequest(Method.POST);
            request.AddObject(user);
            var response = client.Execute(request);

            return RedirectToAction("AllUsers");
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            var client = new RestClient(ServerBaseUrl + "/AddUser");
            RestRequest request = new RestRequest(Method.POST);
            request.AddObject(user);
            int intt=  client.Execute<int>(request).Data;
            return RedirectToAction("AllUsers");
        }

        [HttpGet]
        public ActionResult AllRoles()
        {
            var client = new RestClient(ServerBaseUrl + "/GetAllRoles");
            RestRequest request = new RestRequest(Method.GET);
            var response = client.Execute<List<UserRole>>(request);
            return View(response.Data);
        }

        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRole(UserRole role)
        {
            var client = new RestClient(ServerBaseUrl + "/AddUserRole");
            RestRequest request = new RestRequest(Method.POST);
            request.AddObject(role);
            int intt = client.Execute<int>(request).Data;
            return RedirectToAction("AllRoles");
        }

        [HttpGet]
        public ActionResult EditRole(string id)
        {
            var client = new RestClient(ServerBaseUrl + "/GetUserRole");
            RestRequest request = new RestRequest(Method.GET);
            request.AddParameter("id", id);
            var response = client.Execute<UserRole>(request);
            return View(response.Data);
        }
        [HttpPost]
        public ActionResult EditRole(UserRole role)
        {
            // get user to update db using api. 
            var client = new RestClient(ServerBaseUrl + "/UpdateRole");
            RestRequest request = new RestRequest(Method.POST);
            request.AddObject(role);
            var response = client.Execute(request);

            return RedirectToAction("AllRoles");
        }

        [HttpGet]
        public ActionResult DeleteUser(string id)
        {
            var client = new RestClient(ServerBaseUrl + "/GetUserByID");
            RestRequest request = new RestRequest(Method.GET);
            request.AddParameter("id", id);
            var response = client.Execute<User>(request);
            return View(response.Data);
        }

        [HttpPost]
        public ActionResult DeleteUser(int? id)
        {
            var client = new RestClient(ServerBaseUrl + "/DeleteUser");
            RestRequest request = new RestRequest(Method.GET);
            request.AddParameter("id", id);
            var response = client.Execute(request);

            return RedirectToAction("AllUsers");
        }

        [HttpGet]
        public ActionResult DeleteRole(string id)
        {
            var client = new RestClient(ServerBaseUrl + "/GetUserRole");
            RestRequest request = new RestRequest(Method.GET);
            request.AddParameter("id", id);
            var response = client.Execute<UserRole>(request);
            return View(response.Data);
        }

        [HttpPost]
        public ActionResult DeleteRole(int? id)
        {
            var client = new RestClient(ServerBaseUrl + "/DeleteRole");
            RestRequest request = new RestRequest(Method.GET);
            request.AddParameter("id", id);
            var response = client.Execute(request);

            return RedirectToAction("AllRoles");
        }



        public ActionResult ManageUserRoles(int? id)
        {
            var client = new RestClient(ServerBaseUrl + "/GetRolesOfUser");
            RestRequest request = new RestRequest(Method.GET);
            request.AddParameter("UserID", id);
            var response = client.Execute<List<UserRole>>(request);
            ViewBag.UserID = id;
            return View(response.Data);
        }

        public ActionResult DeleteRoleFromUser(int? UserID, int? RoleID)
        {

            var client = new RestClient(ServerBaseUrl + "/RemoveRoleFromUser?UserID=" + UserID + "&RoleID=" + RoleID);
            RestRequest request = new RestRequest(Method.GET);
            List<Parameter> paramss = new List<Parameter>();
            //paramss.Add(new Parameter() { Name = "UserID", Value = UserID });
            //paramss.Add(new Parameter() { Name = "RoleID", Value = RoleID });
            //request.AddParameter("UserID", UserID);
            //request.AddParameter("RoleID", RoleID);
            //request.Parameters.AddRange(paramss);
            var response = client.Execute(request);
            return RedirectToAction("ManageUserRoles", UserID);
        }

        [HttpGet]
        public ActionResult AssignNewRole(string userid)
        {

            if (!string.IsNullOrEmpty(userid))
                ViewBag.UserId = userid;
            
            var client = new RestClient(ServerBaseUrl + "/GetAllRoles");
            RestRequest request = new RestRequest(Method.GET);
            var response = client.Execute<List<UserRole>>(request);
            return View("View1", response.Data);
        }
        [HttpPost]
        public ActionResult AssignNewRole(int? hdUserID, int? hdUserRole)
        {
            var client = new RestClient(ServerBaseUrl + "/AddRoleToUser?UserID=" + hdUserID + "&RoleID=" + hdUserRole);
            RestRequest request = new RestRequest(Method.GET);
            //request.AddParameter("UserID", UserID);
            //request.AddParameter("RoleID", RoleID);
            var response = client.Execute(request);
            return RedirectToAction("AllUsers");
        
        }

        [HttpPost]
        public ActionResult AssignRole(int? hdUserID, int? hdUserRole)
        {
            var client = new RestClient(ServerBaseUrl + "/AddRoleToUser?UserID=" + hdUserID + "&RoleID=" + hdUserRole);
            RestRequest request = new RestRequest(Method.GET);
            //request.AddParameter("UserID", UserID);
            //request.AddParameter("RoleID", RoleID);
            var response = client.Execute(request);
            return RedirectToAction("AllUsers");
        }
	}
}