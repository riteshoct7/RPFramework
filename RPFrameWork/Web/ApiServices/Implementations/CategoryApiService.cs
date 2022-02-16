using Common.Helpers;
using Dtos.Models;
using Web.ApiServices.Interfaces;
using static Common.Helpers.Constants;

namespace Web.ApiServices.Implementations
{
    public class CategoryApiService : BaseService, ICategoryApiService
    {
        #region Fields
        private readonly IHttpClientFactory httpClientFactory;
        #endregion

        #region Constructors
        public CategoryApiService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        } 
        #endregion

        #region Methods

        public async Task<T> CreateCategoryAsync<T>(CategoriesCreateDto model)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = model,
                Url= Constants.ApiBaseUrl+"/api/Admin/Categories",
                AccessToken =""
            });                
        }

        public async Task<T> DeleteCategoryAsync<T>(object id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,                
                Url = Constants.ApiBaseUrl + "/api/Admin/Categories/"+id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllCategoriesAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = Constants.ApiBaseUrl + "/api/Admin/Categories",
                AccessToken = ""
            });            
        }

        public  async Task<T> GetCategoriesByIdAsync<T>(object id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = Constants.ApiBaseUrl + "/api/Admin/Categories/"+id,
                AccessToken = ""
            });
        }

        public async Task<T> UdpateCategoryAsync<T>(CategoriesUpdateDto model)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.PUT,
                Data = model,
                Url = Constants.ApiBaseUrl + "/api/Admin/Categories",
                AccessToken = ""
            });
        } 

        #endregion
    }
}
