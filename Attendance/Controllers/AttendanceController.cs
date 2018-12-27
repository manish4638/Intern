using Attendance.Models;
using Attendance.Models.Viewmodel;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;
using System.Web.Mvc;

namespace Attendance.Controllers
{
    [Authorize]
    public class AttendanceController : Controller
    {
        OracledbEntities _db = new OracledbEntities();
        //leaveEntities _lve = new leaveEntities();
        ATTENDANCE ate = new ATTENDANCE();
        //
        // GET: /Attendance/
        [Authorize]
        [HttpPost]
        public ActionResult login_time()
        {
            int maxaid = Convert.ToInt32(_db.ATTENDANCEs.Select(p => p.AID).DefaultIfEmpty(0).Max()); // reading maximum value
            int seid = Convert.ToInt32(Session["Eid"]);
            ATTENDANCE incheck = _db.ATTENDANCEs.Where(p => p.EID == seid && p.ATTEND_DATE == System.DateTime.Today).FirstOrDefault();
            if (incheck == null)
            {
                if (maxaid <= 0)
                {
                    maxaid = 1;
                }
                else
                {
                    maxaid++;
                }
                ate.AID = maxaid;
                ate.EID = Convert.ToInt32(Session["Eid"]);
                // Session.Add("said", ate.AID);
                ate.ATTEND_DATE = System.DateTime.Today;
                ate.LOGIN_TIME = System.DateTime.Now;
                //  ate.LOGOUT_TIME = System.DateTime.Now.AddHours(5);
                string res = System.DateTime.Now.ToString();
                res = res.Substring(res.Length - 11);
                if (ate.LOGIN_TIME <= Convert.ToDateTime("10:00:00 AM"))
                {
                    ate.SHIFT = "A";
                }
                else if (ate.LOGIN_TIME > Convert.ToDateTime("10:00:00 AM") && ate.LOGIN_TIME < Convert.ToDateTime("6:00:00 PM"))
                {
                    ate.SHIFT = "B";
                }
                else if (ate.LOGIN_TIME >= Convert.ToDateTime("6:00:00 PM"))
                {
                    ate.SHIFT = "C";

                    //for meal allowance
                    DateTime dt = Convert.ToDateTime(ate.ATTEND_DATE);
                    string worhrs_monyr = dt.Date.ToString("MM/yyyy");
                    var ms = _db.MONTHLY_STATEMENT.Where(i => i.EID == seid && i.MONTH == worhrs_monyr).FirstOrDefault();
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
                        msi.EID = seid;
                        msi.MONTH = worhrs_monyr;
                        msi.TOTALMEALALLOW = 1;                        
                        _db.MONTHLY_STATEMENT.Add(msi);
                    }
                    else
                    {
                        if(ms.TOTALMEALALLOW==null)
                        {
                            ms.TOTALMEALALLOW = 0;
                        }
                        ms.TOTALMEALALLOW ++;                        
                    }
                    //in "login shift c commented" at attendance folder
                }                
                _db.ATTENDANCEs.Add(ate);
                _db.SaveChanges();
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('You have Already Log-In!');</script>");
                //   ViewBag.Message = "you have already logged-in";
            }
            return RedirectToAction("Schedule", "Home");
        }
        [Authorize]
        [HttpPost]
        public ActionResult logout_time(ATTENDANCE atend)
        {
            int seid = Convert.ToInt32(Session["Eid"]);
            DateTime today = System.DateTime.Today;
            DateTime yesterday = System.DateTime.Today.AddDays(-1);
            
            //--------------------------------------------------------------------------------

            //ATTENDANCE check = _db.ATTENDANCEs.Where(p => p.EID == seid && p.ATTEND_DATE == System.DateTime.Today && p.SHIFT != "C").FirstOrDefault();
            ATTENDANCE check = _db.ATTENDANCEs.Where(p => p.EID == seid && p.ATTEND_DATE == System.DateTime.Today).FirstOrDefault();
            if (check != null && check.LOGOUT_DATE == null && check.LOGOUT_TIME == null && check.ATTEND_DATE == System.DateTime.Today)
            {
                check.LOGOUT_TIME = System.DateTime.Now;
                TimeSpan ttltim = Convert.ToDateTime(check.LOGOUT_TIME) - Convert.ToDateTime(check.LOGIN_TIME);
                string strtim = ttltim.ToString();
                check.TOTAL_TIME = Convert.ToDateTime(strtim);
                check.LOGOUT_DATE = System.DateTime.Today;

                //--------------------------------------------------
                /*For monthly statment*/
                DateTime dt = Convert.ToDateTime(check.TOTAL_TIME);
                string worhrs_monyr = dt.Date.ToString("MM/yyyy");

                double inhrs = ttltim.TotalHours;

                var ms = _db.MONTHLY_STATEMENT.Where(i => i.EID == seid && i.MONTH == worhrs_monyr).FirstOrDefault();
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
                    msi.EID = seid;
                    msi.MONTH = worhrs_monyr;
                    msi.TOTALWORKINGHRS = System.Math.Round(Convert.ToDecimal(inhrs), 2);
                    if(check.LOGOUT_TIME>=Convert.ToDateTime("7:30 PM"))
                    {                        
                        msi.TOTALMEALALLOW = 1;
                    }
                    _db.MONTHLY_STATEMENT.Add(msi);
                }
                else
                {
                    ms.TOTALWORKINGHRS = ms.TOTALWORKINGHRS + Convert.ToDecimal(inhrs);
                    if (check.LOGOUT_TIME >= Convert.ToDateTime("7:30 PM"))
                    {
                        if(ms.TOTALMEALALLOW==null)
                        {
                            ms.TOTALMEALALLOW = 0;
                        }
                        ms.TOTALMEALALLOW ++;
                    }
                }
                String dayofweek = Convert.ToDateTime(check.ATTEND_DATE).DayOfWeek.ToString().ToUpper();
                // string dayofweek = System.DateTime.Now.DayOfWeek.ToString().ToUpper();
                var holidaycheck = _db.HOLIDAY_LIST.Where(i => i.H_DATE == check.ATTEND_DATE).FirstOrDefault();
                if (holidaycheck != null)
                {
                    if(ms.TOTALWOSH==null)
                    {
                        ms.TOTALWOSH = 0;
                    }
                    ms.TOTALWOSH = ms.TOTALWOSH + Convert.ToDecimal(inhrs);                    
                }
                else if (dayofweek == "SUNDAY" || dayofweek == "SATURDAY")
                {
                    if (ms.TOTALWOH == null)
                    {
                        ms.TOTALWOH = 0;
                    }
                    ms.TOTALWOH = ms.TOTALWOH + Convert.ToDecimal(inhrs);
                }
                if (check.LOGOUT_TIME < Convert.ToDateTime("7:30 pm") && check.SHIFT=="C" )
                {
                    ms.TOTALMEALALLOW = ms.TOTALMEALALLOW - 1;
                }

                //--------------------------------------------------
                _db.SaveChanges();
                return RedirectToAction("Schedule", "Home");
            }
            else
            {
                ATTENDANCE check1 = _db.ATTENDANCEs.Where(p => p.EID == seid && p.ATTEND_DATE == yesterday && p.SHIFT == "C").FirstOrDefault();

                if (check1 != null && check1.LOGOUT_TIME == null && check1.LOGOUT_DATE == null)
                {
                    check1.LOGOUT_DATE = System.DateTime.Today;
                    check1.LOGOUT_TIME = System.DateTime.Now;
                    TimeSpan ttltim = Convert.ToDateTime(check1.LOGOUT_TIME) - Convert.ToDateTime(check1.LOGIN_TIME);
                    string strtim = ttltim.ToString();
                    check1.TOTAL_TIME = Convert.ToDateTime(strtim);

                    //For monthly statment

                    DateTime dt = Convert.ToDateTime(check1.TOTAL_TIME);
                    string worhrs_monyr = dt.Date.ToString("MM/yyyy");

                    double inhrs = ttltim.TotalHours;

                    var ms = _db.MONTHLY_STATEMENT.Where(i => i.EID == seid && i.MONTH == worhrs_monyr).FirstOrDefault();
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
                        msi.EID = seid;
                        msi.MONTH = worhrs_monyr;
                        msi.TOTALWORKINGHRS = System.Math.Round(Convert.ToDecimal(inhrs), 2);
                        msi.TOTALNIGHTSHIFTS = System.Math.Round(Convert.ToDecimal(inhrs), 2);                        
                        _db.MONTHLY_STATEMENT.Add(msi);
                    }
                    else
                    {                        
                        ms.TOTALWORKINGHRS = System.Math.Round(Convert.ToDecimal(inhrs), 2);
                        
                        String dayofweek = Convert.ToDateTime(check.ATTEND_DATE).DayOfWeek.ToString().ToUpper();
                        // string dayofweek = System.DateTime.Now.DayOfWeek.ToString().ToUpper();
                        var holidaycheck = _db.HOLIDAY_LIST.Where(i => i.H_DATE == check.ATTEND_DATE).FirstOrDefault();
                        if (holidaycheck != null)
                        {
                            if (ms.TOTALWOSH == null)
                            {
                                ms.TOTALWOSH = 0;
                            }
                            ms.TOTALWOSH = ms.TOTALWOSH + Convert.ToDecimal(inhrs);
                        }
                        else if (dayofweek == "SUNDAY" || dayofweek == "SATURDAY")
                        {
                            if (ms.TOTALWOH == null)
                            {
                                ms.TOTALWOH = 0;
                            }
                            ms.TOTALWOH = ms.TOTALWOH + Convert.ToDecimal(inhrs);
                        }
                        else
                        {
                            if (ms.TOTALNIGHTSHIFTS == null)
                            {
                                ms.TOTALNIGHTSHIFTS = 0;
                            }
                            ms.TOTALNIGHTSHIFTS = ms.TOTALNIGHTSHIFTS + Convert.ToDecimal(inhrs); 
                        }
                    }                          
                    _db.SaveChanges();
                    return RedirectToAction("Schedule", "Home");
                }
                else
                {
                   // ViewBag.Message = "You have already logout";
                    return RedirectToAction("Schedule", "Home", new { msg = "You have already logout" });
                }
            }

            //--------------------------------------------------------------------------------------------------------
            
        }


        /*For Work in and out*/
        [HttpGet]
        public ActionResult inoutsession()
        {
            int seid = Convert.ToInt32(Session["Eid"]);
            var inoutlist = _db.WORK_IN_OUT.Where(i => i.EID == seid).ToList();
            return View(inoutlist.OrderBy(i => i.IN_OUT_ID));
        }

        [HttpGet]
        public ActionResult workout()
        {
            int seid = Convert.ToInt32(Session["Eid"]);
            var checklogin = _db.ATTENDANCEs.Where(x => x.EID == seid && x.ATTEND_DATE == System.DateTime.Today).FirstOrDefault();
            if(checklogin==null)
            {
                return RedirectToAction("Schedule", "Home", new { msg="You have to Login First"}); 
            }
            else
            {
                return View();
            }
            
        }

        //[HttpPost, ActionName("workout")]
        [HttpPost]
        public ActionResult workout(WORK_IN_OUT wiop)
        {
            WORK_IN_OUT win = new WORK_IN_OUT();
            int seid = Convert.ToInt32(Session["Eid"]);
            int maxwioid = Convert.ToInt32(_db.WORK_IN_OUT.Select(i => i.IN_OUT_ID).DefaultIfEmpty(0).Max());
            if (maxwioid <= 0)
            {
                maxwioid = 1;
            }
            else
            {
                maxwioid++;
            }
            win.IN_OUT_ID = maxwioid;
            win.EID = seid;
            win.OUT_ON_WORK = System.DateTime.Now;
            win.REASON = wiop.REASON;
            _db.WORK_IN_OUT.Add(win);
            _db.SaveChanges();
            return RedirectToAction("schedule", "home");
        }
        [HttpPost]
        public ActionResult workin()
        {
            WORK_IN_OUT win = new WORK_IN_OUT();
            int seid = Convert.ToInt32(Session["Eid"]);           
            //int seid = 1;            
            var newio = _db.WORK_IN_OUT.Where(x => x.EID == seid).FirstOrDefault();
            if (newio == null)
            {
                return RedirectToAction("schedule", "home", new { msg = "you have not gone out of office today" });
            }
            else
            {
                Int32 qwe = Convert.ToInt32(_db.WORK_IN_OUT.Where(c => c.EID == seid).Max(s => s.IN_OUT_ID));
                //Int32 wioid = _db.WORK_IN_OUT.Where(i => i.OUT_ON_WORK == qwe).FirstOrDefault();
                win = _db.WORK_IN_OUT.Where(i => i.IN_OUT_ID == qwe).FirstOrDefault();
                DateTime dt = Convert.ToDateTime(win.OUT_ON_WORK);
                string strd = dt.ToString("MM/dd/yyyy 12:00:00 'AM'");
                DateTime dtstring = DateTime.Parse(strd);
                if (win.RETURN_INSIDE == null && dtstring == System.DateTime.Today)
                {
                    win.RETURN_INSIDE = System.DateTime.Now;
                    _db.SaveChanges();
                    return RedirectToAction("schedule", "home");
                }
                else
                {
                    // ViewBag.Message = "you have not gone out of office today";
                    return RedirectToAction("schedule", "home", new { msg = "you have not gone out of office today" });
                }
            }
        }
        [HttpGet]//for admin
        public ActionResult Allattendance()
        {
            var alattend = _db.ATTENDANCEs.ToList();
            return View(alattend);
        }


        //------------------------------Attendance Claim------------------------------------
        [HttpGet]
        public ActionResult Claimattendance()
        {
            //   var cdata = _db.ATTENDANCE_CLAIM.Where(x => x.EID == Convert.ToInt32(Session["Eid"]));
            decimal num;
            int seid=Convert.ToInt32(Session["Eid"]);
            var cdata = _db.ATTENDANCE_CLAIM.Where(x => x.EID == seid).ToList().OrderBy(x => x.CAID);
            foreach(var qwe in cdata)
            {
                num = qwe.CAID;
            }
            ViewBag.claimlists =cdata;
            return View();
        }

        [HttpPost]
        public ActionResult Claimattendance(ATTENDANCE_CLAIM ac)
        {
            Int32 maxcaid = Convert.ToInt32(_db.ATTENDANCE_CLAIM.Select(x => x.CAID).DefaultIfEmpty(0).Max());
            if (maxcaid <= 0)
            {
                maxcaid = 1;
            }
            else
            {
                maxcaid++;
            }

            if (ac.LOGIN_DATE != null && ac.LOGIN_TIME != null)
            {
                string lid = ac.LOGIN_DATE.ToString();
                string lit = ac.LOGIN_TIME.ToString();
                string[] litokens = lid.Split(' ');
                string lidat = litokens[0];
                string[] litokens1 = lit.Split(' ');
                string litim = litokens1[1] + " " + litokens1[2];
                string lidattim = lidat + " " + litim;
                ac.LOGIN_TIME = Convert.ToDateTime(lidattim);
            }
            else if ((ac.LOGIN_DATE != null && ac.LOGIN_TIME == null) || (ac.LOGIN_DATE == null && ac.LOGIN_TIME != null))
            {
                ViewBag.Message = "Fill all login parameter";
                return View();
            }

            if (ac.LOGOUT_DATE != null && ac.LOGOUT_TIME != null)
            {
                string lod = ac.LOGOUT_DATE.ToString();
                string lot = ac.LOGOUT_TIME.ToString();
                string[] lotokens = lod.Split(' ');
                string lodat = lotokens[0];
                string[] lotokens1 = lot.Split(' ');
                string lotim = lotokens1[1] + " " + lotokens1[2];
                string lodattim = lodat + " " + lotim;
                ac.LOGOUT_TIME = Convert.ToDateTime(lodattim);
            }
            else if ((ac.LOGOUT_DATE != null && ac.LOGOUT_TIME == null) || (ac.LOGOUT_DATE == null && ac.LOGOUT_TIME != null))
            {
                ViewBag.Message = "Fill all logout parameter";
                return View();
            }

            ac.CAID = maxcaid;
            //ac.EID = 9;
            ac.EID = Convert.ToInt32(Session["Eid"]);
            ac.STATUS = "Pending";
            _db.ATTENDANCE_CLAIM.Add(ac);
            _db.SaveChanges();
            return RedirectToAction("Claimattendance");
        }

        [HttpGet]
        public ActionResult claimrequest()
        {
            string email = Session["Emailid"].ToString();
            var crdata = _db.ATTENDANCE_CLAIM.ToList();
            //List<ClaimAttendanceViewmodel> suplist = new ClaimAttendanceViewmodel();
            List<ClaimAttendanceViewmodel> datalst = new List<ClaimAttendanceViewmodel>();
            // data.Add()
            foreach (var item in crdata)
            {
                var test = _db.SUPERVISORs.Where(x => x.EID == item.EID && (x.SUPERVISOR1 == email || x.SUPERVISOR2 == email || x.SUPERVISOR3 == email || x.SUPERVISOR4 == email || x.SUPERVISOR5 == email)).FirstOrDefault();
                var data = new ClaimAttendanceViewmodel();
                data.CAID = item.CAID;
                data.EID = item.EID;
                data.LOGIN_DATE = item.LOGIN_DATE;
                data.LOGIN_TIME = item.LOGIN_TIME;
                data.LOGOUT_DATE = item.LOGOUT_DATE;
                data.LOGOUT_TIME = item.LOGOUT_TIME;
                data.REASON = item.REASON;
                data.STATUS = item.STATUS;
                data.COMENT = item.COMENT;
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
            return View(datalst.OrderByDescending(x => x.CAID));
            //var crdata = _db.ATTENDANCE_CLAIM.ToList();
            //return View(crdata.OrderByDescending(x => x.CAID));
        }
        


        [HttpPost]
        public ActionResult claimapproved(int id)
        {
            //----------------------------login claim---------------------------
            var claimdata = _db.ATTENDANCE_CLAIM.Where(x => x.CAID == id).FirstOrDefault();
            int seid = Convert.ToInt32(claimdata.EID);
            if (claimdata.LOGIN_DATE != null && claimdata.LOGIN_TIME != null)
            {
                int maxaid = Convert.ToInt32(_db.ATTENDANCEs.Select(p => p.AID).DefaultIfEmpty(0).Max()); // reading maximum value        

                ATTENDANCE incheck = _db.ATTENDANCEs.Where(p => p.EID == seid && p.ATTEND_DATE == claimdata.LOGIN_DATE).FirstOrDefault();
                if (incheck == null)
                {
                    claimdata.STATUS = "Approved";
                    claimdata.COMENT = seid.ToString()+" " +claimdata.REASON;
                    if (maxaid <= 0)
                    {
                        maxaid = 1;
                    }
                    else
                    {
                        maxaid++;
                    }
                    ate.AID = maxaid;
                    ate.EID = seid;
                    ate.ATTEND_DATE = claimdata.LOGIN_DATE;
                    ate.LOGIN_TIME = claimdata.LOGIN_TIME;
                    string res = System.DateTime.Now.ToString();       //
                    res = res.Substring(res.Length - 11);              //
                    string lid = claimdata.LOGIN_DATE.ToString();                    
                    string[] litokens = lid.Split(' ');
                    string lidat = litokens[0];                    
                   // string litim = litokens1[1] + " " + litokens1[2];
                    //DateTime shifta = Convert.ToDateTime(lidat +" "+ "10:00:00 AM");

                    if (ate.LOGIN_TIME <= Convert.ToDateTime(lidat + " " + "10:00:00 AM"))
                    {
                        ate.SHIFT = "A";
                    }
                    else if (ate.LOGIN_TIME > Convert.ToDateTime(lidat + " " + "10:00:00 AM") && ate.LOGIN_TIME < Convert.ToDateTime(lidat + " " + "6:00:00 PM"))
                    {
                        ate.SHIFT = "B";
                    }
                    else if (ate.LOGIN_TIME >= Convert.ToDateTime(lidat + " " + "6:00:00 PM"))
                    {
                        ate.SHIFT = "C";

                        //for meal allowance
                        DateTime dt = Convert.ToDateTime(lidat);
                        string worhrs_monyr = dt.Date.ToString("MM/yyyy");
                        var ms = _db.MONTHLY_STATEMENT.Where(i => i.EID == seid && i.MONTH == worhrs_monyr).FirstOrDefault();
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
                            msi.EID = seid;
                            msi.MONTH = worhrs_monyr;
                            msi.TOTALMEALALLOW = 1;
                            _db.MONTHLY_STATEMENT.Add(msi);
                        }
                        else
                        {
                            if (ms.TOTALMEALALLOW == null)
                            {
                                ms.TOTALMEALALLOW = 0;
                            }
                            ms.TOTALMEALALLOW++;
                        }
                    }
                    _db.ATTENDANCEs.Add(ate);
                    _db.SaveChanges();
                }
                else
                {
                    claimdata.STATUS = "Declined";
                    _db.SaveChanges();
                }
                return RedirectToAction("claimrequest");
            }
            //-----------------------end of login claim---------------------------

            //------------------------start of logout, copied from Logout action-----------------------------


            if (claimdata.LOGOUT_DATE != null && claimdata.LOGOUT_TIME != null)
            {


                DateTime today = Convert.ToDateTime(claimdata.LOGOUT_DATE);
                DateTime yesterday = today.AddDays(-1);

                //--------------------------------------------------------------------------------

                //ATTENDANCE check = _db.ATTENDANCEs.Where(p => p.EID == seid && p.ATTEND_DATE == System.DateTime.Today && p.SHIFT != "C").FirstOrDefault();
                ATTENDANCE check = _db.ATTENDANCEs.Where(p => p.EID == seid && p.ATTEND_DATE == today).FirstOrDefault();
                if (check != null && check.LOGOUT_DATE == null && check.LOGOUT_TIME == null && check.ATTEND_DATE == today && check.LOGIN_TIME <= claimdata.LOGOUT_TIME)
                {

                    claimdata.STATUS = "Approved";
                    claimdata.COMENT = claimdata.REASON;
                    check.LOGOUT_TIME = claimdata.LOGOUT_TIME;
                    TimeSpan ttltim = Convert.ToDateTime(check.LOGOUT_TIME) - Convert.ToDateTime(check.LOGIN_TIME);
                    string strtim = ttltim.ToString();
                    check.TOTAL_TIME = Convert.ToDateTime(strtim);
                    check.LOGOUT_DATE = System.DateTime.Today;

                    //--------------------------------------------------
                    /*For monthly statment*/
                    DateTime dt = Convert.ToDateTime(check.TOTAL_TIME);
                    string worhrs_monyr = dt.Date.ToString("MM/yyyy");

                    double inhrs = ttltim.TotalHours;

                    var ms = _db.MONTHLY_STATEMENT.Where(i => i.EID == seid && i.MONTH == worhrs_monyr).FirstOrDefault();
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
                        msi.EID = seid;
                        msi.MONTH = worhrs_monyr;
                        msi.TOTALWORKINGHRS = System.Math.Round(Convert.ToDecimal(inhrs), 2);
                        _db.MONTHLY_STATEMENT.Add(msi);
                    }
                    else
                    {
                        ms.TOTALWORKINGHRS = ms.TOTALWORKINGHRS + Convert.ToDecimal(inhrs);
                    }
                    String dayofweek = Convert.ToDateTime(check.ATTEND_DATE).DayOfWeek.ToString().ToUpper();
                    // string dayofweek = System.DateTime.Now.DayOfWeek.ToString().ToUpper();
                    var holidaycheck = _db.HOLIDAY_LIST.Where(i => i.H_DATE == check.ATTEND_DATE).FirstOrDefault();
                    if (holidaycheck != null)
                    {
                        if (ms.TOTALWOSH == null)
                        {
                            ms.TOTALWOSH = 0;
                        }
                        ms.TOTALWOSH = ms.TOTALWOSH + Convert.ToDecimal(inhrs);
                    }
                    else if (dayofweek == "SUNDAY" || dayofweek == "SATURDAY")
                    {
                        ms.TOTALWOH = ms.TOTALWOH + Convert.ToDecimal(inhrs);
                    }
                    if (check.LOGOUT_TIME < Convert.ToDateTime("7:30 pm") && check.SHIFT == "C")
                    {
                        ms.TOTALMEALALLOW = ms.TOTALMEALALLOW - 1;
                    }
                    //--------------------------------------------------
                    _db.SaveChanges();
                    return RedirectToAction("Schedule", "Home");
                }
                else
                {
                    ATTENDANCE check1 = _db.ATTENDANCEs.Where(p => p.EID == seid && p.ATTEND_DATE == yesterday && p.SHIFT == "C").FirstOrDefault();

                    if (check1 != null && check1.LOGOUT_TIME == null && check1.LOGOUT_DATE == null)
                    {

                        claimdata.STATUS = "Approved";
                        claimdata.COMENT = claimdata.REASON;
                        check1.LOGOUT_DATE = claimdata.LOGOUT_DATE;
                        check1.LOGOUT_TIME = claimdata.LOGOUT_TIME;
                        TimeSpan ttltim = Convert.ToDateTime(check1.LOGOUT_TIME) - Convert.ToDateTime(check1.LOGIN_TIME);
                        string strtim = ttltim.ToString();
                        check1.TOTAL_TIME = Convert.ToDateTime(strtim);

                        //For monthly statment

                        DateTime dt = Convert.ToDateTime(check1.TOTAL_TIME);
                        string worhrs_monyr = dt.Date.ToString("MM/yyyy");

                        double inhrs = ttltim.TotalHours;

                        var ms = _db.MONTHLY_STATEMENT.Where(i => i.EID == seid && i.MONTH == worhrs_monyr).FirstOrDefault();
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
                            msi.EID = seid;
                            msi.MONTH = worhrs_monyr;
                            msi.TOTALWORKINGHRS = System.Math.Round(Convert.ToDecimal(inhrs), 2);
                            msi.TOTALNIGHTSHIFTS = System.Math.Round(Convert.ToDecimal(inhrs), 2);
                            _db.MONTHLY_STATEMENT.Add(msi);
                        }
                        else
                        {
                            ms.TOTALWORKINGHRS = System.Math.Round(Convert.ToDecimal(inhrs), 2);
                            String dayofweek = Convert.ToDateTime(check.ATTEND_DATE).DayOfWeek.ToString().ToUpper();
                            // string dayofweek = System.DateTime.Now.DayOfWeek.ToString().ToUpper();
                            var holidaycheck = _db.HOLIDAY_LIST.Where(i => i.H_DATE == check.ATTEND_DATE).FirstOrDefault();
                            if (holidaycheck != null)
                            {
                                if (ms.TOTALWOSH == null)
                                {
                                    ms.TOTALWOSH = 0;
                                }
                                ms.TOTALWOSH = ms.TOTALWOSH + Convert.ToDecimal(inhrs);
                            }
                            else if (dayofweek == "SUNDAY" || dayofweek == "SATURDAY")
                            {
                                ms.TOTALWOH = ms.TOTALWOH + Convert.ToDecimal(inhrs);
                            }
                            else
                            {
                                ms.TOTALNIGHTSHIFTS = ms.TOTALNIGHTSHIFTS + Convert.ToDecimal(inhrs);
                            }
                        }
                        _db.SaveChanges();
                    }
                    else
                    {

                        claimdata.STATUS = "Declined";
                        ViewBag.Message = "You have already logout";
                    }
                }
                

            }
            return RedirectToAction("claimrequest");            

         }
        [HttpPost]
        public ActionResult claimdeclined(int id)
        {
            ATTENDANCE_CLAIM acd = _db.ATTENDANCE_CLAIM.Where(x => x.CAID == id).FirstOrDefault();
            acd.STATUS = "Declined";
            _db.SaveChanges();
            return RedirectToAction("claimrequest");
        }
    }
}