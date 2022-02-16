using Dtos.Models;

namespace Services.Interfaces
{
    public interface ICategoryService
    {
        #region Methods

        #region Sync Methods

        object GetAll();
        object GetById(object id);
        object Save(CategoriesCreateDto model);
        public object Update(CategoriesUpdateDto model);
        public object Delete(object id); 

        #endregion

        #region Aync Methods

        Task<object> GetAllAsync();
        Task<object> GetByIdAsync(object id);
        Task<object> SaveAsync(CategoriesCreateDto model);
        Task<object> UpdateAsync(CategoriesUpdateDto model);
        public Task<object> DeleteAsync(object id);

        #endregion

        #region Common Methods

        object GetCategoryByName(string categoryName);
        bool IsExist(object categoryId);
        bool IsExist(string categoryName, object categoryId);

        #endregion  

        #endregion
    }
}
