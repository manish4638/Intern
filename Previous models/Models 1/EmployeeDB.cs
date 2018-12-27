using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Attendance.Models.Viewmodel;

namespace Attendance.Models
{
    public class EmployeeDB
    {
        OracledbEntities _db = new OracledbEntities();


        public List<ManageEmployeeViewModel> ListAll()
        {
            List<ManageEmployeeViewModel> lstemp = new List<ManageEmployeeViewModel>();
            var emps = _db.EMPLOYEEs.ToList();
            //var emps1 = _db.EMPLOYEE_POST.ToList();
            foreach (var item in emps)
            {
                lstemp.Add(new ManageEmployeeViewModel() { EID = Convert.ToInt32(item.EID), FULL_NAME = item.FULL_NAME, CONTACT = item.CONTACT, EMAIL = item.EMAIL, GENDER = item.GENDER });
            }
            return lstemp;
        }
    }
}