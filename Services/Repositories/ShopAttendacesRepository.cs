using System.Linq;
using CodeFirstEmployee.models;
using CodeFirstEmployee.contexts;

namespace Services.Repositories
{
    public class ShopAttendacesRepository : IRepository<ShopAttendances>
    {
        private ShopContext _database;

        public void DeleteEntity(ShopAttendances entity)
        {
            _database.Attendances.Remove(entity);
            _database.SaveChanges();
        }

        public IQueryable<ShopAttendances> GetAllEntities()
        {
            var attendances = from attendance in _database.Attendances select attendance;
            return attendances;
        }

        public ShopAttendances GetById(int id)
        {
            var attendance = _database.Attendances.SingleOrDefault(x => x.AttendaceId == id);
            return attendance;
        }

        public void InsertEntity(ShopAttendances entity)
        {
            _database.Attendances.Add(entity);
            _database.SaveChanges();
        }

        public void UpdateEntity(ShopAttendances entity)
        {
            var attendance = _database.Attendances.SingleOrDefault(x => x.AttendaceId == entity.AttendaceId);

            if(attendance != null)
            {
                _database.Entry(attendance).CurrentValues.SetValues(entity);
                _database.SaveChanges();
            }
        }
    }
}
