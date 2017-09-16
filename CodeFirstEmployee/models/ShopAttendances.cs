using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEmployee.models
{
    public class ShopAttendances
    {
        [Key]
        public int AttendanceId { get; set; }
        [ForeignKey("employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("shop")]
        public int ShopId { get; set; }
        [Required(ErrorMessage = "Date must be saved.")]
        public DateTime AttendaceDate { get; set; }

        public virtual Employee employee { get; set; }
        public virtual Shop shop { get; set; }
    }
}
