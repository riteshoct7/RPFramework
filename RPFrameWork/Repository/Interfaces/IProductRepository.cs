using Entities.Models;

namespace Repository.Interfaces
{
    public interface IProductRepository :IRepository<Products>
    {
        #region Methods
        Products GetProductByName(string productName);

        bool IsExist(object productId);

        bool IsExist(string productName, object productId);

        void Update(Products obj);

        ICollection<Products> GetAllProductsWithCategory();

        Products GetProductWithCategoryByProductId(int productId);

        #endregion
    }
}
