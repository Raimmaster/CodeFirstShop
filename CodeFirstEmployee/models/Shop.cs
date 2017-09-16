using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstEmployee.models
{
    public class Shop
    {
        //ID, Name, Address, Telephone
        [Key]
        public int ShopId { get; set; }
        [Required(ErrorMessage = "Shop Name cannot be empty.")]
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}