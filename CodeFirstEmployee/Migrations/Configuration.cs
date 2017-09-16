namespace CodeFirstEmployee.Migrations
{
    using CodeFirstEmployee.models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstEmployee.contexts.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CodeFirstEmployee.contexts.ShopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var types = new List<EmployeeType>
            {
                new EmployeeType { EmployeeTypeId=1, EmployeeTypeName="Gato", Salary=100 },
                new EmployeeType { EmployeeTypeId=2, EmployeeTypeName="Tigre", Salary=100000 }
            };
            types.ForEach(t => context.EmployeeTypes.Add(t));
            context.SaveChanges();

            var emps = new List<Employee>
            {
                new Employee { EmployeeId=1, EmployeeName="Raim", EmployeeTypeId=1 },
                new Employee { EmployeeId=2, EmployeeName="Nexer", EmployeeTypeId=2 }
            };
            emps.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();
        }
    }
}
