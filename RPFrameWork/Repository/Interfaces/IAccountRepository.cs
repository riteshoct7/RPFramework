using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Repository.Interfaces
{
    public interface IAccountRepository : IRepository<ApplicationUser>
    {
        Task<object> RegisterUser(ApplicationUser model, string password, string userRole);
        Task<ApplicationUser> LoginAsync(string userName, string password, bool RememberMe, bool lockOutOnFailure);
    }
}
