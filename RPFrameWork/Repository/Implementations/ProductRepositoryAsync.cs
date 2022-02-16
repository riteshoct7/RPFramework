using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class ProductRepositoryAsync : RepositoryAsync<Products>,IProductRepositoryAsync
    {
        #region Fields
        private readonly AppDbContext db;
        #endregion

        #region Constructors
        public ProductRepositoryAsync(AppDbContext db) : base(db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        public void UpdateAsync(Products obj)
        {
            var originalData = db.Products.AsNoTracking().FirstOrDefault(m => m.ProductId == obj.ProductId);
            obj.CreatedDate = originalData.CreatedDate;
            obj.UpdatedDate = DateTime.UtcNow;
            db.Products.Update(obj);
        }

        public async Task<ICollection<Products>> GetAllProductsWithCategoryAsync()
        {
            return await db.Products.Include(x => x.Categories).ToListAsync();
        }

        public async Task<Products> GetProductWithCategoryByProductIdAsync(int productId)
        {
            var result = await db.Products.Include(c => c.Categories).Where(c => c.ProductId == productId).ToListAsync();
            return result.FirstOrDefault();
        }

        #endregion
    }
}
