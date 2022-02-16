using Dtos.Models;

namespace Services.Interfaces
{
    public interface IProductService
    {
        #region Methods

        #region Sync Methods

        object GetAll();
        object GetById(object id);
        object Save(ProductsCreateDto model);
        public object Update(ProductsUpdateDto model);
        public object Delete(object id);

        #endregion

        #region Aync Methods

        Task<object> GetAllAsync();
        Task<object> GetByIdAsync(object id);
        Task<object> SaveAsync(ProductsCreateDto model);
        Task<object> UpdateAsync(ProductsUpdateDto model);
        public Task<object> DeleteAsync(object id);

        #endregion

        #region Common Methods

        object GetProductByName(string productName);
        bool IsExist(object productId);
        bool IsExist(string productName, object productId);

        object GetAllProductsWithCategory();
        Task<object> GetAllProductsWithCategoryAsync();

        object GetProductWithCategoryByProductId(int productId);        
        Task<object> GetProductWithCategoryByProductIdAsync(int productId);

        #endregion  

        #endregion
    }
}
