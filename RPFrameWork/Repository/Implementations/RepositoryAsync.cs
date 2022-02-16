using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class RepositoryAsync<T>: IRepositoryAsync<T> where T : class
    {
        #region Fields
        private readonly AppDbContext db;
        internal DbSet<T> dbSet;
        #endregion

        #region Constructors
        public RepositoryAsync(AppDbContext  db)
        {
            this.db = db;
            this.dbSet = db.Set<T>();
        }
        #endregion

        #region Methods

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = dbSet;
            return await query.ToListAsync();
        }

        public async  Task<T> GetByIdAsync(object id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public void SaveAsync(T obj)
        {
            db.AddAsync(obj);
        }
        
        public void RemoveAsync(T obj)
        {
            db.Remove(obj);
        }

        public void RemoveAsync(object id)
        {
            var result = this.dbSet.Find(id);
            if (result != null)
            {
                RemoveAsync(result);
            }
        }

        public async  void BulkAddAsync(IEnumerable<T> model)
        {
            await dbSet.AddRangeAsync(model);
        }

        public void BulkUpdateAsync(IEnumerable<T> model)
        {
            dbSet.UpdateRange(model);
        }

        public void BulkDeleteAsync(IEnumerable<T> model)
        {
            dbSet.RemoveRange(model);
        }

        #endregion
    }
}
