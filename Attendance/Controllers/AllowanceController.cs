using Attendance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attendance.Controllers
{
    [Authorize]
    public class AllowanceController : Controller
    {
        //
        // GET: /Allowance/
        OracledbEntities _db = new OracledbEntities();
        public ActionResult Allowancelist()
        {
            var lst = _db.ALLOWANCEs.OrderBy(i => i.AID).ToList();   
           return View(lst);
        }
        [HttpGet]
        public ActionResult Allowancecreate(String msg)
        {
            List<POST_LIST> postlist = _db.POST_LIST.ToList();
            ViewBag.Postlist = new SelectList(postlist, "POID", "POST");
            ViewBag.Alert = msg;
            return View();
        }
        [HttpPost]
        public ActionResult Allowancecreate(ALLOWANCE alw)
        {
            if (ModelState.IsValid)
            {
                Int32 maxaolid = Convert.ToInt32(_db.ALLOWANCEs.Select(p => p.AID).DefaultIfEmpty(0).Max());
                int tpoid = Convert.ToInt32(alw.POST);
                POST_LIST pl = _db.POST_LIST.Where(c => c.POID == tpoid).FirstOrDefault();
                var pocheck = _db.ALLOWANCEs.Where(o => o.POST == pl.POST).FirstOrDefault();
                if (pocheck == null)
                {
                    if (maxaolid <= 0)
                    {
                        maxaolid = 1;
                    }
                    else
                    {
                        maxaolid++;
                    }
                    alw.AID = maxaolid;
                    alw.POST = pl.POST;
                    _db.ALLOWANCEs.Add(alw);
                    _db.SaveChanges();
                    return RedirectToAction("Allowancelist");
                }
                else
                {
                    // ViewBag.Alert="Allowance for "+pl.POST+" is already set";
                    // return View();
                    return RedirectToAction("Allowancecreate", new { msg = "Allowance for " + pl.POST + " is already set" });
                }
            }
            else
            {
                return RedirectToAction("Allowancecreate", new { msg = "Please Check The Entered Parameter" });
            }
        }
        [HttpGet]
        public ActionResult AllowanceEdit(int id)
        {
            var foredit = _db.ALLOWANCEs.Where(i => i.AID == id).FirstOrDefault();
            return View(foredit);
        }
        [HttpPost]
        public ActionResult AllowanceEdit(ALLOWANCE alw)
        {
            if (ModelState.IsValid)
            {
                ALLOWANCE alw1 = _db.ALLOWANCEs.Where(i => i.AID == alw.AID).FirstOrDefault();
                alw1.MEAL_ALLOWANCE = alw.MEAL_ALLOWANCE;
                alw1.WOH = alw.WOH;
                alw1.WONS = alw.WONS;
                alw1.WOSH = alw.WOSH;
                _db.SaveChanges();
                return RedirectToAction("Allowancelist");
            }
            else
            {
                return RedirectToAction("AllowanceEdit",alw.AID);
            }
        }
        [HttpGet]
        public ActionResult Allowancedelete(int id)
        {
            var fordelete = _db.ALLOWANCEs.Where(i => i.AID == id).FirstOrDefault();
            return View(fordelete);
        }
        [HttpPost, ActionName("Allowancedelete")]
        public ActionResult Allowancedelete_rec(int id)
        {
            var fordelete = _db.ALLOWANCEs.Where(i => i.AID == id).FirstOrDefault();
            _db.ALLOWANCEs.Remove(fordelete);
            _db.SaveChanges();
            return RedirectToAction("Allowancelist");
        }
	}
}