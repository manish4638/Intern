using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models.Viewmodel
{
    public class ManageEmployeeViewModel
    {
        [Required(ErrorMessage = "*")]
        public int EID { get; set; }
        //[Required(ErrorMessage="Enter the Full Name")]
        [Required(ErrorMessage = "*")]
        public String FULL_NAME { get; set; }
       [Required(ErrorMessage = "*")]
        public String ADDRESS { get; set; }
       [Required(ErrorMessage = "*")]
       [RegularExpression(@"^\+?\d{0,3}\-?\d{4,5}\-?\d{4,5}", ErrorMessage = "Enter the valid contact number")]
        public String CONTACT { get; set; }
       [Required(ErrorMessage = "*")]
        public String GENDER { get; set; }
        [Required(ErrorMessage = "*")]  
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        //ErrorMessage = "Please enter correct email address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage="Enter valid Email")]
        public String EMAIL { get; set; }
       [Required(ErrorMessage = "*")]
        public String PASSCODE { get; set; }
       [Required(ErrorMessage = "*")]
        public String ROLENAME { get; set; }
       [Required(ErrorMessage = "*")]
        public String POST { get; set; }

        public object ProductName { get; set; }
    }
}