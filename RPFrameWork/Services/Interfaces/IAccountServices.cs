using Dtos.Models;
using Dtos.ViewModels;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAccountServices
    {
        Task<object> RegisterUserAsync(RegisterViewModel model, string password, string userRole);

        Task<ApplicationUser> LoginAsync(LoginViewModel model, bool lockOutOnFailure);
    }
}
