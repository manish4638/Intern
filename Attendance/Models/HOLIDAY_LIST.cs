
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
    
public partial class HOLIDAY_LIST
{

    [Display(Name = "Holiday ID")]
    public decimal HID { get; set; }
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    [Required(ErrorMessage = "*")]
    [Display(Name = "Holiday Date")]

    public Nullable<System.DateTime> H_DATE { get; set; }
    [Required(ErrorMessage = "*")]
    [Display(Name = "Occation")]
    public string OCCATION { get; set; }

}

}