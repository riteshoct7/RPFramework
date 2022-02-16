using Repository.Context;
using Repository.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Repository.Implementations
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        #region Fields
        private readonly AppDbContext db;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        #endregion

        #region Constructors
        public UnitOfWorkRepository(AppDbContext db, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.db = db;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.categoryRepository = new CategoryRepository(db);
            this.categoryRepositoryAsync = new CategoryRepositoryAsync(db);
            this.productRepository = new ProductRepository(db);
            this.productRepositoryAsync = new ProductRepositoryAsync(db);
            this.countryRepository = new CountryRepository(db);
            this.countryRepositoryAsync = new CountryRepositoryAsync(db);
            this.stateRepository = new StateRepository(db);
            this.stateRepositoryAsync = new StateRepositoryAsync(db);
            this.cityRepository = new CityRepository(db);
            this.cityRepositoryAsync = new CityRepositoryAsync(db);
            this.accountRepository = new AccountRepository(db, userManager, signInManager, roleManager);
            this.storedPorcedureRepository = new StoredProcedureRepository(db);                      
        }
        #endregion

        #region Methods
        public ICategoryRepository categoryRepository { get; private set; }
        public ICategoryRepositoryAsync categoryRepositoryAsync { get; private set; }
        public IProductRepository productRepository { get; private set; }
        public IProductRepositoryAsync productRepositoryAsync { get; private set; }
        public ICountryRepository countryRepository { get; private set; }
        public ICountryRepositoryAsync countryRepositoryAsync { get; private set; }
        public IStateRepository stateRepository { get; private set; }
        public IStateRepositoryAsync stateRepositoryAsync { get; private set; }
        public ICityRepository cityRepository { get; private set; }
        public ICityRepositoryAsync cityRepositoryAsync { get; private set; }
        public IAccountRepository accountRepository { get; private set; }
        public IStoredPorcedureRepository storedPorcedureRepository { get; private set; }
        

        public void Dispose()
        {
            db.Dispose();   
        }

        public bool SaveChanges()
        {
            return db.SaveChanges() >= 0 ? true : false;
        }

        public  async Task<bool> SaveChangesAsync()
        {
       
            return await db.SaveChangesAsync() >= 0 ? true : false;
        }
                
        #endregion
    }
}
