using Dtos.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebApi.Areas.Admin.Controllers
{
    [Route("api/Admin/Categories")]
    [ApiController]
    public class CategoriesApiController : BaseApiController
    {
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices; 
        #endregion

        #region Constructors
        public CategoriesApiController(IUnitOfWorkServices unitOfWorkServices):base(unitOfWorkServices)
        {
            this.unitOfWorkServices = unitOfWorkServices;
        }
        #endregion

        #region Methods
       
        [HttpGet(Name = "GetAllCategories")]
        public async  Task<object> GetAllCategories()
        {
            return await unitOfWorkServices.categoryService.GetAllAsync();
        }

        [HttpGet("{Categoryid:int}",Name = "GetCategoryById")]
        public  async Task<object>  GetCategoryById(int Categoryid)
        {
            return await unitOfWorkServices.categoryService.GetByIdAsync(Categoryid);
        }

        [HttpPost(Name = "SaveCategory")]
        public async Task<object> SaveCategory([FromBody] CategoriesCreateDto model)
        {
            return await unitOfWorkServices.categoryService.SaveAsync(model);
        }

        [HttpPut(Name = "UpdateCategory")]
        public async Task<object> UpdateCategory([FromBody] CategoriesUpdateDto model)
        {
            return await unitOfWorkServices.categoryService.UpdateAsync(model);
        }

        [HttpDelete("{CategoryId:int}", Name = "DeleteCategory")]
        public async Task<object> DeleteCategory(int CategoryId)
        {
            return await unitOfWorkServices.categoryService.DeleteAsync(CategoryId);
        }

        #endregion

    }
}
