using Dtos.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;


namespace WebApi.Areas.Admin.Controllers
{
    [Route("api/Admin/Countries")]
    [ApiController]
    public class CountriesApiController : BaseApiController
    {
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices;
        #endregion

        #region Constructors
        public CountriesApiController(IUnitOfWorkServices unitOfWorkServices) : base(unitOfWorkServices)
        {
            this.unitOfWorkServices = unitOfWorkServices;
        }
        #endregion

        #region Methods

        [HttpGet(Name = "GetAllCountris")]
        public async Task<object> GetAllCountris()
        {
            return await unitOfWorkServices.countryService.GetAllAsync();
        }

        [HttpGet("{Countryid:int}", Name = "GetCountryById")]
        public async Task<object> GetCountryById(int Countryid)
        {
            return await unitOfWorkServices.countryService.GetByIdAsync(Countryid);
        }

        [HttpPost(Name = "SaveCountry")]
        public async Task<object> SaveCountry([FromBody] CountriesCreateDto model)
        {
            return await unitOfWorkServices.countryService.SaveAsync(model);
        }

        [HttpPut(Name = "UpdateCountry")]
        public async Task<object> UpdateCountry([FromBody] CountriesUpdateDto model)
        {
            return await unitOfWorkServices.countryService.UpdateAsync(model);
        }

        [HttpDelete("{Countryid:int}", Name = "DeleteCountry")]
        public async Task<object> DeleteCountry(int Countryid)
        {
            return await unitOfWorkServices.countryService.DeleteAsync(Countryid);
        }

        #endregion

    }
}
