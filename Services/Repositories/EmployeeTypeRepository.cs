using System.Data;
using System.Linq;
using CodeFirstEmployee.contexts;
using CodeFirstEmployee.models;

namespace Services.Repositories
{
    public class EmployeeTypeRepository : IRepository<EmployeeType>
    {
        private ShopContext _database;

        public EmployeeTypeRepository()
        {
            _database = new ShopContext();
        }

        public IQueryable<EmployeeType> GetAllEntities()
        {
            var entities = from type in _database.EmployeeTypes select type;
            return entities;
        }

        public EmployeeType GetById(int id)
        {
            var type = _database.EmployeeTypes.SingleOrDefault(x => x.EmployeeTypeId == id);
            return type;
        }

        public void InsertEntity(EmployeeType entity)
        {
            _database.EmployeeTypes.Add(entity);
            _database.SaveChanges();
        }

        public void UpdateEntity(EmployeeType entity)
        {
            var type = _database.EmployeeTypes.SingleOrDefault(x => x.EmployeeTypeId == entity.EmployeeTypeId);

            if (type != null)
            {
                _database.Entry(type).CurrentValues.SetValues(entity);
                _database.SaveChanges();
            }
        }

        public void DeleteEntity(int id)
        {
            var entity = _database.EmployeeTypes.SingleOrDefault(x => x.EmployeeTypeId == id);

            _database.EmployeeTypes.Attach(entity);
            _database.EmployeeTypes.Remove(entity);
            _database.SaveChanges();
        }
    }
}
