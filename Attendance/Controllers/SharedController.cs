﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attendance.Controllers
{
    public class SharedController : Controller
    {
        //
        // GET: /Shared/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult master()
        {
            return View("_master");
        }
	}
}