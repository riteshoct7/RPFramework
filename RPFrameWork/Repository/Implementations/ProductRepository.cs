using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class ProductRepository : Repository<Products>, IProductRepository
    {
        #region Fields
        private readonly AppDbContext db;
        #endregion

        #region Constructors
        public ProductRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        public Products GetProductByName(string productName)
        {
            return db.Products.Where(x => x.ProductName.Trim().ToUpper() == productName.Trim().ToUpper()).FirstOrDefault();
        }

        public bool IsExist(object productId)
        {
            return db.Products.Any(x => x.ProductId == (int)productId);
        }

        public bool IsExist(string productName, object productId)
        {
            return db.Products.Any(x => x.ProductName.Trim().ToUpper() == productName.Trim().ToUpper() && x.ProductId != (int)(productId));
        }

        public void Update(Products obj)
        {
            var originalData = db.Products.AsNoTracking().FirstOrDefault(m => m.ProductId == obj.ProductId);
            obj.CreatedDate = originalData.CreatedDate;
            db.Products.Update(obj);
        }

        public ICollection<Products> GetAllProductsWithCategory()
        {
            return db.Products.Include(x => x.Categories).ToList();
        }

        public Products GetProductWithCategoryByProductId(int productId)
        {
            return db.Products.Include(c => c.Categories).Where(c => c.ProductId == productId).ToList().FirstOrDefault();
        }

        #endregion

    }
}
