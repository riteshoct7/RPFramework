using Common.Helpers;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class AccountRepository : Repository<ApplicationUser>, IAccountRepository
    {
        #region Fields
        private readonly AppDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        #endregion

        #region Constuctors
        public AccountRepository(AppDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager) : base(db)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        #endregion

        public async Task<object> RegisterUser(ApplicationUser model, string password, string userRole)
        {
            var result = await userManager.CreateAsync(model, password);
            if (result.Succeeded)
            {
                if (!roleManager.RoleExistsAsync(Constants.AdminRoleTitle).Result)
                {
                    ApplicationRole objRole = new ApplicationRole();
                    objRole.Name = Constants.AdminRoleTitle;
                    objRole.NormalizedName = Constants.AdminRoleTitle;
                    objRole.Description = Constants.AdminRoleTitle;
                    await roleManager.CreateAsync(objRole);
                }
                if (!roleManager.RoleExistsAsync(Constants.CustomerRoleTitle).Result)
                {
                    ApplicationRole objRole = new ApplicationRole();
                    objRole.Name = Constants.CustomerRoleTitle;
                    objRole.NormalizedName = Constants.CustomerRoleTitle;
                    objRole.Description = Constants.CustomerRoleTitle;
                    await roleManager.CreateAsync(objRole);
                }
                //var roleResult ;
                bool roleAssignmentSuceess = false;
                switch (userRole)
                {
                    case Constants.CustomerRoleTitle:
                        {
                            var roleResult = userManager.AddToRoleAsync(model, Constants.CustomerRoleTitle).Result;
                            roleAssignmentSuceess = roleResult.Succeeded;
                            break;
                        }
                    case Constants.AdminRoleTitle:
                        {
                            var roleResult = userManager.AddToRoleAsync(model, Constants.AdminRoleTitle).Result;
                            roleAssignmentSuceess = roleResult.Succeeded;
                            break;
                        }
                    default:
                        {
                            var roleResult = userManager.AddToRoleAsync(model, Constants.CustomerRoleTitle).Result;
                            roleAssignmentSuceess = roleResult.Succeeded;
                            break;
                        }
                }

                if (roleAssignmentSuceess)
                {
                    await signInManager.SignInAsync(model, isPersistent: false);
                    if (result.Succeeded && roleAssignmentSuceess)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public async Task<ApplicationUser> LoginAsync(string userName, string password, bool RememberMe, bool lockOutOnFailure)
        {
            var result = await signInManager.PasswordSignInAsync(userName,password,RememberMe,lockOutOnFailure);
            var user = userManager.FindByNameAsync(userName).Result;
            if (result.Succeeded)
            {                
                var roles = userManager.GetRolesAsync(user).Result;
                user.ApplicationRoles = roles.ToArray();                
            }
            return user;
        }
    }
}
