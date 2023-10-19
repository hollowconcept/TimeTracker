using GlobalDefinitions_TimeTracker.Models;
using OMSManager.Backend;
using OMSManager.GlobalDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web_TimeTracker.Controllers
{
    public class SecureController : BaseController
    {
        private ADManager AdManager;
        private ADUser CurrentAdUser;

        public SecureController()
        {
            AdManager = new ADManager();
            CurrentAdUser = new ADUser();
        }

        public ActionResult Authentification()
        {
            string userRoles = string.Empty;

            string userName = HttpContext.Request.LogonUserIdentity.Name.Split('\\').LastOrDefault() ?? string.Empty;
            string domain = HttpContext.Request.LogonUserIdentity.Name.Split('\\').FirstOrDefault() ?? Domain;

            ViewBag.Error = string.Empty;

            try
            {
                if (ProveCookies())
                {
                    return RedirectToAction("", "");
                }

                CurrentAdUser = AdManager.GetADUser(Domain, Domain, userName);

                if(CurrentAdUser != null)
                {
                    if (!string.IsNullOrEmpty(CurrentAdUser.Department))
                    {
                        if (CurrentAdUser.Department.IndexOf("Projekte", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            CurrentAdUser.Department.IndexOf("Lösungen", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            if (!HandleUserDatabaseOperations())
                            {
                                Log4net.Logger.Error($"SecureController.Authentification.HandleUserDatabaseOperation Ein Fehler ist aufgetreten. Anwender {CurrentAdUser.AccountName} ");

                                return RedirectToAction("", "");
                            }
                            else
                            {
                                Log4net.Logger.Info($"SecureController.Authentification Anwender {CurrentAdUser.AccountName} hat sich erfolgreich angemeldet.");

                                SetCookies(userRoles);

                                return RedirectToAction("", "");
                            }
                        }
                        else
                        {
                            Log4net.Logger.Info($"SecureController.Authentification Anwender {CurrentAdUser.AccountName} hat sich versucht anzumelden ohne Berechtigung. Abteilung {CurrentAdUser.Department}");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Log4net.Logger.Error($"SecureController.Authentfication {ex.Message}");
            }

            return View();
        }

        private bool HandleUserDatabaseOperations()
        {
            UserProperty currentDBUser = new UserProperty();

            bool result = false;

            if(currentDBUser != null)
            {
                currentDBUser.UserName = CurrentAdUser.AccountName;
                currentDBUser.FirstName = CurrentAdUser.GivenName;
                currentDBUser.LastName = CurrentAdUser.Surname;
                currentDBUser.EMailAddress = CurrentAdUser.EMailAddress;
                currentDBUser.ManagerName = CurrentAdUser.Manager;
                currentDBUser.LastLogin = DateTime.Now;

                result = true;
            }
            else
            {
                currentDBUser = new UserProperty()
                {
                    UserName = CurrentAdUser.AccountName,
                    FirstName = CurrentAdUser.GivenName,
                    LastName = CurrentAdUser.Surname,
                    EMailAddress = CurrentAdUser.EMailAddress,
                    ManagerName = CurrentAdUser.Manager
                };

                result = true;
            }

            return result;
        }

        private void SetCookies(string userRoles)
        {
            HttpCookie cookie = new HttpCookie("timeTrackerUserData");

            try
            {
                SetCookieValues(cookie, userRoles);

                cookie.Expires = DateTime.Now.AddHours(8);
                Response.Cookies.Add(cookie);

                FormsAuthentication.SetAuthCookie(CurrentAdUser.AccountName, false);
            }
            catch (Exception ex)
            {
                Log4net.Logger.Error($"SecureController.SetCookies {ex.Message}");
            }
        }

        private void SetCookieValues(HttpCookie cookie, string userRoles)
        {
            cookie.Values["firstName"] = Server.UrlEncode(CurrentAdUser.GivenName);
            cookie.Values["lastName"] = Server.UrlEncode(CurrentAdUser.Surname);
            cookie.Values["userName"] = Server.UrlEncode(CurrentAdUser.AccountName);
            cookie.Values["roles"] = Server.UrlEncode(userRoles);
            cookie.Values["email"] = Server.UrlEncode(CurrentAdUser.EMailAddress);
            cookie.Values["phone"] = Server.UrlEncode(CurrentAdUser.Phone);
            cookie.Values["department"] = Server.UrlEncode(CurrentAdUser.Department);
            cookie.Values["manager"] = Server.UrlEncode(CurrentAdUser.Manager);
        }

        private void removeCookies()
        {
            HttpCookie cookie = new HttpCookie("timeTrackerUserData");

            try
            {
                if (cookie != null)
                {
                    cookie.Values.Remove("firstName");
                    cookie.Values.Remove("lastName");
                    cookie.Values.Remove("userName");
                    cookie.Values.Remove("userRoles");
                    cookie.Values.Remove("email");
                    cookie.Values.Remove("phone");
                    cookie.Values.Remove("department");
                    cookie.Values.Remove("manager");

                    cookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);
                }

                FormsAuthentication.SignOut();
            }
            catch (Exception ex)
            {
                Log4net.Logger.Error($"SecureController.RemoveCookies {ex.Message}");
            }
        }
    }
}