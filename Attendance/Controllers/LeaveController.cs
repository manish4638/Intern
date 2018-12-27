using Attendance.Models;
using Attendance.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attendance.Controllers
{
    [Authorize]
    public class LeaveController : Controller
    {
        OracledbEntities _db = new OracledbEntities();
        //
        // GET: /Leave/
        [HttpGet]
        public ActionResult Leave(string msg)
        {
                         // Not  working to pass the leave.cshtml js
            ViewBag.Dates = _db.HOLIDAY_LIST.Select(x => x.H_DATE).ToArray();                                           // Not  working

            ViewBag.Message = msg;
            List<LEAVES_TYPES> leavelist = _db.LEAVES_TYPES.ToList();
            ViewBag.leavelst = new SelectList(leavelist, "LTID", "LEAVE_NAME");

            Int32 seid = Convert.ToInt32(Session["Eid"]);
            var leave = _db.LEAVEDAYS.Where(x => x.EID == seid).ToList();


            var Result = (from p in _db.LEAVEDAYS
                          join e in _db.LEAVES_TYPES
                          on p.LEAVETYPE equals e.LEAVE_NAME
                          where p.EID == seid
                          select new leavedaysViewmodel
                          {
                              EID = p.EID,
                              DAYS_OFF = e.DAYS_OFF,
                              LDID = p.LDID,
                              DAYS = p.DAYS,
                              LEAVETYPE = e.LEAVE_NAME

                          }).ToList();
            ViewBag.leavehistory = Result;
            return View();
        }
        [HttpPost]
        public ActionResult Leave(LEAVE lv)
        {
            //LEAVESTATU ls = new LEAVESTATU();
            lv.EID = Convert.ToInt32(Session["Eid"]);
            int NoOfDays = (lv.REQUESTED_TO.Value.Date - lv.REQUESTED_FROM.Value.Date).Days+1;
            DateTime startdate = Convert.ToDateTime(lv.REQUESTED_FROM);
            var datelst = _db.LEAVEs.Where(x => x.EID == lv.EID).ToList();
            foreach(var item in datelst)
            {
                if((lv.REQUESTED_FROM>=item.REQUESTED_FROM && lv.REQUESTED_FROM<=item.REQUESTED_TO) || (lv.REQUESTED_TO>=item.REQUESTED_FROM && lv.REQUESTED_TO<= item.REQUESTED_TO))
                {
                    return RedirectToAction("Leave", new { msg = "You have already apply for the date selected" });
                }
            }

            for(int i=0;i<NoOfDays;i++)
            {                
                DateTime testdate = startdate.AddDays(i);
                string day=testdate.DayOfWeek.ToString().ToUpper();
                var sholiday=_db.HOLIDAY_LIST.Where(x=>x.H_DATE==testdate);
                if (testdate.DayOfWeek.ToString().ToUpper() == "SUNDAY" || testdate.DayOfWeek.ToString().ToUpper() == "SATURDAY" || sholiday==null)
                {
                   
                    return RedirectToAction("Leave", new { msg = "Choose the Date properly" });
                }
            }
            int lid = Convert.ToInt32(_db.LEAVEs.Select(p => p.LID).DefaultIfEmpty(0).Max()); // reading maximum value

            if (lid <= 0)
            {
                lid = 1;
            }
            else
            {
                lid++;
            }
          
            lv.LID = lid;
            
            
            DateTime dt1 = Convert.ToDateTime(lv.REQUESTED_FROM);
            DateTime dt2 = Convert.ToDateTime(lv.REQUESTED_TO);
            int typenum = Convert.ToInt32(lv.LEAVE_TYPE);
            lv.DAYS = NoOfDays;                
            lv.LEAVE_TYPE=_db.LEAVES_TYPES.Where(x=>x.LTID==typenum).Select(x=>x.LEAVE_NAME).FirstOrDefault();
            lv.STATUS = "UnKnown";
            _db.LEAVEs.Add(lv);

            //===================checking the limit====================
            var checkld = _db.LEAVEDAYS.Where(x => x.EID == lv.EID && x.LEAVETYPE == lv.LEAVE_TYPE).FirstOrDefault();
            int daysoff = Convert.ToInt32(_db.LEAVES_TYPES.Where(x => x.LEAVE_NAME == lv.LEAVE_TYPE).Select(x => x.DAYS_OFF).FirstOrDefault());

            if (daysoff < NoOfDays || daysoff < (NoOfDays + checkld.DAYS))
            {
                return RedirectToAction("Leave", new { msg = "leave days exceed the limit provided" });
            }

            if (typenum == 1 && NoOfDays != 1)
            {
                return RedirectToAction("Leave", new { msg = "casual leave have maximum of one day leave" });
            }
            
            if(dt1.Month!=dt2.Month)
            {
                return RedirectToAction("Leave", new { msg = "You cannot Select the Date of Two Month" });
            }


            /*if(checkld==null)
            {
                if(daysoff<NoOfDays)
                {
                    return RedirectToAction("Leave", new { msg = "leave days exceed the limit provided" });
                }
            }
            else
            {
                if (daysoff < (NoOfDays+checkld.DAYS))
                {
                    return RedirectToAction("Leave", new { msg = "leave days exceed the limit provided" });
                } 
            }
            */

           /* //---------------------------------For adding to leave days-------------------------
            var checkld = _db.LEAVEDAYS.Where(x => x.EID == lv.EID && x.LEAVETYPE == lv.LEAVE_TYPE).FirstOrDefault();
            int daysoff = Convert.ToInt32(_db.LEAVES_TYPES.Where(x => x.LEAVE_NAME == lv.LEAVE_TYPE).Select(x => x.DAYS_OFF).FirstOrDefault());
            if(checkld==null)
            {                
                if(daysoff<NoOfDays)
                {
                    return RedirectToAction("Leave", new { msg = "leave days exceed the limit provided" });
                }
                else
                {
                    LEAVEDAY ld = new LEAVEDAY();
                    int ldid = Convert.ToInt32(_db.LEAVEDAYS.Select(p => p.LDID).DefaultIfEmpty(0).Max());
                    if (ldid <= 0)
                    {
                        ldid = 1;
                    }
                    else
                    {
                        ldid++;
                    }
                    ld.EID = lv.EID;
                    ld.LDID = ldid;
                    ld.LEAVETYPE = lv.LEAVE_TYPE;
                    ld.DAYS = NoOfDays;
                    _db.LEAVEDAYS.Add(ld);
                }          
                              
            }
            else
            {
                if (daysoff < (NoOfDays+checkld.DAYS))
                {
                    return RedirectToAction("Leave", new { msg = "leave days exceed the limit provided" });
                }   
                else
                {
                    checkld.DAYS = checkld.DAYS + NoOfDays;
                }
            }*/
            _db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Leave", new { msg=""});
        }
        [HttpGet]
        public ActionResult leave_Requested()
        {
            string email = Session["Emailid"].ToString();
            var lst = _db.LEAVEs.ToList();            
            List<leaveviewmodel> datalst = new List<leaveviewmodel>();            
            foreach (var item in lst)
            {
                var test = _db.SUPERVISORs.Where(x => x.EID == item.EID && (x.SUPERVISOR1 == email || x.SUPERVISOR2 == email || x.SUPERVISOR3 == email || x.SUPERVISOR4 == email || x.SUPERVISOR5 == email)).FirstOrDefault();
                var data = new leaveviewmodel();
                data.LID = item.LID;
                data.EID = item.EID;
                data.LEAVE_TYPE = item.LEAVE_TYPE;
                data.FROM_DATE = item.FROM_DATE;
                data.TO_DATE = item.TO_DATE;
                data.DAYS = item.DAYS;
                data.REASON = item.REASON;
                data.STATUS = item.STATUS;
                data.COMENT = item.COMENT;
                data.REQUESTED_FROM = item.REQUESTED_FROM;
                data.REQUESTED_TO = item.REQUESTED_TO;
                data.flag = "0";
                if (test != null)
                {
                    data.flag = "1";
                }
                else
                {
                    data.flag = "0";
                }
                datalst.Add(data);
            }
            return View(datalst.OrderByDescending(x => x.LID));           
        }
                

        [HttpGet]
        public ActionResult Approved(Int32 id)
        {
            var app=_db.LEAVEs.Where(i=>i.LID==id).FirstOrDefault();
            return View(app);
        }
        [HttpPost]
        public ActionResult Approved(LEAVE lvl)
        {
            LEAVE lv = _db.LEAVEs.Where(u => u.LID == lvl.LID).FirstOrDefault();
            lv.STATUS = "Approved";
            lv.FROM_DATE = lvl.REQUESTED_FROM;
            lv.TO_DATE = lvl.REQUESTED_TO;
            lv.COMENT = lvl.REASON;
            lv.DAYS = (lv.TO_DATE.Value.Date - lv.FROM_DATE.Value.Date).Days + 1;
            _db.SaveChanges();
            //====================== adding in leavedays===============
            var checkld = _db.LEAVEDAYS.Where(x => x.EID == lv.EID && x.LEAVETYPE == lv.LEAVE_TYPE).FirstOrDefault();
            int daysoff = Convert.ToInt32(_db.LEAVES_TYPES.Where(x => x.LEAVE_NAME == lv.LEAVE_TYPE).Select(x => x.DAYS_OFF).FirstOrDefault());
            if(checkld==null)
            {
                    LEAVEDAY ld = new LEAVEDAY();
                    int ldid = Convert.ToInt32(_db.LEAVEDAYS.Select(p => p.LDID).DefaultIfEmpty(0).Max());
                    if (ldid <= 0)
                    {
                        ldid = 1;
                    }
                    else
                    {
                        ldid++;
                    }
                    ld.EID = lv.EID;
                    ld.LDID = ldid;
                    ld.LEAVETYPE = lv.LEAVE_TYPE;
                    ld.DAYS = lvl.DAYS;                
                    _db.LEAVEDAYS.Add(ld);
            }
            else
            {
                    checkld.DAYS = checkld.DAYS + lvl.DAYS;
            }

            /*For monthly statment*/
            DateTime dt = Convert.ToDateTime(lvl.FROM_DATE);
            string leave_monyr = dt.Date.ToString("MM/yyyy");            
            
            var ms = _db.MONTHLY_STATEMENT.Where(i => i.EID == lvl.EID && i.MONTH == leave_monyr).FirstOrDefault();
            if (ms==null)
            {
                int maxmonrecid = Convert.ToInt32(_db.MONTHLY_STATEMENT.Select(p => p.MON_REC_ID).DefaultIfEmpty(0).Max()); // reading maximum value
                MONTHLY_STATEMENT msi = new MONTHLY_STATEMENT();
                if (maxmonrecid <= 0)
                {
                    maxmonrecid = 1;
                }
                else
                {
                    maxmonrecid++;
                }
                msi.MON_REC_ID = maxmonrecid;
               // msi.EID = 1;
                msi.EID = lv.EID;
                msi.MONTH = leave_monyr;
                msi.TOTALLEAVEDAYS = lvl.DAYS;
                _db.MONTHLY_STATEMENT.Add(msi);
            }
            else
            {
                if (ms.TOTALLEAVEDAYS == null)
                {
                    ms.TOTALLEAVEDAYS = lv.DAYS;
                }
                else
                {
                    ms.TOTALLEAVEDAYS = ms.TOTALLEAVEDAYS + lv.DAYS;
                }
            }
            _db.SaveChanges();
            return RedirectToAction("leave_Requested");
        }

        [HttpGet]
        public ActionResult Makeleavechanges(Int32 id,string msg)
        {
            var app = _db.LEAVEs.Where(i => i.LID == id).FirstOrDefault();
            ViewBag.alert = msg;
            return View(app);
        }
        [HttpPost]
        public ActionResult Makeleavechanges(LEAVE lvl)
        {
            LEAVE lv = _db.LEAVEs.Where(u => u.LID == lvl.LID).FirstOrDefault();
            lv.STATUS = "Approved";
            lv.FROM_DATE = lvl.FROM_DATE;
            lv.TO_DATE = lvl.TO_DATE;
            lv.COMENT = lvl.COMENT;
            lv.DAYS = (lv.TO_DATE.Value.Date - lv.FROM_DATE.Value.Date).Days + 1;
            if (lv.REQUESTED_FROM>lv.FROM_DATE || lv.REQUESTED_TO<lv.TO_DATE)
            {
                return RedirectToAction("Makeleavechanges", new { msg = "Please select the appropriate Granted date" });
            }

           // _db.SaveChanges();
            //====================== adding in leavedays===============
            var checkld = _db.LEAVEDAYS.Where(x => x.EID == lv.EID && x.LEAVETYPE == lv.LEAVE_TYPE).FirstOrDefault();
            int daysoff = Convert.ToInt32(_db.LEAVES_TYPES.Where(x => x.LEAVE_NAME == lv.LEAVE_TYPE).Select(x => x.DAYS_OFF).FirstOrDefault());
            if (checkld == null)
            {
                LEAVEDAY ld = new LEAVEDAY();
                int ldid = Convert.ToInt32(_db.LEAVEDAYS.Select(p => p.LDID).DefaultIfEmpty(0).Max());
                if (ldid <= 0)
                {
                    ldid = 1;
                }
                else
                {
                    ldid++;
                }
                ld.EID = lv.EID;
                ld.LDID = ldid;
                ld.LEAVETYPE = lv.LEAVE_TYPE;
                ld.DAYS = lv.DAYS;
                _db.LEAVEDAYS.Add(ld);
            }
            else
            {
                checkld.DAYS = checkld.DAYS + lv.DAYS;
            }

            /*For monthly statment*/
            DateTime dt = Convert.ToDateTime(lvl.FROM_DATE);
            string leave_monyr = dt.Date.ToString("MM/yyyy");

            var ms = _db.MONTHLY_STATEMENT.Where(i => i.EID == lvl.EID && i.MONTH == leave_monyr).FirstOrDefault();
            if (ms == null)
            {
                int maxmonrecid = Convert.ToInt32(_db.MONTHLY_STATEMENT.Select(p => p.MON_REC_ID).DefaultIfEmpty(0).Max()); // reading maximum value
                MONTHLY_STATEMENT msi = new MONTHLY_STATEMENT();
                if (maxmonrecid <= 0)
                {
                    maxmonrecid = 1;
                }
                else
                {
                    maxmonrecid++;
                }
                msi.MON_REC_ID = maxmonrecid;
                // msi.EID = 1;
                msi.EID = lv.EID;
                msi.MONTH = leave_monyr;
                msi.TOTALLEAVEDAYS = lv.DAYS;
                _db.MONTHLY_STATEMENT.Add(msi);
            }
            else
            {
                if(ms.TOTALLEAVEDAYS==null)
                {
                    ms.TOTALLEAVEDAYS = lv.DAYS;
                }
                else
                {
                    ms.TOTALLEAVEDAYS = ms.TOTALLEAVEDAYS + lv.DAYS;
                }
               
            }
            _db.SaveChanges();
            return RedirectToAction("leave_Requested");
            // return RedirectToAction("Approved",new{ lvl});
            //return RedirectToAction("Approved",new{LEAVE lv=lvl});
        }



        [HttpGet]
        public ActionResult Declined(Int32 id)
        {
            var app = _db.LEAVEs.Where(i => i.LID == id).FirstOrDefault();
            return View(app);
        }
        [HttpPost]
        public ActionResult Declined(LEAVE lvl)
        {
            LEAVE lv = _db.LEAVEs.Where(u => u.LID == lvl.LID).FirstOrDefault();
            lv.STATUS = "Declined";             
            _db.SaveChanges();
            return RedirectToAction("leave_Requested");
        }
        [HttpGet]
        public ActionResult leavestus()
        {
            int seid = Convert.ToInt32(Session["Eid"]);
            var leavestus = _db.LEAVEs.Where(i => i.EID==seid).ToList();
            return View(leavestus.OrderBy(i=>i.LID));
        }


        //===========================Leave type CRUD========================

        [HttpGet]
        public ActionResult leavetypelist()
        {
            var levtyplst = _db.LEAVES_TYPES.ToList();
            return View(levtyplst);
        }
        [HttpGet]
        public ActionResult createleavetype()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createleavetype(LEAVES_TYPES lt)
        {
            int ltid = Convert.ToInt32(_db.LEAVES_TYPES.Select(p => p.LTID).DefaultIfEmpty(0).Max()); // reading maximum value           
            if (ltid <= 0)
            {
                ltid = 1;
            }
            else
            {
                ltid++;
            }
            lt.LTID = ltid;
            _db.LEAVES_TYPES.Add(lt);
            _db.SaveChanges();
            return RedirectToAction("leavetypelist");
        }

        [HttpPost]
        public ActionResult delleavetype(int ltid)
        {
            LEAVES_TYPES lt = _db.LEAVES_TYPES.Where(u => u.LTID == ltid).FirstOrDefault();
            _db.LEAVES_TYPES.Remove(lt);
            _db.SaveChanges();
            return RedirectToAction("leavetypelist"); 
        }
        [HttpGet]
        public ActionResult editleavetype(int ltid)
        {
            LEAVES_TYPES elt = _db.LEAVES_TYPES.Where(x => x.LTID == ltid).FirstOrDefault();
            return View(elt);
        }
        [HttpPost]
        public ActionResult editleavetype(LEAVES_TYPES elt)
        {
            LEAVES_TYPES lt = _db.LEAVES_TYPES.Where(x => x.LTID == elt.LTID).FirstOrDefault();
            lt.LEAVE_NAME = elt.LEAVE_NAME;
            lt.DAYS_OFF = elt.DAYS_OFF;
            _db.SaveChanges();
            return RedirectToAction("leavetypelist");
        }
        //================================ Leavedays ===============================   
        [HttpGet]
        public ActionResult userleavedays()
        {
            Int32 seid=Convert.ToInt32(Session["Eid"]);

            var leave=_db.LEAVEDAYS.Where(x=>x.EID==seid).ToList();


            var Result = (from p in _db.LEAVEDAYS
                          join e in _db.LEAVES_TYPES
                          on p.LEAVETYPE equals e.LEAVE_NAME
                          where p.EID == seid
                          select new leavedaysViewmodel
                          {
                              EID=p.EID,
                              DAYS_OFF=e.DAYS_OFF,
                              LDID=p.LDID,
                              DAYS=p.DAYS,
                              LEAVETYPE=e.LEAVE_NAME
                              
                          }).ToList();
            return View(Result);
        }
        [HttpGet]
        public ActionResult Adminleavedays()
        {
            var Result = (from p in _db.LEAVEDAYS
                          join e in _db.LEAVES_TYPES
                          on p.LEAVETYPE equals e.LEAVE_NAME                        
                          select new leavedaysViewmodel
                          {
                              EID = p.EID,
                              DAYS_OFF = e.DAYS_OFF,
                              LDID = p.LDID,
                              DAYS = p.DAYS,
                              LEAVETYPE = e.LEAVE_NAME

                          }).ToList();
            return View(Result);
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                          
	}
}