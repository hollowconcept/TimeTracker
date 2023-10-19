using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_TimeTracker.Controllers
{
    public class BaseController : Controller
    {
        /* App Settings */
        public string Domain = Properties.Settings.Default.Domain;

        /* User */
        public string GlobalUserName;
        public string GlobalFirstName;
        public string GlobalLastName;
        public string GlobalRoles;
        public string GlobalEmail;
        public string GlobalPhone;
        public string GlobalDepartment;
        public string GlobalManagerName;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            SetGlobalSettings();
        }

        public void SetGlobalSettings()
        {
            HttpCookie cookie = Request.Cookies["timeTrackerUserData"];

            if (cookie != null)
            {
                GlobalUserName = Server.UrlDecode(cookie["userName"].ToString());
                GlobalFirstName = Server.UrlDecode(cookie["firstName"].ToString());
                GlobalLastName = Server.UrlDecode(cookie["lastName"].ToString());
                GlobalRoles = Server.UrlDecode(cookie["roles"].ToString());
                GlobalEmail = Server.UrlDecode(cookie["email"].ToString());
                GlobalPhone = Server.UrlDecode(cookie["phone"].ToString());
                GlobalDepartment = Server.UrlDecode(cookie["department"].ToString());
                GlobalManagerName = Server.UrlDecode(cookie["manager"].ToString());

                /* User */
                ViewBag.Username = GlobalUserName;
                ViewBag.Firstname = GlobalFirstName;
                ViewBag.Lastname = GlobalLastName;
                ViewBag.Roles = GlobalRoles;
                ViewBag.Email = GlobalEmail;
                ViewBag.Phone = GlobalPhone;
                ViewBag.Department = GlobalDepartment;
                ViewBag.ManagerName = GlobalManagerName;

                /* Berechtigungen */
                ViewBag.User = false;
                ViewBag.Admin = false;
            }
        }

        public void ErrorLogger(string message)
        {
            Log4net.Logger.Error($"BaseController.ErrorLogger {message}");
        }

        public bool ProveCookies()
        {
            HttpCookie cookie = Request.Cookies["timeTrackerUserData"];

            if (cookie != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}