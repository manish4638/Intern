
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
    
public partial class REPORTTOSUPERVISOR
{

    public decimal RTSID { get; set; }
    [Required(ErrorMessage = "*")]
    public string SUPERVISOR { get; set; }
    [Required(ErrorMessage = "*")]
    public string MESSAGE { get; set; }

    public string EMAIL { get; set; }

}

}
