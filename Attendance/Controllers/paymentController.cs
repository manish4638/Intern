using Attendance.Models;
using Attendance.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Data;
using System.Text;
using System.Web.UI;

namespace Attendance.Controllers
{
    [Authorize]
    public class paymentController : Controller
    {
        OracledbEntities _db = new OracledbEntities();
        //
        // GET: /payment/
        [HttpGet] //for user
        public ActionResult userpayoutslip()
        {
            Int32 seid = Convert.ToInt32(Session["Eid"]);
            var pay = _db.PAYOUTs.Where(p => p.EID == seid);
            return View(pay.OrderBy(p => p.PAY_MONTH));
        }
        [HttpGet]//for user
        public ActionResult userstatement()
        {
            Int32 seid = Convert.ToInt32(Session["Eid"]);
            var mstat = _db.MONTHLY_STATEMENT.Where(p => p.EID == seid);
            return View(mstat.OrderBy(p => p.MONTH));
        }
        [HttpGet]//for Admin
        public ActionResult allmonstatement()
        {
            var amstat = _db.MONTHLY_STATEMENT.ToList();
            return View(amstat.OrderBy(p => p.MONTH));
        }

         [HttpGet]//for admin
        public ActionResult paymentslip()
        {
            ViewBag.Months = new SelectList(Enumerable.Range(1, 12).Select(x => new SelectListItem()
            {
                Text = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[x - 1] + " (" + x + ")",
                Value = x.ToString()
            }), "Value", "Text");
            ViewBag.Years = new SelectList(Enumerable.Range(2010, DateTime.Today.Year - 2010 + 1).Select(x => new SelectListItem()
            {
                Text = x.ToString(),
                Value = x.ToString()
            }), "Value", "Text");

            //Int32 seid = Convert.ToInt32(Session["Eid"]);
            //string monyy = Session["monyy"].ToString();
           // var user = _db.PAYOUTs.Where(p => p.PAY_MONTH == monyy).ToList();
            return View();
        }

        [HttpGet]
        public ActionResult monthlystatementgenerate()
         {
             var paydata = _db.PAYOUTs.ToList();
             return View(paydata.OrderBy(p => p.PAY_MONTH));
         }


        [HttpPost]
        public ActionResult monthlystatementgenerate(Monthselectionviewmodel monselect)
        {
            string monyy = monselect.SelectedMonth + "/" + monselect.SelectedYear;
            Session.Add("monyy", monyy);
            var check=_db.PAYOUTs.Where(i=>i.PAY_MONTH==monyy).FirstOrDefault();
            if(check!=null)
            {
                var paylist = _db.PAYOUTs.Where(i => i.PAY_MONTH == monyy).ToList();
                return View(paylist);
            }
            else
            {
                var mstmt=_db.MONTHLY_STATEMENT.Where(i=>i.MONTH==monyy).ToList();
                foreach (var item in mstmt)
                {
                    int maxpayid =  Convert.ToInt32(_db.PAYOUTs.Select(p => p.PID).DefaultIfEmpty(0).Max()); // reading maximum value           

                    if(maxpayid <=0)
                    {
                        maxpayid = 1;
                    }
                    else
                    {
                        maxpayid++;
                    }
                    var empl = new PAYOUT
                    {             
                        PID=maxpayid,
                        EID=item.EID,                
                        PAY_MONTH = item.MONTH,                
                        WOH_DAY = item.TOTALWOH,
                        WOSH_DAY=item.TOTALWOSH,
                        NIGHT = item.TOTALNIGHTSHIFTS,                              
                        LEAVE_DAYS = item.TOTALLEAVEDAYS,
                        WORKING_HOUR = item.TOTALWORKINGHRS      
                 
                    };
                    var allpos=_db.EMPLOYEE_POST.Where(i=>i.EID==empl.EID).FirstOrDefault();
                    var allowancei=_db.ALLOWANCEs.Where(i=>i.POST==allpos.POST).FirstOrDefault();
                    var basicsal=_db.POST_LIST.Where(i=>i.POST==allpos.POST).FirstOrDefault();
                    if(empl.LEAVE_DAYS==null)
                    {
                        empl.LEAVE_DAYS = 0;
                    }
                    if (empl.NIGHT == null)
                    {
                        empl.NIGHT = 0;
                    }
                    if (empl.WOH_DAY == null)
                    {
                        empl.WOH_DAY = 0;
                    }
                    if (empl.WORKING_HOUR == null)
                    {
                        empl.WORKING_HOUR = 0;
                    }
                    if (empl.WOSH_DAY == null)
                    {
                        empl.WOSH_DAY = 0;
                    }
                    if (empl.MEALALLOWANCE == null)
                    {
                        empl.MEALALLOWANCE = 0;
                    }
                    empl.TOTAL_SALARY =(empl.MEALALLOWANCE*allowancei.MEAL_ALLOWANCE)+(empl.WOSH_DAY * allowancei.WOSH) + (empl.WOH_DAY * allowancei.WOH) + (empl.NIGHT * allowancei.WONS) + ((empl.WORKING_HOUR - empl.WOSH_DAY-empl.WOH_DAY - empl.NIGHT) * basicsal.BASIC_SALARY);
                    _db.PAYOUTs.Add(empl);                    
                }
                _db.SaveChanges();
                var paylist = _db.PAYOUTs.Where(i => i.PAY_MONTH == monyy).ToList();
                return View(paylist);
            }           
        }
        //-- testing to send the pdf-----------------------------------------------------------
        
        public ActionResult payrollmail()
        {
            int pid = 1;
            if (pid>0)
            {
                DataTable dt = new DataTable();
                var paydata = _db.PAYOUTs.Where(x => x.PID == pid).FirstOrDefault();   
                //var mstmt=_db.MONTHLY_STATEMENT.Where(x=>x.MONTH==paydata.PAY_MONTH && x.EID==paydata.EID).FirstOrDefault();
                var postlsit=_db.EMPLOYEE_POST.Where(x=>x.EID==paydata.EID).FirstOrDefault();
                var basicssal=_db.POST_LIST.Where(x=>x.POST==postlsit.POST).FirstOrDefault();
                var allowanc = _db.ALLOWANCEs.Where(x => x.POST == postlsit.POST).FirstOrDefault();              
                dt.Columns.AddRange(new DataColumn[4] {
                    new DataColumn("Working Type"),
                    new DataColumn("Working Hour"),
                    new DataColumn("Amount per hour "),
                    new DataColumn("Amount")});
                decimal weekhr = Convert.ToInt32(paydata.WORKING_HOUR - (paydata.WOH_DAY + paydata.NIGHT+paydata.MEALALLOWANCE+paydata.WOSH_DAY));

                dt.Rows.Add("Basic Payment", weekhr, basicssal.BASIC_SALARY, weekhr * basicssal.BASIC_SALARY);
                dt.Rows.Add("Holiday", paydata.WOH_DAY, allowanc.WOH, paydata.WOH_DAY * allowanc.WOH);
                dt.Rows.Add("Special Holiday", paydata.WOSH_DAY, allowanc.WOSH, paydata.WOSH_DAY * allowanc.WOSH);
                dt.Rows.Add("Meal Allowance", paydata.MEALALLOWANCE, allowanc.MEAL_ALLOWANCE, paydata.MEALALLOWANCE * allowanc.MEAL_ALLOWANCE);
                dt.Rows.Add("Night Shift", paydata.NIGHT, allowanc.WONS, paydata.NIGHT * allowanc.WONS);
                dt.Rows.Add("Total", paydata.WORKING_HOUR, "", paydata.TOTAL_SALARY);
                dt.Rows.Add("", "", "uppertotal", weekhr * basicssal.BASIC_SALARY + paydata.WOH_DAY * allowanc.WOH + paydata.NIGHT * allowanc.WONS + paydata.WOSH_DAY * allowanc.WOSH + paydata.MEALALLOWANCE * allowanc.MEAL_ALLOWANCE);
                ExportToPDF(dt, Convert.ToInt32(paydata.EID));                
            }
            return RedirectToAction("Login", "Account");
        }

        private void ExportToPDF(DataTable dt, int id)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    var empdetail = _db.EMPLOYEEs.Where(x => x.EID == id).FirstOrDefault();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<div align='center'> NepaSoft</div>");

                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Order Sheet</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>EID :</b>"+id +"</td><td><b>Date: </b>" + DateTime.Now + " </td></tr>");
                    sb.Append("<tr><td><b>From :</b> " + "Company Name" + " </td><td><b>To: </b>" + empdetail.FULL_NAME + " </td></tr>");
                    sb.Append("</table>");

                    sb.Append("<table border = '1'>");
                    sb.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<th>");
                        sb.Append(column.ColumnName);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        
                        sb.Append("<tr>");
                        
                        foreach (DataColumn column in dt.Columns)
                        {                                                   
                            sb.Append("<td>");                             
                            sb.Append(row[column]);                            
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");

                    StringReader sr = new StringReader(sb.ToString());

                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();
                      //  MailMessage mm = new MailMessage("manish.shrestha3539@gmail.com", "manish.9818544129@gmail.com");
                        MailMessage mm = new MailMessage("manish.shrestha3539@gmail.com", empdetail.EMAIL);
                        mm.Subject = "GridView Exported PDF";
                        mm.Body = "GridView Exported PDF Attachment";
                        mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "GridViewPDF.pdf"));
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                        NetworkCred.UserName = "manish.shrestha3539@gmail.com";
                        NetworkCred.Password = "Nabins46";//Enter the password
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                    }
                }
            }
        }
    }
}