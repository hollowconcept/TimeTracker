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

namespace Web_TimeTracker.Areas.Employee.Controllers
{
    public class TimeEntriesController : Controller
    {
        // GET: Employee/TimeEntries
        public ActionResult Index()
        {
            CustomerDB customerDB = new Backend_TimeTracker.DataAccess.CustomerDB();
            ProjectDB projectDB = new Backend_TimeTracker.DataAccess.ProjectDB();
            RepositoryDB repositoryDB = new Backend_TimeTracker.DataAccess.RepositoryDB();
            //Customer Dropdown
            var customerList = customerDB.GetCustomers();
            //Create List of SelectListItem
            List<SelectListItem> custselectlist = new List<SelectListItem>();
            foreach (CustomerProperty cust in customerList)
            {
                //Adding every record to list  
                custselectlist.Add(new SelectListItem { Text = cust.CustomerName, Value = cust.Id.ToString() });
            }

            ViewBag.SelectList = custselectlist;//Assign list to ViewBag will access this in view
       

            //Project Dropdown

            var projectList = projectDB.GetProjects();
            //Create List of SelectListItem
            List<SelectListItem> projselectlist = new List<SelectListItem>();
            foreach (ProjectProperty proj in projectList)
            {
                //Adding every record to list  
                projselectlist.Add(new SelectListItem { Text = proj.ProjectName, Value = proj.Id.ToString() });
            }

            ViewBag.projSelectList = projselectlist;//Assign list to ViewBag will access this in view
            return View();

            //BusinessArea Dropdown

            var businessAreaList = repositoryDB.GetBusinessAreas();
            //Create List of SelectListItem
            List<SelectListItem> areaselectList = new List<SelectListItem>();
            foreach (ProjectProperty proj in projectList)
            {
                //Adding every record to list  
                projselectlist.Add(new SelectListItem { Text = proj.ProjectName, Value = proj.Id.ToString() });
            }

            ViewBag.projSelectList = projselectlist;//Assign list to ViewBag will access this in view
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult AddEntry(TimeRecordingProperty currentTimeRecording)
        {

            string currentUserId;
            string currentUserFirstName;

            HttpCookie reqCookies = Request.Cookies["userDataFuhrparkManagement"];
            if (reqCookies != null)
            {
                currentUserId = reqCookies["ID"].ToString();
                currentUserFirstName = reqCookies["FirstName"].ToString();
            }
            currentUserId = currentTimeRecording.RecordingUserId.ToString();

            TimeRecordingDB timeRecordingDB = new TimeRecordingDB();

            TimeTrackerManager timeTrackerManager = new TimeTrackerManager();

            timeRecordingDB.InsertTimeRecording(currentTimeRecording);

            TimeTrackerManager.CreateTimeRecording(currentTimeRecording);

            TempData["InsertTimeRecordingFlag"] = "Eintrag erfolgreich erstellt";

            return RedirectToAction("Index", "Home");

            return View("Index");
        }
    }
}