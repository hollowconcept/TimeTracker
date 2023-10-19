using Backend_TimeTracker.Management;
using GlobalDefinitions_TimeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Backend_TimeTracker;
using Backend_TimeTracker.DataAccess;
using OMSManager.GlobalDefinitions;
using System.Web.Security;

namespace Web_TimeTracker.Areas.Administrator.Controllers
{
    public class OverviewController : Controller
    {
        // GET: Administrator/Overview
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        private void setCookies(UserProperty currentUser)
        {
            HttpCookie cookie = new HttpCookie("userDataTimeTracker");

            try
            {
                cookie["ID"] = Server.UrlEncode(currentUser.Id.ToString());
                cookie["UserName"] = Server.UrlEncode(currentUser.UserName);
                cookie["FirstName"] = Server.UrlEncode(currentUser.FirstName);
                cookie["LastName"] = Server.UrlEncode(currentUser.LastName);

                cookie.Expires = DateTime.Now.AddHours(8);
                Response.Cookies.Add(cookie);

                FormsAuthentication.SetAuthCookie(currentUser.UserName, false);
            }
            catch (Exception ex)
            {

            }
        }

        /** Methode zum löschen der Cookies **/
        private void removeCookies()
        {
            HttpCookie cookie = new HttpCookie("userDataTimeTracker");

            try
            {
                if (cookie != null)
                {
                    cookie.Values.Remove("ID");
                    cookie.Values.Remove("UserName");
                    cookie.Values.Remove("FirstName");
                    cookie.Values.Remove("LastName");

                    cookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);
                }

                FormsAuthentication.SignOut();
            }
            catch (Exception ex)
            {

            }
        }

        /** Methode überprüft ob Cookies noch vorhanden sind **/
        private bool proveCookies()
        {
            HttpCookie cookie = Request.Cookies["userDataTimeTracker"];

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