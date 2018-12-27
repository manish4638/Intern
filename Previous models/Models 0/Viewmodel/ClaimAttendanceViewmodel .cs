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

        public Nullable<decimal> EID { get; set; }
        public string NAME { get; set; }
        public Nullable<System.DateTime> LOGIN_DATE { get; set; }

        public Nullable<System.DateTime> LOGIN_TIME { get; set; }

        public Nullable<System.DateTime> LOGOUT_DATE { get; set; }

        public Nullable<System.DateTime> LOGOUT_TIME { get; set; }

        public string REASON { get; set; }

        public string STATUS { get; set; }

        public List<ClaimAttendanceViewmodel> claimlist { get; set; }
    }
}







