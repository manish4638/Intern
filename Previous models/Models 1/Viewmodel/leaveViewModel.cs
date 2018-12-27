using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models.Viewmodel
{
    public class leaveViewModel
    {
        //public List<LEAVE> leavelist { get; set; }
        //public List<LEAVESTATU> leavestatuslist { get; set; }


      

        public decimal LID { get; set; }
        public Nullable<decimal> EID { get; set; }
        public string STATUS { get; set; }

        [Required(ErrorMessage = "*")]
        public string LEAVE_TYPE { get; set; }
        [DataType(DataType.Date), Required(ErrorMessage = "*")]
        public Nullable<System.DateTime> FROM_DATE { get; set; }
         [DataType(DataType.Date), Required(ErrorMessage = "*")]
        public Nullable<System.DateTime> TO_DATE { get; set; }
        public decimal DAYS { get; set; }
        [Required(ErrorMessage = "*")]
        public string REASON { get; set; }
        
        
    }
}







