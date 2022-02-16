using Dtos.Models;

namespace Web.ApiServices.Interfaces
{
    public interface ICategoryApiService:IBaseService
    {
        #region Methods
        Task<T> GetAllCategoriesAsync<T>();
        Task<T> GetCategoriesByIdAsync<T>(object id);
        Task<T> CreateCategoryAsync<T>(CategoriesCreateDto model);
        Task<T> UdpateCategoryAsync<T>(CategoriesUpdateDto model);
        Task<T> DeleteCategoryAsync<T>(object id); 
        #endregion
    }
}
