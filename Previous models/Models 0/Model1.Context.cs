﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class OracledbEntities : DbContext
{
    public OracledbEntities()
        : base("name=OracledbEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public DbSet<ALLOWANCE> ALLOWANCEs { get; set; }

    public DbSet<ATTENDANCE> ATTENDANCEs { get; set; }

    public DbSet<ATTENDANCE_CLAIM> ATTENDANCE_CLAIM { get; set; }

    public DbSet<EMPLOYEE> EMPLOYEEs { get; set; }

    public DbSet<EMPLOYEE_POST> EMPLOYEE_POST { get; set; }

    public DbSet<HOLIDAY_LIST> HOLIDAY_LIST { get; set; }

    public DbSet<LEAVE> LEAVEs { get; set; }

    public DbSet<MONTHLY_STATEMENT> MONTHLY_STATEMENT { get; set; }

    public DbSet<PAYOUT> PAYOUTs { get; set; }

    public DbSet<POST_LIST> POST_LIST { get; set; }

    public DbSet<ROLE> ROLES { get; set; }

    public DbSet<USERROLE> USERROLES { get; set; }

    public DbSet<WORK_IN_OUT> WORK_IN_OUT { get; set; }

}

}

