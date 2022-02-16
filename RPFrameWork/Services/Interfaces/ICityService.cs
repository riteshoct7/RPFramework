using Dtos.Models;

namespace Services.Interfaces
{
    public interface ICityService
    {
        #region Sync Methods

        object GetAll();
        object GetById(object id);
        object Save(CitiesCreateDto model);
        public object Update(CitiesUpdateDto model);
        public object Delete(object id);

        #endregion

        #region Aync Methods

        Task<object> GetAllAsync();
        Task<object> GetByIdAsync(object id);
        Task<object> SaveAsync(CitiesCreateDto model);
        Task<object> UpdateAsync(CitiesUpdateDto model);
        public Task<object> DeleteAsync(object id);

        #endregion

        #region Common Methods

        object GetCityByName(string cityName);
        bool IsExist(object cityId);
        bool IsExist(string cityName, object cityId);

        object GetAllCities();

        object GetCityDetailsByCityId(int cityId);

        Task<object> GetAllCitiesAsync();

        Task<object> GetCityDetailsByCityIdAsync(int cityId);


        #endregion
    }
}
