using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebApi.Areas.Customer.Controllers
{
 
    [ApiController]
    [Area(Constants.CustomerRoleTitle)]
    public class BaseApiController : ControllerBase
    {
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices; 
        #endregion

        #region Constructors
        public BaseApiController(IUnitOfWorkServices unitOfWorkServices)
        {
            this.unitOfWorkServices = unitOfWorkServices;
        }
        #endregion

        #region Methods
        #endregion
    }
}
