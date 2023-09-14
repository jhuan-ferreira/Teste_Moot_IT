using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Data.Infraestruture
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {

        private readonly DbContext _dbContext;
        protected virtual DbContext Context { get { return _dbContext; } }

        public RepositoryBase(DbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException("dbContext");
            this._dbContext = dbContext;
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
                _dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public List<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public bool Save(TEntity entity)
        {
            try
            {
                var primeiraColuna = entity.GetType().GetProperties().Select(x => x.Name).ToArray().First().ToString();
                var id = Convert.ToInt64(entity.GetType().GetProperty(primeiraColuna).GetValue(entity).ToString());

                if (id == 0)
                    _dbContext.Entry(entity).State = EntityState.Added;
                else
                    _dbContext.Entry(entity).State = EntityState.Modified;

                _dbContext.SaveChanges();


                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
