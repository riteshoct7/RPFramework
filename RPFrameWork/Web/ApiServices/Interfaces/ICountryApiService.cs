using Dtos.Models;

namespace Web.ApiServices.Interfaces
{
    public interface ICountryApiService : IBaseService
    {
        #region Methods
        Task<T> GetAllCountriesAsync<T>();
        Task<T> GetCountryByIdAsync<T>(object id);
        Task<T> CreateCountryAsync<T>(CountriesCreateDto model);
        Task<T> UdpateCountryAsync<T>(CountriesUpdateDto model);
        Task<T> DeleteCountryAsync<T>(object id);
        #endregion
    }
}
