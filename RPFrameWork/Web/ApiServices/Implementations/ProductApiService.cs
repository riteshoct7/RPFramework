using Common.Helpers;
using Dtos.Models;
using Web.ApiServices.Interfaces;
using static Common.Helpers.Constants;

namespace Web.ApiServices.Implementations
{
    public class ProductApiService : BaseService,IProductApiService
    {
        #region Fields
        private readonly IHttpClientFactory httpClientFactory;
        #endregion

        #region Constructors
        public ProductApiService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        #endregion

        #region Methods

        public async Task<T> CreateProductAsync<T>(ProductsCreateDto model)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = model,
                Url = Constants.ApiBaseUrl + "/api/Admin/Products",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(object id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                Url = Constants.ApiBaseUrl + "/api/Admin/Products/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = Constants.ApiBaseUrl + "/api/Admin/Products",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductsByIdAsync<T>(object id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = Constants.ApiBaseUrl + "/api/Admin/Products/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UdpateProductAsync<T>(ProductsUpdateDto model)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.PUT,
                Data = model,
                Url = Constants.ApiBaseUrl + "/api/Admin/Products",
                AccessToken = ""
            });
        }

        #endregion
    }
}
