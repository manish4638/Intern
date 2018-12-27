using Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attendance.Controllers
{
    public class ManageEmployeeController : Controller
    {
        OracledbEntities _db = new OracledbEntities();
        //
        // GET: /ManageEmployee/
        [HttpGet]
        public ActionResult List_Employee()
        {
            var users = _db.EMPLOYEEs.ToList();
            return View();
        }
	}
}