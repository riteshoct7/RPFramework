namespace Web.ApiServices.Interfaces
{
    public interface IApiService
    {
        #region Methods
        ICountryApiService countryApiService { get; }
        IStateApiService stateApiService { get; }
        ICityApiService cityApiService { get; }
        ICategoryApiService categoryApiService { get; }
        IProductApiService productApiService { get; }
        #endregion
    }
}
