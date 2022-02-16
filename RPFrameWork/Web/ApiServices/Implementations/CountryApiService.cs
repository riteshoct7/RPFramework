using Common.Helpers;
using Dtos.Models;
using Web.ApiServices.Interfaces;
using static Common.Helpers.Constants;

namespace Web.ApiServices.Implementations
{
    public class CountryApiService : BaseService, ICountryApiService
    {
        #region Fields
        private readonly IHttpClientFactory httpClientFactory;
        #endregion

        #region Constructors
        public CountryApiService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        #endregion

        #region Methods

        public async Task<T> CreateCountryAsync<T>(CountriesCreateDto model)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = model,
                Url = Constants.ApiBaseUrl + "/api/Admin/Countries",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteCountryAsync<T>(object id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                Url = Constants.ApiBaseUrl + "/api/Admin/Countries/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllCountriesAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = Constants.ApiBaseUrl + "/api/Admin/Countries",
                AccessToken = ""
            });
        }

        public async Task<T> GetCountryByIdAsync<T>(object id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = Constants.ApiBaseUrl + "/api/Admin/Countries/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UdpateCountryAsync<T>(CountriesUpdateDto model)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.PUT,
                Data = model,
                Url = Constants.ApiBaseUrl + "/api/Admin/Countries",
                AccessToken = ""
            });
        }
        #endregion
    }
}
