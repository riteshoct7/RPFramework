using Entities.Models;

namespace Web.Helpers.Interfaces
{
    public interface IUserAccessor
    {
        #region Methods

        ApplicationUser GetUser();

        #endregion
    }
}
