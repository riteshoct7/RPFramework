using Common.Helpers;
using Dtos.Models;
using Dtos.ViewModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;
using Services.Helpers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class AccountServices : IAccountServices
    {
        #region Fields
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        protected ApiResponseDto response;
        #endregion

        #region Constructors
        public AccountServices(IUnitOfWorkRepository unitOfWorkRepository, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            response = new ApiResponseDto();
        }
        #endregion

        #region Methods
        public async Task<object> RegisterUserAsync(RegisterViewModel model, string password, string userRole)
        {
            try
            {
                var user = ObjectMapper.Mapper.Map<ApplicationUser>(model);
                user.UserName = model.Email;
                var result = await unitOfWorkRepository.accountRepository.RegisterUser(user, password, userRole);
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public async Task<ApplicationUser> LoginAsync(LoginViewModel model, bool lockOutOnFailure)
        {
            
           return  await unitOfWorkRepository.accountRepository.LoginAsync(model.UserName, model.Password, model.RemembeMe, lockOutOnFailure);
                                                   
                                                   
        } 
        #endregion
    }
}
