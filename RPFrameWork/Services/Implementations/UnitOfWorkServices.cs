using Repository.Interfaces;
using Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Entities.Models;

namespace Services.Implementations
{
    public class UnitOfWorkServices: IUnitOfWorkServices
    {
        #region Fields
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        #endregion

        #region Constructors

        public UnitOfWorkServices(IUnitOfWorkRepository unitOfWorkRepository, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.categoryService = new CategoryService(unitOfWorkRepository);
            this.productService = new ProductService(unitOfWorkRepository);
            this.countryService = new CountryService(unitOfWorkRepository);
            this.stateService = new StateService(unitOfWorkRepository);
            this.cityService = new CityService(unitOfWorkRepository);
            this.storedProcedureService = new StoredProcedureService(unitOfWorkRepository);
            this.accountServices = new AccountServices(unitOfWorkRepository, signInManager, userManager, roleManager);
        }

        #endregion

        #region Methods

        public ICategoryService categoryService { get; private set; }
        public IProductService productService { get; private set; }
        public IStoredProcedureService storedProcedureService { get; private set; }
        public ICountryService countryService { get; private set; }
        public IStateService stateService { get; private set; }
        public ICityService cityService { get; private set; }
        public IAccountServices accountServices { get; private set; }

        #endregion
    }
}
