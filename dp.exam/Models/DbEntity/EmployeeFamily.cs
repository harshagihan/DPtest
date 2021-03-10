using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dp.exam.Models.DbEntity
{
    public class EmployeeFamily: AuditableEntity
    {
        [Required(ErrorMessage = "Enter the FristName")]
        [MaxLength(50)]
        public String FristName { get; set; }
        [Required(ErrorMessage = "Enter the Surname")]
        [MaxLength(50)]
        public String Surname { get; set;}
        [Required(ErrorMessage = "Enter the Relationship")]
        public String Relationship { get; set; }

        public int FkEmployeeId { get; set; }
        [ForeignKey("FkEmployeeId")]
        public Employee Employee { get; set; }
    }
}
