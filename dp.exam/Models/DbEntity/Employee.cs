using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dp.exam.Models.DbEntity
{
    public class Employee: AuditableEntity
    {
        [Required(ErrorMessage = "Enter the Code")]
        [MaxLength(3), MinLength(3)]
        public String Code { get; set; }

        [Required(ErrorMessage = "Enter the Initials")]
        public String Initials { get; set; }

        [Required(ErrorMessage = "Enter the FristName")]
        [MaxLength(50)]
        public String FristName { get; set; }

        [Required(ErrorMessage = "Enter the Surname")]
        [MaxLength(50)]
        public String Surname { get; set; }

        [Required(ErrorMessage = "Enter the Address1")]
        [MaxLength(100)]
        public String Address1 { get; set; }

        [Required(ErrorMessage = "Enter the Address2")]
        [MaxLength(100)]
        public String Address2 { get; set; }

        [Required(ErrorMessage = "Enter the DateOFBirth")]
        public DateTime DateOFBirth { get; set; }

        [Required(ErrorMessage = "Enter the Status")] 
        public bool Status { get; set; }

        public ICollection<EmployeeFamily> EmployeeFamilies { get; set; }
    }
}
