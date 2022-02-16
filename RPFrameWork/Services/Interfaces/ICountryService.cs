using Dtos.Models;

namespace Services.Interfaces
{
    public interface ICountryService
    {
        #region Methods

        #region Sync Methods

        object GetAll();
        object GetById(object id);
        object Save(CountriesCreateDto model);
        public object Update(CountriesUpdateDto model);
        public object Delete(object id);

        #endregion

        #region Aync Methods

        Task<object> GetAllAsync();
        Task<object> GetByIdAsync(object id);
        Task<object> SaveAsync(CountriesCreateDto model);
        Task<object> UpdateAsync(CountriesUpdateDto model);
        public Task<object> DeleteAsync(object id);

        #endregion

        #region Common Methods

        object GetCountryByName(string countryName);
        bool IsExist(object countryId);
        bool IsExist(string countryName, object countryId);

        #endregion  

        #endregion
    }
}
