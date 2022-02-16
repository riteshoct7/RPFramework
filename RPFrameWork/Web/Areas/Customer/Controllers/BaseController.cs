using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Web.Helpers.Filters;

namespace Web.Areas.Customer.Controllers
{
    [CustomAuthorize(Roles = Constants.CustomerRoleTitle)]
    [Area(Constants.CustomerRoleTitle)]
    public class BaseController : Controller
    {
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices; 
        #endregion

        #region Constructors
        public BaseController(IUnitOfWorkServices unitOfWorkServices)
        {
            this.unitOfWorkServices = unitOfWorkServices;
        }
        #endregion

        #region Methods

        #endregion
    }
}
