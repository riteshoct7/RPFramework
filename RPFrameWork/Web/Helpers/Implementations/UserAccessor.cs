using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Web.Helpers.Interfaces;

namespace Web.Helpers.Implementations
{
    public class UserAccessor : IUserAccessor
    {
        #region Properties
        UserManager<ApplicationUser> userManager;
        IHttpContextAccessor httpContextAccessor;
        #endregion

        #region Constructors
        public UserAccessor(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        #endregion
        #region Methods

        public ApplicationUser GetUser()
        {
            if (httpContextAccessor.HttpContext.User != null)
                return userManager.GetUserAsync(httpContextAccessor.HttpContext.User).Result;
            else
                return null;
        }

        #endregion
    }
}
