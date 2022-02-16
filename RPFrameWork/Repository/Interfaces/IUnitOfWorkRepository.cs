namespace Repository.Interfaces
{
    public interface IUnitOfWorkRepository :IDisposable
    {
        #region Methods

        ICategoryRepository categoryRepository { get; }
        ICategoryRepositoryAsync categoryRepositoryAsync { get; }
        IProductRepository productRepository { get; }
        IProductRepositoryAsync productRepositoryAsync { get; }
        ICountryRepository countryRepository { get; }
        ICountryRepositoryAsync countryRepositoryAsync { get; }
        IStateRepository stateRepository { get; }
        IStateRepositoryAsync stateRepositoryAsync { get; }
        ICityRepository cityRepository { get; }
        ICityRepositoryAsync cityRepositoryAsync { get; }
        IAccountRepository accountRepository { get; }
        IStoredPorcedureRepository storedPorcedureRepository { get; }
        bool SaveChanges();
        Task<bool> SaveChangesAsync();

        #endregion  
    }
}
