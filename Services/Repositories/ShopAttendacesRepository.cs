using System.Linq;
using CodeFirstEmployee.models;
using CodeFirstEmployee.contexts;

namespace Services.Repositories
{
    public class ShopAttendacesRepository : IRepository<ShopAttendances>
    {
        private ShopContext _database;

        public void DeleteEntity(int id)
        {
            var entity = _database.Attendances.SingleOrDefault(x => x.AttendanceId == id);

            _database.Attendances.Attach(entity);
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
            var attendance = _database.Attendances.SingleOrDefault(x => x.AttendanceId == id);
            return attendance;
        }

        public void InsertEntity(ShopAttendances entity)
        {
            _database.Attendances.Add(entity);
            _database.SaveChanges();
        }

        public void UpdateEntity(ShopAttendances entity)
        {
            var attendance = _database.Attendances.SingleOrDefault(x => x.AttendanceId == entity.AttendanceId);

            if(attendance != null)
            {
                _database.Entry(attendance).CurrentValues.SetValues(entity);
                _database.SaveChanges();
            }
        }
    }
}
