using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEmployee.models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "EmployeeName cannot be empty.")]
        public string EmployeeName { get; set; }
        [ForeignKey("EmployeeTypeName")]
        public int EmployeeTypeId { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
        public virtual EmployeeType EmployeeTypeName { get; set; }
    }
}
