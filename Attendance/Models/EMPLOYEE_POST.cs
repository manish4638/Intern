
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
    
public partial class EMPLOYEE_POST
{

    [Display(Name = "Employee Post ID")]
    public decimal EPOID { get; set; }

    [Display(Name = "Employee ID")]
    public Nullable<decimal> EID { get; set; }

    [Display(Name = "Employee Post")]
    public string POST { get; set; }



    public virtual EMPLOYEE EMPLOYEE { get; set; }

}

}
