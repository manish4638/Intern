using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models.Viewmodel
{
    public class leaveviewmodel
    {
        public decimal LID { get; set; }

        public string flag { get; set; }

        public Nullable<decimal> EID { get; set; }
        [Display(Name = "Type")]
        public string LEAVE_TYPE { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "From Date")]
        public Nullable<System.DateTime> FROM_DATE { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "To Date")]
        public Nullable<System.DateTime> TO_DATE { get; set; }
        [Display(Name = "Days")]
        public Nullable<decimal> DAYS { get; set; }

        public string REASON { get; set; }

        public string STATUS { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Request From")]
        public Nullable<System.DateTime> REQUESTED_FROM { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Request To")]
        public Nullable<System.DateTime> REQUESTED_TO { get; set; }

        public string COMENT { get; set; }

    }
}