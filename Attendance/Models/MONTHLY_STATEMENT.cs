
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
    using System.ComponentModel.DataAnnotations;
    
public partial class MONTHLY_STATEMENT
{
    [Display(Name = "Monthly Record Id")]
    public decimal MON_REC_ID { get; set; }
    [Display(Name = "Employee Id")]
    public Nullable<decimal> EID { get; set; }
     [Display(Name = "Month")]
    public string MONTH { get; set; }
    [Display(Name = "Total Leave Days")]
    public Nullable<decimal> TOTALLEAVEDAYS { get; set; }
    [Display(Name = "Total Woring Hour")]
    public Nullable<decimal> TOTALWORKINGHRS { get; set; }
    [Display(Name = "Total Night Shift Hour")]
    public Nullable<decimal> TOTALNIGHTSHIFTS { get; set; }
    [Display(Name = "Total Work on Weekend")]
    public Nullable<decimal> TOTALWOH { get; set; }
    [Display(Name = "Total Work on Holiday")]
    public Nullable<decimal> TOTALWOSH { get; set; }
    [Display(Name = "Number of Meal Allowance")]
    public Nullable<decimal> TOTALMEALALLOW { get; set; }



    public virtual EMPLOYEE EMPLOYEE { get; set; }

}

}
