using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CodeFirstEmployee.models;

namespace CodeFirstEmployee.contexts
{
    public class ShopContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<ShopAttendances> Attendances { get; set; }

        private string _connectionString;

        public ShopContext() : base("name=ShopContext") {
            base.Configuration.LazyLoadingEnabled = false;
        }

        public ShopContext(string connectionString) : this()
        {
            this._connectionString = connectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
