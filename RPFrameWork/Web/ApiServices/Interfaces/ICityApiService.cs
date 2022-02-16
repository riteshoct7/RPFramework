using Dtos.Models;

namespace Web.ApiServices.Interfaces
{
    public interface ICityApiService : IBaseService
    {
        #region Methods
        Task<T> GetAllCitiesAsync<T>();
        Task<T> GetCitiesByIdAsync<T>(object id);
        Task<T> CreateCitiesAsync<T>(CitiesCreateDto model);
        Task<T> UdpateCitiesAsync<T>(CitiesUpdateDto model);
        Task<T> DeleteCitiesAsync<T>(object id);
        #endregion
    }
}
