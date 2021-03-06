using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Web.Areas.Customer.Controllers
{
    public class OrdersController : BaseController
    {
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices; 
        #endregion

        #region Constructors
        public OrdersController(IUnitOfWorkServices unitOfWorkServices) :base(unitOfWorkServices)
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
