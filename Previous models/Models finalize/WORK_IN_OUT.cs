
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
    
public partial class WORK_IN_OUT
{

    public decimal IN_OUT_ID { get; set; }
   
    [Display(Name = "Employee Id")]
    public Nullable<decimal> EID { get; set; }
     
     [Display(Name = "Out on Work")]
    public Nullable<System.DateTime> OUT_ON_WORK { get; set; }
    [Display(Name = "Return Inside")]
    public Nullable<System.DateTime> RETURN_INSIDE { get; set; }
    [Display(Name = "Reason")]
    [Required(ErrorMessage="*")]
    public string REASON { get; set; }



    public virtual EMPLOYEE EMPLOYEE { get; set; }

}

}
