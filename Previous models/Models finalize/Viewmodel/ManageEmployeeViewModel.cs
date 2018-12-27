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

        public object ProductName { get; set; }
    }
}