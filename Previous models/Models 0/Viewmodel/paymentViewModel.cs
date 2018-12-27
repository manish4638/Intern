using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance.Models.Viewmodel
{
    public class paymentViewModel
    {
        public decimal PID { get; set; }

        public Nullable<decimal> EID { get; set; }

        public string PAY_MONTH { get; set; }
        public string POST { get; set; }

        public Nullable<decimal> WOH_DAY { get; set; }

        public Nullable<decimal> NIGHT { get; set; }

        public Nullable<decimal> TOTAL_SALARY { get; set; }

        public Nullable<decimal> LEAVE_DAYS { get; set; }

        public Nullable<decimal> WORKING_HOUR { get; set; }
        public int SelectedMonth
        {
            get;
            set;
        }
        public int SelectedYear
        {
            get;
            set;
        }
    }
}