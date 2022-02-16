using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class CategoryRepository:Repository<Categories>,ICategoryRepository
    {
        #region Fields
        private readonly AppDbContext db; 
        #endregion

        #region Constructors
        public CategoryRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        public Categories GetCategoryByName(string categoryName)
        {
            return db.Categories.Where(x => x.CategoryName.Trim().ToUpper() == categoryName.Trim().ToUpper()).FirstOrDefault();
        }

        public bool IsExist(object categoryId)
        {
            return db.Categories.Any(x => x.CategoryId == (int)categoryId);
        }

        public bool IsExist(string categoryName, object categoryId)
        {
            return db.Categories.Any(x => x.CategoryName.Trim().ToUpper() == categoryName.Trim().ToUpper() && x.CategoryId != (int)(categoryId));
        }

        public void Update(Categories obj)
        {
            var originalData = db.Categories.AsNoTracking().FirstOrDefault(m => m.CategoryId == obj.CategoryId);
            obj.CreatedDate = originalData.CreatedDate;
            db.Categories.Update(obj);
        }

        #endregion  
    }
}
