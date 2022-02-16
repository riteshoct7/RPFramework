using Dtos.Models;

namespace Web.ApiServices.Interfaces
{
    public interface IProductApiService : IBaseService
    {
        #region Methods
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductsByIdAsync<T>(object id);
        Task<T> CreateProductAsync<T>(ProductsCreateDto model);
        Task<T> UdpateProductAsync<T>(ProductsUpdateDto model);
        Task<T> DeleteProductAsync<T>(object id);
        #endregion
    }
}
