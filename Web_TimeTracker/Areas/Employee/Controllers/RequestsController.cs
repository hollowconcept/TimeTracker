using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_TimeTracker.Areas.Employee.Controllers
{
    public class RequestsController : Controller
    {
        // GET: Employee/Requests
        public ActionResult Index()
        {
            return View();
        }
    }
}