using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebApi.Areas.Customer.Controllers
{
    [Route("api/Customer/Orders")]
    [ApiController]
    public class OrdersApiController : BaseApiController
    {
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices; 
        #endregion

        #region Constructors
        public OrdersApiController(IUnitOfWorkServices unitOfWorkServices) :base(unitOfWorkServices)
        {
            this.unitOfWorkServices = unitOfWorkServices;
        }
        #endregion

        #region Methods

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Get All Orders");
        }

        [HttpGet("{OrderId:int}", Name = "GetOrderById")]
        public IActionResult GetOrderById(int OrderId)
        {
            return Ok(OrderId);
        }

        #endregion
    }
}
