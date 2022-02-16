using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class CategoryRepositoryAsync:RepositoryAsync<Categories>, ICategoryRepositoryAsync
    {
        #region Fields
        private readonly AppDbContext db; 
        #endregion

        #region Constructors
        public CategoryRepositoryAsync(AppDbContext db) : base(db)
        {
            this.db = db;
        }
        #endregion

        #region Methods
        public  void UpdateAsync(Categories obj)
        {
            var originalData = db.Categories.AsNoTracking().FirstOrDefault(m => m.CategoryId == obj.CategoryId);
            obj.CreatedDate = originalData.CreatedDate;
            obj.UpdatedDate = DateTime.UtcNow;
            db.Categories.Update(obj);
        }
        #endregion
    }
}
