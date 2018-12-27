using Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attendance.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        OracledbEntities _db = new OracledbEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var users = _db.EMPLOYEEs.ToList();
            return View(users);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EMPLOYEE e)
        {
            _db.EMPLOYEEs.Add(e);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EMPLOYEE e = _db.EMPLOYEEs.Where(u => u.EID == id).FirstOrDefault();
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(EMPLOYEE e)
        {
            EMPLOYEE el = _db.EMPLOYEEs.Where(u => u.EID == e.EID).FirstOrDefault();
            el.FULL_NAME = e.FULL_NAME;
            el.ADDRESS = e.ADDRESS;
            el.EMAIL = e.EMAIL;
            el.GENDER = e.GENDER;
            el.PASSCODE = e.PASSCODE;
            el.CONTACT = e.CONTACT;
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            EMPLOYEE e = _db.EMPLOYEEs.Where(u => u.EID == id).FirstOrDefault();
            return View(e);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            EMPLOYEE e = _db.EMPLOYEEs.Where(u => u.EID == id).FirstOrDefault();
            return View(e);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            EMPLOYEE e = _db.EMPLOYEEs.Where(u => u.EID == id).FirstOrDefault();
            _db.EMPLOYEEs.Remove(e);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}