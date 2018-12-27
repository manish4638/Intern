using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models.Viewmodel
{
    public class Loginviewmodel
    {
        //[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = " ")]
        [Required(ErrorMessage = "*")]        
        public String Email { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        public bool Rememberme { get; set; }

    }
}