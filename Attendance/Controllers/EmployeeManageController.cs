using Attendance.Models;
using System.Data.Entity;
using Attendance.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attendance.Controllers
{
    [Authorize]
    public class EmployeeManageController : Controller
    {
        OracledbEntities _db = new OracledbEntities();
        //
        // GET: /EmployeeManage/
        [HttpGet]
        public ActionResult list()
        {
            var user = _db.EMPLOYEEs.ToList();
            return View(user.OrderBy(x=>x.FULL_NAME));
        }
        [HttpGet]
        public ActionResult Create()
        {

            //int flag = _db.Database.ExecuteSqlCommand("select max(EID) from EMPLOYEE");
            //ViewBag.Message(flag);
            /* var getpostlist = _db.POST_LIST.ToList();
             SelectList list = new SelectList(getpostlist,"POID","POST");           */
            List<POST_LIST> postlist = _db.POST_LIST.ToList();
            ViewBag.Postlist = new SelectList(postlist, "POID", "POST");

            List<ROLE> rolelist = _db.ROLES.ToList();
            ViewBag.Rolelist = new SelectList(rolelist, "ROLEID", "ROLENAME");




            List<ManageEmployeeViewModel> Result = (from e in _db.EMPLOYEEs
                          join p in _db.USERROLES
                          on e.EID equals p.EID
                          where p.ROLEID != 2
                          select new ManageEmployeeViewModel
                          {
                              EID1 = e.EID,
                              FULL_NAME=e.FULL_NAME,
                              GENDER=e.GENDER,
                              CONTACT=e.CONTACT,
                              PASSCODE=e.PASSCODE,
                              ADDRESS=e.ADDRESS,
                              EMAIL=e.EMAIL,

                          }).ToList();            
            ViewBag.supvlist = new SelectList(Result, "EID1", "EMAIL");

            return View();
        }


        [HttpPost]
        public ActionResult Create(ManageEmployeeViewModel mevm)
        {
            if (ModelState.IsValid)
            {
                int maxeid = Convert.ToInt32(_db.EMPLOYEEs.Select(p => p.EID).DefaultIfEmpty(0).Max()); // reading maximum value

                //int check = Convert.ToInt32(_db.EMPLOYEEs.Where(p => p.EMAIL == mevm.EMAIL));//for js

                if (maxeid <= 0)
                {
                    maxeid = 1;
                }
                else
                {
                    maxeid++;
                }
                var empl = new EMPLOYEE
                {
                    EID = maxeid,
                    FULL_NAME = mevm.FULL_NAME,
                    ADDRESS = mevm.ADDRESS,
                    EMAIL = mevm.EMAIL.ToLower(),
                    GENDER = mevm.GENDER.ToString(),
                    PASSCODE = mevm.PASSCODE,
                    CONTACT = mevm.CONTACT.ToString()                    
                };
                _db.EMPLOYEEs.Add(empl);



                //Insert into the table Employee Post
                int maxepoid = Convert.ToInt32(_db.EMPLOYEE_POST.Select(p => p.EPOID).DefaultIfEmpty(1).Max());
                int tpoid = Convert.ToInt32(mevm.POST);
                POST_LIST pl = _db.POST_LIST.Where(c => c.POID == tpoid).FirstOrDefault();
                if (maxepoid <= 0)
                {
                    maxepoid = 1;
                }
                else
                {
                    maxepoid++;
                }
                var upost = new EMPLOYEE_POST
                {
                    EPOID = maxepoid,
                    EID = maxeid,
                    POST = pl.POST
                };

                _db.EMPLOYEE_POST.Add(upost);




                //Insert into table UserRole
                int maxurid = Convert.ToInt32(_db.USERROLES.Select(p => p.USERROLESID).DefaultIfEmpty(0).Max());

                if (maxurid <= 0)
                {
                    maxurid = 1;
                }
                else
                {
                    maxurid++;
                }
                var urole = new USERROLE
                {
                    USERROLESID = maxurid,
                    ROLEID = Convert.ToInt32(mevm.ROLENAME),
                    EID = maxeid
                };
                _db.USERROLES.Add(urole);
                
                // ================================creating for the leave days==================
                
                var levtyplst = _db.LEAVES_TYPES.Select(p => new { p.LEAVE_NAME, p.DAYS_OFF }).ToList();
                foreach (var item in levtyplst)
                {                    
                    int maxlevdaysid = Convert.ToInt32(_db.LEAVEDAYS.Select(p => p.LDID).DefaultIfEmpty(0).Max());
                    if (maxlevdaysid <= 0)
                    {
                        maxlevdaysid = 1;
                    }
                    else
                    {
                        maxlevdaysid++;
                    }
                    var lvd = new LEAVEDAY
                    {
                        LDID = maxlevdaysid,
                        LEAVETYPE = item.LEAVE_NAME,
                        DAYS = 0,
                        EID = maxeid,
                    };
                    _db.LEAVEDAYS.Add(lvd);
                    _db.SaveChanges();                   
                }

                //==================================For supervisor=================================
                SUPERVISOR spv = new SUPERVISOR();
                spv.EID = maxeid;
                int sveid=Convert.ToInt32(mevm.SUPERVISOR1);
                var nam = _db.EMPLOYEEs.Where(x => x.EID == sveid).FirstOrDefault();
                spv.SUPERVISOR1 = nam.EMAIL;
                
                sveid = Convert.ToInt32(mevm.SUPERVISOR2);
                nam = _db.EMPLOYEEs.Where(x => x.EID == sveid).FirstOrDefault();
                if(nam!=null)
                {
                    spv.SUPERVISOR2 = nam.EMAIL;
                }else
                {
                    spv.SUPERVISOR2 = "Null";
                }

                sveid = Convert.ToInt32(mevm.SUPERVISOR3);
                nam = _db.EMPLOYEEs.Where(x => x.EID == sveid).FirstOrDefault();
                if (nam != null)
                {
                    spv.SUPERVISOR3 = nam.EMAIL;
                }else
                {
                    spv.SUPERVISOR3 = "Null";
                }

                sveid = Convert.ToInt32(mevm.SUPERVISOR4);
                nam = _db.EMPLOYEEs.Where(x => x.EID == sveid).FirstOrDefault();
                if (nam != null)
                {
                    spv.SUPERVISOR4 = nam.EMAIL;
                }else
                {
                    spv.SUPERVISOR4="Null";
                }

                sveid = Convert.ToInt32(mevm.SUPERVISOR5);
                nam = _db.EMPLOYEEs.Where(x => x.EID == sveid).FirstOrDefault();
                if (nam != null)
                {
                    spv.SUPERVISOR5 = nam.EMAIL;
                }
                else
                {
                    spv.SUPERVISOR5 = "Null";
                }
                _db.SUPERVISORs.Add(spv);
                
                _db.SaveChanges();
                ViewBag.alert = "Created";
                return RedirectToAction("list");
            }
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ManageEmployeeViewModel mevm = new ManageEmployeeViewModel();
            List<POST_LIST> postlist = _db.POST_LIST.ToList();
            ViewBag.Postlist = new SelectList(postlist, "POID", "POST");

            List<ROLE> rolelist = _db.ROLES.ToList();
            ViewBag.Rolelist = new SelectList(rolelist, "ROLEID", "ROLENAME");


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
        [HttpPost]
        public ActionResult Edit(ManageEmployeeViewModel mevm)
        {
            int tpoid = Convert.ToInt32(mevm.POST);
            EMPLOYEE e = _db.EMPLOYEEs.Where(u => u.EID == mevm.EID).FirstOrDefault();
            e.FULL_NAME = mevm.FULL_NAME;
            e.EMAIL = mevm.EMAIL;
            e.CONTACT = mevm.CONTACT;
            e.ADDRESS = mevm.ADDRESS;
            e.GENDER = mevm.GENDER;
            if (mevm.ROLENAME != null && mevm.POST != null)
            {
                EMPLOYEE_POST ep = _db.EMPLOYEE_POST.Where(z => z.EID == mevm.EID).FirstOrDefault();
                USERROLE ur = _db.USERROLES.Where(z => z.EID == mevm.EID).FirstOrDefault();
                POST_LIST po = _db.POST_LIST.Where(x => x.POID == tpoid).FirstOrDefault();
                ep.POST = po.POST;
                ur.ROLEID = Convert.ToInt32(mevm.ROLENAME);
            }
            else if (mevm.ROLENAME != null)
            {
                USERROLE ur = _db.USERROLES.Where(z => z.EID == mevm.EID).FirstOrDefault();
                ur.ROLEID = Convert.ToInt32(mevm.ROLENAME);
            }
            else if (mevm.POST != null)
            {
                EMPLOYEE_POST ep = _db.EMPLOYEE_POST.Where(z => z.EID == mevm.EID).FirstOrDefault();
                POST_LIST po = _db.POST_LIST.Where(x => x.POID == tpoid).FirstOrDefault();
                ep.POST = po.POST;
            }

            SUPERVISOR spv = _db.SUPERVISORs.Where(x => x.EID == mevm.EID).FirstOrDefault();
            int sveid = Convert.ToInt32(mevm.SUPERVISOR1);
            var nam = _db.EMPLOYEEs.Where(x => x.EID == sveid).FirstOrDefault();
           if(nam!=null)
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
            return RedirectToAction("list");

        }
        [HttpGet]
        public ActionResult Details(int id, ManageEmployeeViewModel mevm)
        {
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

        [HttpGet]
        public ActionResult Delete(int id, ManageEmployeeViewModel mevm)
        {
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
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            SUPERVISOR spv = _db.SUPERVISORs.Where(x => x.EID == id).FirstOrDefault();
            _db.SUPERVISORs.Remove(spv);
            EMPLOYEE_POST ep = _db.EMPLOYEE_POST.Where(u => u.EID == id).FirstOrDefault();
            USERROLE ur = _db.USERROLES.Where(u => u.EID == id).FirstOrDefault();
            EMPLOYEE e = _db.EMPLOYEEs.Where(u => u.EID == id).FirstOrDefault();
            _db.EMPLOYEE_POST.Remove(ep);
            _db.USERROLES.Remove(ur);
            _db.SaveChanges();
            var attc = _db.ATTENDANCE_CLAIM.Where(u => u.EID == id).ToList();
            foreach(var item in attc)
            {
                ATTENDANCE_CLAIM atd = _db.ATTENDANCE_CLAIM.Where(u => u.EID == id).FirstOrDefault();
                _db.ATTENDANCE_CLAIM.Remove(atd);
                _db.SaveChanges();
            }
           
            var att = _db.ATTENDANCEs.Where(u => u.EID == id).ToList();
            foreach (var item in att)
            {
                ATTENDANCE atd = _db.ATTENDANCEs.Where(u => u.EID == id).FirstOrDefault();
                _db.ATTENDANCEs.Remove(atd);
                _db.SaveChanges();
            } 
            var lev = _db.LEAVEs.Where(u => u.EID == id).ToList();
            foreach (var item in lev)
            {
                LEAVE atd = _db.LEAVEs.Where(u => u.EID == id).FirstOrDefault();
                _db.LEAVEs.Remove(atd);
                _db.SaveChanges();
            }
            var levd = _db.LEAVEDAYS.Where(u => u.EID == id).ToList();
            foreach (var item in levd)
            {
                LEAVEDAY atd = _db.LEAVEDAYS.Where(u => u.EID == id).FirstOrDefault();
                _db.LEAVEDAYS.Remove(atd);
                _db.SaveChanges();
            }
            
            var mons = _db.MONTHLY_STATEMENT.Where(u => u.EID == id).ToList();
            foreach (var item in mons)
            {
                MONTHLY_STATEMENT atd = _db.MONTHLY_STATEMENT.Where(u => u.EID == id).FirstOrDefault();
                _db.MONTHLY_STATEMENT.Remove(atd);
                _db.SaveChanges();
            }
            
            var pay = _db.PAYOUTs.Where(u => u.EID == id).ToList();
            foreach (var item in pay)
            {
                PAYOUT atd = _db.PAYOUTs.Where(u => u.EID == id).FirstOrDefault();
                _db.PAYOUTs.Remove(atd);
                _db.SaveChanges();
            }
            
            var rep = _db.REPORTTOSUPERVISORs.Where(u => u.EMAIL == e.EMAIL).ToList();
            foreach (var item in rep)
            {
                REPORTTOSUPERVISOR atd = _db.REPORTTOSUPERVISORs.Where(u => u.EMAIL == e.EMAIL).FirstOrDefault();
                _db.REPORTTOSUPERVISORs.Remove(atd);
                _db.SaveChanges();
            }
            
            var wio = _db.WORK_IN_OUT.Where(u => u.EID == id).ToList();
            foreach (var item in wio)
            {
                WORK_IN_OUT atd = _db.WORK_IN_OUT.Where(u => u.EID == id).FirstOrDefault();
                _db.WORK_IN_OUT.Remove(atd);
                _db.SaveChanges();
            }
            
            _db.EMPLOYEEs.Remove(e);
            _db.SaveChanges();
            return RedirectToAction("list");
        }

        public JsonResult IsUserExists(string Email)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            return Json(_db.EMPLOYEEs.Any(x => x.EMAIL == Email), JsonRequestBehavior.AllowGet);
        }

    }
}