using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models.Viewmodel
{
    public class ClaimAttendanceViewmodel
    {
        public decimal CAID { get; set; }

        public string flag { get; set; }

        public Nullable<decimal> EID { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Login Date")]
        public Nullable<System.DateTime> LOGIN_DATE { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Login Time")]
        public Nullable<System.DateTime> LOGIN_TIME { get; set; }
        [Display(Name = "Logout Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> LOGOUT_DATE { get; set; }
        [Display(Name = "Logout Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        public Nullable<System.DateTime> LOGOUT_TIME { get; set; }

        public string REASON { get; set; }

        public string STATUS { get; set; }

        public string COMENT { get; set; }

        public List<ClaimAttendanceViewmodel> claimlist { get; set; }
    }
}







