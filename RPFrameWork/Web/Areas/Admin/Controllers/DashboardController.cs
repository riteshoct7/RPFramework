using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Web.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices; 
        #endregion

        #region Constructors
        public DashboardController(IUnitOfWorkServices unitOfWorkServices):base(unitOfWorkServices)
        {
            this.unitOfWorkServices = unitOfWorkServices;
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            return View();
        } 
        #endregion
    }
}
