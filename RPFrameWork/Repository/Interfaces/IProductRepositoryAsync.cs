using Entities.Models;

namespace Repository.Interfaces
{
    public interface IProductRepositoryAsync:IRepositoryAsync<Products>
    {
        #region Methods

        void UpdateAsync(Products obj);

        Task<ICollection<Products>> GetAllProductsWithCategoryAsync();
        Task<Products> GetProductWithCategoryByProductIdAsync(int productId);

        #endregion
    }
}
