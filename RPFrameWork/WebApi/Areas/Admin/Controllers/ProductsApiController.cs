using Dtos.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebApi.Areas.Admin.Controllers
{
    [Route("api/Admin/Products")]
    [ApiController]
    public class ProductsApiController : BaseApiController
    {
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices;
        #endregion

        #region Constructors
        public ProductsApiController(IUnitOfWorkServices unitOfWorkServices) : base(unitOfWorkServices)
        {
            this.unitOfWorkServices = unitOfWorkServices;
        }
        #endregion

        #region Methods
        [HttpGet(Name = "GetAllProducts")]
        public async Task<object> GetAllProducts()
        {
            return await unitOfWorkServices.productService.GetAllProductsWithCategoryAsync();
        }

        [HttpGet("{ProductId:int}", Name = "GetProductById")]
        public async Task<object> GetProductById(int ProductId)
        {
            return await unitOfWorkServices.productService.GetProductWithCategoryByProductIdAsync(ProductId);
        }

        [HttpPost(Name = "SaveProduct")]
        public async Task<object> SaveProduct([FromBody] ProductsCreateDto model)
        {
            return await unitOfWorkServices.productService.SaveAsync(model);
        }

        [HttpPut(Name = "UpdateProduct")]
        public async Task<object> UpdateProduct([FromBody] ProductsUpdateDto model)
        {
            return await unitOfWorkServices.productService.UpdateAsync(model);
        }

        [HttpDelete("{ProductId:int}", Name = "DeleteProduct")]
        public async Task<object> DeleteProduct(int ProductId)
        {
            return await unitOfWorkServices.productService.DeleteAsync(ProductId);
        }
        #endregion
    }
}
