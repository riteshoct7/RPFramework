using Entities.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Web.Helpers.Interfaces;

namespace Web.Helpers.Implementations
{
    public abstract class BaseViewPage<TModel> : RazorPage<TModel>
    {
        #region Properties

        [RazorInject]
        public IUserAccessor userAccessor { get; set; }

        public ApplicationUser CurrentUser
        {
            get
            {
                if (User != null)
                    return userAccessor.GetUser();
                else
                    return null;
            }
        }
        #endregion
    }
}
