
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
    
public partial class USERROLE
{

    public decimal USERROLESID { get; set; }

    public Nullable<decimal> ROLEID { get; set; }

    public Nullable<decimal> EID { get; set; }



    public virtual EMPLOYEE EMPLOYEE { get; set; }

    public virtual ROLE ROLE { get; set; }

}

}