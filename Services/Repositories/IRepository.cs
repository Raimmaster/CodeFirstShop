using System.Linq;

namespace Services.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAllEntities();
        TEntity GetById(int id);
        void InsertEntity(TEntity entity);
        void UpdateEntity(TEntity entity);
        void DeleteEntity(int id);
    }
}
