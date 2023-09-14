using System.Collections.Generic;

namespace Data.Infraestruture
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool Save(TEntity entity);
        bool Delete(TEntity entity);
        TEntity GetById(int id);
        List<TEntity> GetAll();
        void Dispose();
    }
}
