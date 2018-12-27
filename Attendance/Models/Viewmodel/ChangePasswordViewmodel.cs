using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
//using System.Web;


//Required and compare is not working so compare the funchtion is done in the AccountController  ChangePassword action
//Required is done in changepassword.cshtml
namespace Attendance.Models.Viewmodel
{
    public class ChangePasswordViewmodel
    {
        [Required(ErrorMessage="*")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "*")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Password Mismatch")]
        public string ConfirmNew { get; set; }
    }
}