using Common.Helpers;
using Dtos.Models;
using Web.ApiServices.Interfaces;
using static Common.Helpers.Constants;

namespace Web.ApiServices.Implementations
{
    public class CityApiService : BaseService, ICityApiService
    {
        #region Fields
        private readonly IHttpClientFactory httpClientFactory;
        #endregion

        #region Constructors
        public CityApiService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        #endregion

        #region Methods

        public async Task<T> CreateCitiesAsync<T>(CitiesCreateDto model)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = model,
                Url = Constants.ApiBaseUrl + "/api/Admin/Cities",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteCitiesAsync<T>(object id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                Url = Constants.ApiBaseUrl + "/api/Admin/Cities/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllCitiesAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = Constants.ApiBaseUrl + "/api/Admin/Cities",
                AccessToken = ""
            });
        }

        public async Task<T> GetCitiesByIdAsync<T>(object id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = Constants.ApiBaseUrl + "/api/Admin/Cities/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UdpateCitiesAsync<T>(CitiesUpdateDto model)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.PUT,
                Data = model,
                Url = Constants.ApiBaseUrl + "/api/Admin/Cities",
                AccessToken = ""
            });
        }

        #endregion

    }
}
