
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
    
public partial class ATTENDANCE_CLAIM
{
    
   
    
    public decimal CAID { get; set; }

    public Nullable<decimal> EID { get; set; }
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public Nullable<System.DateTime> LOGIN_DATE { get; set; }
    [DataType(DataType.Time)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
    public Nullable<System.DateTime> LOGIN_TIME { get; set; }
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public Nullable<System.DateTime> LOGOUT_DATE { get; set; }
    [DataType(DataType.Time)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
    public Nullable<System.DateTime> LOGOUT_TIME { get; set; }

    public string REASON { get; set; }

    public string STATUS { get; set; }
      

    public virtual EMPLOYEE EMPLOYEE { get; set; }

}

}
