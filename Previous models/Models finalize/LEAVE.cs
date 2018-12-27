
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
    
public partial class LEAVE
{
    
    [Display(Name = "Leave Id")]
    public decimal LID { get; set; }
    
    [Display(Name = "Employee Id")]
    public Nullable<decimal> EID { get; set; }
    [Required(ErrorMessage = "*")]
    [Display(Name = "Leave Type")]
    public string LEAVE_TYPE { get; set; }
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    [Required(ErrorMessage = "*")]
    [Display(Name = "From Date")]
    public Nullable<System.DateTime> FROM_DATE { get; set; }
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    [Required(ErrorMessage = "*")]
    [Display(Name = "To Date")]
    public Nullable<System.DateTime> TO_DATE { get; set; }
    
    [Display(Name = "Days")]
    public Nullable<decimal> DAYS { get; set; }

    public string REASON { get; set; }

    public string STATUS { get; set; }



    public virtual EMPLOYEE EMPLOYEE { get; set; }

}

}