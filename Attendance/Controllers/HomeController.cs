using Attendance.Models;
using Attendance.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attendance.Controllers
{
    [System.Runtime.InteropServices.GuidAttribute("A9E31CFB-281E-420E-A743-F057F42E28B5")]
    [Authorize]
    public class HomeController : Controller
    {
        OracledbEntities _db = new OracledbEntities();
        // GET: /Home/
        //       [Authorize]
        public ActionResult Schedule(String msg)
        {
            Int32 seid = Convert.ToInt32(Session["Eid"]);
            ViewBag.alert = msg;
            var user = _db.ATTENDANCEs.Where(p => p.EID == seid).ToList();
            return View(user);
        }
        [Authorize]
        [HttpGet]
        public ActionResult PersonalProfile()
        {
            ManageEmployeeViewModel mevm = new ManageEmployeeViewModel();
            int id = Convert.ToInt32(Session["Eid"]);
            EMPLOYEE e = _db.EMPLOYEEs.Where(u => u.EID == id).FirstOrDefault();
            EMPLOYEE_POST ep = _db.EMPLOYEE_POST.Where(z => z.EID == id).FirstOrDefault();
            USERROLE ur = _db.USERROLES.Where(z => z.EID == id).FirstOrDefault();
            ROLE rl = _db.ROLES.Where(x => x.ROLEID == ur.ROLEID).FirstOrDefault();
            String rn = rl.ROLENAME;
            SUPERVISOR spv = _db.SUPERVISORs.Where(x => x.EID == id).FirstOrDefault();
            mevm.EID = Convert.ToInt32(e.EID);
            mevm.FULL_NAME = e.FULL_NAME;
            mevm.ADDRESS = e.ADDRESS;
            mevm.CONTACT = e.CONTACT;
            mevm.EMAIL = e.EMAIL;
            mevm.GENDER = e.GENDER;
            mevm.POST = ep.POST;
            mevm.ROLENAME = rn;
            mevm.SUPERVISOR1 = spv.SUPERVISOR1;
            mevm.SUPERVISOR2 = spv.SUPERVISOR2;
            mevm.SUPERVISOR3 = spv.SUPERVISOR3;
            mevm.SUPERVISOR4 = spv.SUPERVISOR4;
            mevm.SUPERVISOR5 = spv.SUPERVISOR5;
            return View(mevm);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Editpersonalprofile(int id)
        {
            List<ManageEmployeeViewModel> Result = (from f in _db.EMPLOYEEs
                                                    join p in _db.USERROLES
                                                    on f.EID equals p.EID
                                                    where p.ROLEID != 2
                                                    select new ManageEmployeeViewModel
                                                    {
                                                        EID1 = f.EID,
                                                        FULL_NAME = f.FULL_NAME,
                                                        GENDER = f.GENDER,
                                                        CONTACT = f.CONTACT,
                                                        PASSCODE = f.PASSCODE,
                                                        ADDRESS = f.ADDRESS,
                                                        EMAIL = f.EMAIL,

                                                    }).ToList();
            ViewBag.supvlist = new SelectList(Result, "EID1", "EMAIL");




            //List<EMPLOYEE> suplist = _db.EMPLOYEEs.ToList();
            //ViewBag.supvlist = new SelectList(suplist, "EID", "EMAIL");

            ManageEmployeeViewModel mevm = new ManageEmployeeViewModel();
            EMPLOYEE e = _db.EMPLOYEEs.Where(u => u.EID == id).FirstOrDefault();
            EMPLOYEE_POST ep = _db.EMPLOYEE_POST.Where(z => z.EID == id).FirstOrDefault();
            USERROLE ur = _db.USERROLES.Where(z => z.EID == id).FirstOrDefault();
            ROLE rl = _db.ROLES.Where(x => x.ROLEID == ur.ROLEID).FirstOrDefault();
            String rn = rl.ROLENAME;
            SUPERVISOR spv = _db.SUPERVISORs.Where(x => x.EID == id).FirstOrDefault();
            mevm.EID = Convert.ToInt32(e.EID);
            mevm.FULL_NAME = e.FULL_NAME;
            mevm.ADDRESS = e.ADDRESS;
            mevm.CONTACT = e.CONTACT;
            mevm.EMAIL = e.EMAIL;
            mevm.GENDER = e.GENDER;
            mevm.POST = ep.POST;
            mevm.ROLENAME = rn;
            mevm.SUPERVISOR1 = spv.SUPERVISOR1;
            mevm.SUPERVISOR2 = spv.SUPERVISOR2;
            mevm.SUPERVISOR3 = spv.SUPERVISOR3;
            mevm.SUPERVISOR4 = spv.SUPERVISOR4;
            mevm.SUPERVISOR5 = spv.SUPERVISOR5;
            return View(mevm);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Editpersonalprofile(ManageEmployeeViewModel mevm)
        {
            EMPLOYEE e = _db.EMPLOYEEs.Where(u => u.EID == mevm.EID).FirstOrDefault();
            EMPLOYEE_POST ep = _db.EMPLOYEE_POST.Where(z => z.EID == mevm.EID).FirstOrDefault();
            USERROLE ur = _db.USERROLES.Where(z => z.EID == mevm.EID).FirstOrDefault();
            ROLE rl = _db.ROLES.Where(q => q.ROLENAME == mevm.ROLENAME).FirstOrDefault();
            int rid = Convert.ToInt32(rl.ROLEID);
            //SUPERVISOR sspv = _db.SUPERVISORs.Where(x => x.EID == mevm.EID).FirstOrDefault();

            e.FULL_NAME = mevm.FULL_NAME;
            e.EMAIL = mevm.EMAIL;
            e.CONTACT = mevm.CONTACT;
            e.ADDRESS = mevm.ADDRESS;
            e.GENDER = mevm.GENDER;
            ep.POST = mevm.POST;
            ur.ROLEID = rid;

            SUPERVISOR spv = _db.SUPERVISORs.Where(x => x.EID == mevm.EID).FirstOrDefault();
            int sveid = Convert.ToInt32(mevm.SUPERVISOR1);
            var nam = _db.EMPLOYEEs.Where(x => x.EID == sveid).FirstOrDefault();
            if (nam != null)
            {
                spv.SUPERVISOR1 = nam.EMAIL;
            }
            sveid = Convert.ToInt32(mevm.SUPERVISOR2);
            nam = _db.EMPLOYEEs.Where(x => x.EID == sveid).FirstOrDefault();
            if (nam != null)
            {
                spv.SUPERVISOR2 = nam.EMAIL;
            }

            sveid = Convert.ToInt32(mevm.SUPERVISOR3);
            nam = _db.EMPLOYEEs.Where(x => x.EID == sveid).FirstOrDefault();
            if (nam != null)
            {
                spv.SUPERVISOR3 = nam.EMAIL;
            }
            sveid = Convert.ToInt32(mevm.SUPERVISOR4);
            nam = _db.EMPLOYEEs.Where(x => x.EID == sveid).FirstOrDefault();
            if (nam != null)
            {
                spv.SUPERVISOR4 = nam.EMAIL;
            }
            sveid = Convert.ToInt32(mevm.SUPERVISOR5);
            nam = _db.EMPLOYEEs.Where(x => x.EID == sveid).FirstOrDefault();
            if (nam != null)
            {
                spv.SUPERVISOR5 = nam.EMAIL;
            }
            _db.SaveChanges();
            return RedirectToAction("PersonalProfile");
            //return View("PersonalProfile");
        }
        //==================================For list of the holiday*/========================
        [HttpGet]
        public ActionResult Holidaylist()
        {
            var Hlist = _db.HOLIDAY_LIST.ToList();
            return View(Hlist);
        }
        [HttpGet]
        public ActionResult Holidaycreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Holidaycreate(HOLIDAY_LIST hl)
        {
            int maxhlid = Convert.ToInt32(_db.HOLIDAY_LIST.Select(i => i.HID).DefaultIfEmpty(0).Max());
            if (maxhlid <= 0)
            {
                maxhlid = 1;
            }
            else
            {
                maxhlid++;
            }
            hl.HID = maxhlid;
            _db.HOLIDAY_LIST.Add(hl);
            _db.SaveChanges();
            return RedirectToAction("Holidaylist");
        }
        [HttpPost]
        public ActionResult HolidayDelete(int id)
        {
            HOLIDAY_LIST hld = _db.HOLIDAY_LIST.Where(i => i.HID == id).FirstOrDefault();
            _db.HOLIDAY_LIST.Remove(hld);
            _db.SaveChanges();
            return RedirectToAction("Holidaylist");
        }

        //==============================For the post and basic salary==========================
        [HttpGet]
        public ActionResult postlst(String msg)
        {
            var postcontent = _db.POST_LIST.ToList();
            ViewBag.alert = msg;
            return View(postcontent);
        }

        [HttpGet]
        public ActionResult postcreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult postcreate(POST_LIST pl)
        {
            int maxpid = Convert.ToInt32(_db.POST_LIST.Select(i => i.POID).DefaultIfEmpty(0).Max());
            if (maxpid <= 0)
            {
                maxpid = 1;
            }
            else
            {
                maxpid++;
            }
            pl.POID = maxpid;
            _db.POST_LIST.Add(pl);
            _db.SaveChanges();
            return RedirectToAction("postlst");
        }
        [HttpPost]
        public ActionResult postDelete(int id)
        {

            POST_LIST hld = _db.POST_LIST.Where(i => i.POID == id).FirstOrDefault();
            var test = _db.EMPLOYEE_POST.Where(x => x.POST == hld.POST).FirstOrDefault();
            if (test != null)
            {
                _db.POST_LIST.Remove(hld);
                _db.SaveChanges();
                return RedirectToAction("postlst");
            }
            else
            {
                return RedirectToAction("postlst", new { msg = "Employee have the post you want to delete " });
            }
        }
        //=================================================Role of employee========================================
        [HttpGet]
        public ActionResult rolelst(String msg)
        {
            ViewBag.alert = msg;
            ViewBag.rolelist = _db.ROLES.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult rolecrt(ROLE rl)
        {
            var check = _db.ROLES.Where(x => x.ROLENAME.ToUpper() == rl.ROLENAME.ToUpper()).FirstOrDefault();
            if(check!=null)
            {
                return RedirectToAction("rolelst", new { msg = "The Role you want to created has already been created" });
            }
            else
            {
                Int32 maxroleid = Convert.ToInt32(_db.ROLES.Select(x => x.ROLEID).DefaultIfEmpty(0).Max());
                if (maxroleid <= 0)
                {
                    maxroleid = 1;
                }
                else
                {
                    maxroleid++;
                }
                var rol = new ROLE
                {
                    ROLEID = maxroleid,
                    ROLENAME = rl.ROLENAME,
                };
                _db.ROLES.Add(rol);
                _db.SaveChanges();
                return RedirectToAction("rolelst");
            }
            
        }
        [HttpPost]
        public ActionResult roledel(Int32 id)
        {
            var check = _db.USERROLES.Where(x => x.ROLEID == id).FirstOrDefault();
            if(check==null)
            {
                ROLE rl = _db.ROLES.Where(x => x.ROLEID == id).FirstOrDefault();
                _db.ROLES.Remove(rl);
                _db.SaveChanges();
                return RedirectToAction("rolelst", new { msg = "Role has been deleted" });
            }
            else
            {
                return RedirectToAction("rolelst", new { msg = "Some Employee has the role you want to delete" });
            }
        }


        //===================================================Supervisor=============================================
        [HttpGet]
        public ActionResult Report(string msg)
        {
            int seid = Convert.ToInt32(Session["Eid"]);
            // var mail = _db.EMPLOYEEs.Where(x => x.EID == seid).Select(x => new { x.EMAIL,x.FULL_NAME}).FirstOrDefault();

            SUPERVISOR suplist = _db.SUPERVISORs.Where(x => x.EID == seid).FirstOrDefault();
            ViewBag.supvlist = suplist;
            ViewBag.alert = msg;
            return View();
        }
        [HttpPost]
        public ActionResult Report(REPORTTOSUPERVISOR rts)
        {
            if (rts.SUPERVISOR == "Null")
            {
                return RedirectToAction("Report", new { msg = "Select the Appropriate Supervisor" });
            }
            else
            {
                String email = Session["Emailid"].ToString();
                int maxrpid = Convert.ToInt32(_db.REPORTTOSUPERVISORs.Select(x => x.RTSID).DefaultIfEmpty(0).Max());
                if (maxrpid <= 0)
                {
                    maxrpid = 1;
                }
                else
                {
                    maxrpid++;
                }
                var rep = new REPORTTOSUPERVISOR
                {
                    RTSID = maxrpid,
                    MESSAGE = rts.MESSAGE,
                    EMAIL = email,
                    SUPERVISOR = rts.SUPERVISOR,
                };
                _db.REPORTTOSUPERVISORs.Add(rep);
                _db.SaveChanges();
                return RedirectToAction("Report");
            }
        }
        [HttpGet]
        public ActionResult viewmsg()
        {
            String email = Session["Emailid"].ToString();
            var msglst = _db.REPORTTOSUPERVISORs.Where(x => x.EMAIL == email).ToList();
            return View(msglst);
        }
        [HttpPost]
        public ActionResult Deletemsg(int id)
        {
            REPORTTOSUPERVISOR rts = _db.REPORTTOSUPERVISORs.Where(x => x.RTSID == id).FirstOrDefault();
            _db.REPORTTOSUPERVISORs.Remove(rts);
            _db.SaveChanges();
            return RedirectToAction("viewmsg");
        }
    }
}