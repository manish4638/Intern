using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models.Viewmodel
{
    public class CreateEmployee
    {
         [Required]
        public int EID { get; set; }
        [Required]
        public String FULL_NAME { get; set; }
        [Required]
        public String ADDRESS { get; set; }
        [Required]
        public int CONTACT { get; set; }
        [Required]
        public Char GENDER { get; set; }
        [Required]
        public String EMAIL { get; set; }
        [Required]
        public String PASSCODE { get; set; }
        [Required]
        public String ROLENAME { get; set; }
        [Required]
        public String POST { get; set; }

    }
}