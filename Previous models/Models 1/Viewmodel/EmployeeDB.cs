using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance.Models.Viewmodel
{    
        public class EmployeeDB
        {
            OracledbEntities _db = new OracledbEntities();
            public List<ManageEmployeeViewModel> ListAll()
            {
                List<ManageEmployeeViewModel> lstemp = new List<ManageEmployeeViewModel>();
                var emps = _db.EMPLOYEEs.ToList();
                foreach (var item in emps)
                {
                    lstemp.Add(new ManageEmployeeViewModel() { EID = Convert.ToInt32(item.EID), FULL_NAME = item.FULL_NAME, CONTACT = item.CONTACT, ADDRESS = item.ADDRESS, EMAIL = item.EMAIL, GENDER = item.GENDER });
                }
                return lstemp;
            }
        }
    
}