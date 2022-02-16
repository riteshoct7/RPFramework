using Dtos.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebApi.Areas.Admin.Controllers
{
    [Route("api/Admin/Cities")]
    [ApiController]
    public class CitiesApiController : BaseApiController
    {
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices;
        #endregion

        #region Constructors
        public CitiesApiController(IUnitOfWorkServices unitOfWorkServices) : base(unitOfWorkServices)
        {
            this.unitOfWorkServices = unitOfWorkServices;
        }
        #endregion

        #region Methods
        [HttpGet(Name = "GetAllCities")]
        public async Task<object> GetAllCities()
        {
            return await unitOfWorkServices.cityService.GetAllCitiesAsync();
        }

        [HttpGet("{CityId:int}", Name = "GetCityById")]
        public async Task<object> GetCityById(int CityId)
        {
            return await unitOfWorkServices.cityService.GetCityDetailsByCityIdAsync(CityId);
        }

        [HttpPost(Name = "SaveCity")]
        public async Task<object> SaveCity([FromBody] CitiesCreateDto model)
        {
            return await unitOfWorkServices.cityService.SaveAsync(model);
        }

        [HttpPut(Name = "UpdateCity")]
        public async Task<object> UpdateCity([FromBody] CitiesUpdateDto model)
        {
            return await unitOfWorkServices.cityService.UpdateAsync(model);
        }

        [HttpDelete("{CityId:int}", Name = "DeleteCity")]
        public async Task<object> DeleteCity(int CityId)
        {
            return await unitOfWorkServices.cityService.DeleteAsync(CityId);
        }
        #endregion
    }
}
