using System.Linq;
using CodeFirstEmployee.contexts;
using CodeFirstEmployee.models;
using System.Data.Entity;

namespace Services.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private ShopContext _database;// = new ShopContext();

        public EmployeeRepository(ShopContext ctx)
        {
            this._database = ctx;
        }

        public IQueryable<Employee> GetAllEntities()
        {
            var entities = from type in _database.Employees select type;
            return entities;
        }

        public Employee GetById(int id)
        {
            var employee = _database.Employees.SingleOrDefault(x => x.EmployeeId == id);
            return employee;
        }

        public void InsertEntity(Employee entity)
        {
            _database.Employees.Add(entity);
            _database.SaveChanges();
        }

        public void UpdateEntity(Employee entity)
        {
            var employee = _database.Employees.SingleOrDefault(x => x.EmployeeId == entity.EmployeeId);
            if (employee != null)
            {
                _database.Entry(employee).CurrentValues.SetValues(entity);
                _database.SaveChanges();
            }
        }

        public void DeleteEntity(int id)
        {
            var entity = _database.Employees.SingleOrDefault(x => x.EmployeeId == id);

            _database.Employees.Attach(entity);
            _database.Employees.Remove(entity);
            _database.SaveChanges();
        }
    }
}
