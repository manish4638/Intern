using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models.Viewmodel
{
    public class leavedaysViewmodel
    {
        public decimal LDID { get; set; }

        public Nullable<decimal> EID { get; set; }
        [Display(Name = "Type of leave")]
        public string LEAVETYPE { get; set; }

        public Nullable<decimal> DAYS { get; set; }

        [Display(Name = "Maximum leave Days")]
        public Nullable<decimal> DAYS_OFF { get; set; }
    }
}