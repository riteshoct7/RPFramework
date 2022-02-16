using Common.Helpers;
using Dtos.Models;
using Web.ApiServices.Interfaces;
using static Common.Helpers.Constants;

namespace Web.ApiServices.Implementations
{
    public class StateApiService : BaseService, IStateApiService
    {
        #region Fields
        private readonly IHttpClientFactory httpClientFactory;
        #endregion

        #region Constructors
        public StateApiService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        #endregion

        #region Methods

        public async Task<T> GetAllStatesAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = Constants.ApiBaseUrl + "/api/Admin/States",
                AccessToken = ""
            });
        }

        public async  Task<T> GetStatesByIdAsync<T>(object id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = Constants.ApiBaseUrl + "/api/Admin/States/" + id,
                AccessToken = ""
            });
        }

        public async  Task<T> CreateStateAsync<T>(StatesCreateDto model)
        {

            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = model,
                Url = Constants.ApiBaseUrl + "/api/Admin/States",
                AccessToken = ""
            });
        }

        public async Task<T> UdpateStateAsync<T>(StatesUpdateDto model)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.PUT,
                Data = model,
                Url = Constants.ApiBaseUrl + "/api/Admin/States",
                AccessToken = ""
            });
        }

        public async  Task<T> DeleteStateAsync<T>(object id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                Url = Constants.ApiBaseUrl + "/api/Admin/States/" + id,
                AccessToken = ""
            });
        }

        #endregion
    }
}
