using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Fields
        private readonly AppDbContext db;
        internal DbSet<T> dbSet;
        #endregion

        #region Constructors
        public Repository(AppDbContext db)
        {
            this.db = db;
            this.dbSet  = db.Set<T>();
        }
        #endregion

        #region Methods

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Save(T obj)
        {
            db.Add(obj);
        }
        
        public void Remove(T obj)
        {
            db.Remove(obj);
        }

        public void Remove(object id)
        {
            var result = dbSet.Find(id);
            if (result != null)
            {
                Remove(result);
            }
        }

        public void BulkAdd(IEnumerable<T> model)
        {
            db.AddRange(model);
        }

        public void BulkUpdate(IEnumerable<T> model)
        {
            db.UpdateRange(model);
        }

        public void BulkDelete(IEnumerable<T> model)
        {
            db.RemoveRange(model);
        }

        #endregion
    }
}
