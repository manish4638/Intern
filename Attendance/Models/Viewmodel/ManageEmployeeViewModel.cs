using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attendance.Models.Viewmodel
{
    public class ManageEmployeeViewModel
    {
        public Nullable<decimal> EID1{ get; set; }
        [Required(ErrorMessage = "*")]
        public int EID { get; set; }
        //[Required(ErrorMessage="Enter the Full Name")]
        [Required(ErrorMessage = "*")]
        [Display(Name = "Full Name")]
        public String FULL_NAME { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Address")]
        public String ADDRESS { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Contact Number")]
       [RegularExpression(@"^\+?\d{0,3}\-?\d{4,5}\-?\d{4,5}", ErrorMessage = " ")]
        public String CONTACT { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Gender")]
        public String GENDER { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Email Address")]        
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage=" ")]
        public String EMAIL { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public String PASSCODE { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Role")]
        public String ROLENAME { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Post")]
        public String POST { get; set; }
         [Required(ErrorMessage = "*")]
         [Display(Name = "Supervisor 1")]
        public string SUPERVISOR1 { get; set; }
        [Display(Name = "Supervisor 2")]
        public string SUPERVISOR2 { get; set; }
        [Display(Name = "Supervisor 3")]
        public string SUPERVISOR3 { get; set; }
        [Display(Name = "Supervisor 4")]
        public string SUPERVISOR4 { get; set; }
        [Display(Name = "Supervisor 5")]
        public string SUPERVISOR5 { get; set; }


       // public object ProductName { get; set; }
    }
}