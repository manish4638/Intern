
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Attendance.Models
{

using System;
    using System.Collections.Generic;
    
public partial class PAYOUT
{

    public decimal PID { get; set; }

    public Nullable<decimal> EID { get; set; }

    public string PAY_MONTH { get; set; }

    public Nullable<decimal> WOH_DAY { get; set; }

    public Nullable<decimal> NIGHT { get; set; }

    public Nullable<decimal> TOTAL_SALARY { get; set; }

    public Nullable<decimal> LEAVE_DAYS { get; set; }

    public Nullable<decimal> WORKING_HOUR { get; set; }



    public virtual EMPLOYEE EMPLOYEE { get; set; }

}

}
