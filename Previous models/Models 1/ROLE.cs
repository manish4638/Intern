
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
    
public partial class ROLE
{

    public ROLE()
    {

        this.USERROLES = new HashSet<USERROLE>();

    }


    public decimal ROLEID { get; set; }

    public string ROLENAME { get; set; }



    public virtual ICollection<USERROLE> USERROLES { get; set; }

}

}