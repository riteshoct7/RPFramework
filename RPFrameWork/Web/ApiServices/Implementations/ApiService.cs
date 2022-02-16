using Web.ApiServices.Interfaces;

namespace Web.ApiServices.Implementations
{
    public class ApiService : IApiService
    {
        #region Fields
        private readonly IHttpClientFactory httpClientFactory;
        #endregion

        #region Constructors
        public ApiService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            this.countryApiService = new CountryApiService(httpClientFactory);
            this.stateApiService = new StateApiService(httpClientFactory);
            this.cityApiService = new CityApiService(httpClientFactory);            
            this.categoryApiService = new CategoryApiService(httpClientFactory);
            this.productApiService = new ProductApiService(httpClientFactory);  
        }
        #endregion

        #region Methods
        public ICountryApiService countryApiService { get; private set; }
        public IStateApiService stateApiService { get; private set; }
        public ICityApiService cityApiService { get; private set; }
        public ICategoryApiService categoryApiService { get; private set; }
        public IProductApiService productApiService { get; private set; }
        #endregion
    }
}
