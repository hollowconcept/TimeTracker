﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_TimeTracker.Areas.Administrator.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Administrator/Reports
        public ActionResult Index()
        {
            return View();
        }
    }
}