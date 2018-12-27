using Attendance.Models;
using Attendance.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Attendance.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        
        OracledbEntities _db = new OracledbEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(Loginviewmodel l)
        {
            var users = _db.EMPLOYEEs.Where(a => a.EMAIL == l.Email && a.PASSCODE == l.Password).FirstOrDefault();
            if (users != null)
            {
                Session.Add("Emailid", users.EMAIL);
                Session.Add("Eid", users.EID);
                Session.Add("Fullname", users.FULL_NAME);
                FormsAuthentication.SetAuthCookie(l.Email, l.Rememberme);
                return RedirectToAction("Schedule", "Home", new { msg = "" });
            }
            else
            {
                ModelState.AddModelError("", "Invalid Email or Password");
            }

            return View();
        }

        [Authorize]

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewmodel ch)
        {
            int Eid = Convert.ToInt32(Session["Eid"].ToString());
            EMPLOYEE es = _db.EMPLOYEEs.Where(e => e.EID == Eid && e.PASSCODE == ch.CurrentPassword).FirstOrDefault();
            if (es != null)
            {
                if (ch.NewPassword == ch.ConfirmNew)
                {
                    es.PASSCODE = ch.ConfirmNew;
                    _db.SaveChanges();
                    ViewBag.Message = "Password change successfully";
                }
                else
                {
                    ViewBag.Message = "Password Mismatch";
                }

            }
            else
            {
                ViewBag.Message = "Wrong Password";
            }
            ModelState.Clear();
            return View();
        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(EMPLOYEE emp)
        {
            EMPLOYEE e = _db.EMPLOYEEs.Where(p => p.EMAIL == emp.EMAIL).FirstOrDefault();
            if (ModelState.IsValid)
            {
                //https://www.google.com/settings/security/lesssecureapps
                //Make Access for less secure apps=true    
                //ADJUST THE SETTING IN YOUR GMAIL AND USE THE YOUR eMAIL AND PASSWORD
                String from ="manish.shrestha3539@gmail.com";
                String password = "Nabins46";
                using (MailMessage mail = new MailMessage(from,emp.EMAIL))
                {
                    try
                    {
                        EMPLOYEE tb = _db.EMPLOYEEs.Where(u => u.EMAIL == emp.EMAIL).FirstOrDefault();
                        if (tb != null)
                        {
                            mail.Subject = "Password Recovery";
                            mail.Body = "Your Password is:" + tb.PASSCODE;
                            mail.IsBodyHtml = false;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.EnableSsl = true;
                            NetworkCredential networkCredential = new NetworkCredential(from,  password);
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = networkCredential;
                            smtp.Port = 587;
                            smtp.Send(mail);
                            ViewBag.Message = "Your Password Is Sent to your email";
                        }
                        else
                        {
                            ViewBag.Message = "Email Doesnot Exist in Database";
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        
                    }
                   
                }

            }
            ModelState.Clear();
            return View();      
            
        }


        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}