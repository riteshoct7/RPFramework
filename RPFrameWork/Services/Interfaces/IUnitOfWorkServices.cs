namespace Services.Interfaces
{
    public interface IUnitOfWorkServices
    {
        #region Methods
        ICategoryService categoryService { get; }
        IProductService productService { get; }
        ICountryService countryService { get; }
        IStateService stateService { get; }
        ICityService cityService { get; }
        IAccountServices accountServices { get; }
        IStoredProcedureService storedProcedureService { get; }
        #endregion
    }
}
