using Attendance.Models.Viewmodel;
using Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attendance.Controllers
{
    public class ManageEController : Controller
    {
        OracledbEntities _db = new OracledbEntities();
         //
        // GET: /ManageE/
        [HttpGet]
        public ActionResult Listing()
        {
            var user = _db.EMPLOYEEs.ToList();
            return View(user);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /*Insert into multiple Table from a single Form*/
        [HttpPost]
        public ActionResult Create(ManageEmployeeViewModel mevm)
        {
            var employee = new EMPLOYEE
            {
                
               EID = _db.Database.ExecuteSqlCommand("select EID_INCREMENT.NEXTVAL from dual"),                
                FULL_NAME = mevm.FULL_NAME,
               // FULL_NAME = _db.Database.ExecuteSqlCommand("select EID_INCREMENT.NEXTVAL from dual").ToString(),
                ADDRESS = mevm.ADDRESS,
                EMAIL=mevm.EMAIL,
                GENDER=mevm.GENDER.ToString(),
                PASSCODE=mevm.PASSCODE,
                CONTACT = 7777777777
                //_db.Database.ExecuteSqlCommand("select EID_INCREMENT.NEXTVAL from dual")
              //  CONTACT=mevm.CONTACT.ToString()
            };

            var urole = new USERROLE();
            _db.EMPLOYEEs.Add(employee);
            _db.SaveChanges();
            EMPLOYEE seis = _db.EMPLOYEEs.LastOrDefault();
         

            var upost = new EMPLOYEE_POST
            {
                EPOID = 5, // current manually put the value later auto increment from oracle
                EID = seis.EID,
                POST = mevm.POST
            };

            _db.EMPLOYEE_POST.Add(upost);
            _db.SaveChanges();
            return RedirectToAction("Listing");

            //using(var fill =new OracledbEntities())
            //{
            //    _db.EMPLOYEEs.Add(employee);
            //    upost.EID=employee.EID;
            //    _db.EMPLOYEE_POST.Add(upost);
            //    _db.SaveChanges();
            //}
            //return View();


            //_db.EMPLOYEEs.Add(e);
            //_db.SaveChanges();
            
        }
	}
}