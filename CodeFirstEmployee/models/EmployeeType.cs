using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstEmployee.models
{
    public class EmployeeType
    {
        [Key]
        public int EmployeeTypeId { get; set; }
        [Required(ErrorMessage = "EmployeeTypeName must be filled.")]
        public string EmployeeTypeName { get; set; }
        public double Salary { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } 
    }
}
