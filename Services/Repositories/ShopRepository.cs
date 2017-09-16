using System.Linq;
using CodeFirstEmployee.models;
using CodeFirstEmployee.contexts;

namespace Services.Repositories
{
    public class ShopRepository : IRepository<Shop>
    {
        private ShopContext _database;

        public void DeleteEntity(int id)
        {
            var entity = _database.Shops.SingleOrDefault(x => x.ShopId == id);

            _database.Shops.Attach(entity);
            _database.Shops.Remove(entity);
            _database.SaveChanges();
        }

        public IQueryable<Shop> GetAllEntities()
        {
            var shops = from shop in _database.Shops select shop;
            return shops;
        }

        public Shop GetById(int id)
        {
            var shop = _database.Shops.SingleOrDefault(x => x.ShopId == id);
            return shop;
        }

        public void InsertEntity(Shop entity)
        {
            _database.Shops.Add(entity);
            _database.SaveChanges();
        }

        public void UpdateEntity(Shop entity)
        {
            var shop = _database.Shops.SingleOrDefault(x => x.ShopId == entity.ShopId);

            if(shop != null)
            {
                _database.Entry(shop).CurrentValues.SetValues(entity);
                _database.SaveChanges();
            }
        }
    }
}
