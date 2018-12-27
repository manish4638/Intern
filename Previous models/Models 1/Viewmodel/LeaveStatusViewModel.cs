using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models.Viewmodel
{
    public class LeaveStatusViewModel
    {
        public List<LEAVE> leavelist { get; set; }
        public List<LEAVESTATU> leavestatuslist { get; set; }
        
        /*
        public decimal LSID { get; set; }
        public decimal LID { get; set; }
        public Nullable<decimal> EID { get; set; }
        public string STATUS { get; set; }
        public string LEAVE_TYPE { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FROM_DATE { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> TO_DATE { get; set; }
        public Nullable<decimal> DAYS { get; set; }
        public string REASON { get; set; }*/
    }
}