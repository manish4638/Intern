
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
    
public partial class EMPLOYEE
{

    public EMPLOYEE()
    {

        this.ATTENDANCEs = new HashSet<ATTENDANCE>();

        this.MONTHLY_STATEMENT = new HashSet<MONTHLY_STATEMENT>();

        this.EMPLOYEE_POST = new HashSet<EMPLOYEE_POST>();

        this.LEAVEs = new HashSet<LEAVE>();

        this.WORK_IN_OUT = new HashSet<WORK_IN_OUT>();

        this.PAYOUTs = new HashSet<PAYOUT>();

        this.USERROLES = new HashSet<USERROLE>();

    }


    public decimal EID { get; set; }
    [Required]
    public string FULL_NAME { get; set; }

    public string ADDRESS { get; set; }

    public string GENDER { get; set; }

    //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        //ErrorMessage = "Please enter correct email address")]
    public string EMAIL { get; set; }

    public string PASSCODE { get; set; }

    //[RegularExpression(@"^\+?\d{0,3}\-?\d{4,5}\-?\d{4,5}", ErrorMessage = "Enter the valid contact number")]
    public string CONTACT { get; set; }



    public virtual ICollection<ATTENDANCE> ATTENDANCEs { get; set; }

    public virtual ICollection<MONTHLY_STATEMENT> MONTHLY_STATEMENT { get; set; }

    public virtual ICollection<EMPLOYEE_POST> EMPLOYEE_POST { get; set; }

    public virtual ICollection<LEAVE> LEAVEs { get; set; }

    public virtual ICollection<WORK_IN_OUT> WORK_IN_OUT { get; set; }

    public virtual ICollection<PAYOUT> PAYOUTs { get; set; }

    public virtual ICollection<USERROLE> USERROLES { get; set; }

}

}
