using Dtos.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebApi.Areas.Admin.Controllers
{
    [Route("api/Admin/States")]
    [ApiController]
    public class StatesApiController : BaseApiController
    {
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices;
        #endregion

        #region Constructors
        public StatesApiController(IUnitOfWorkServices unitOfWorkServices) : base(unitOfWorkServices)
        {
            this.unitOfWorkServices = unitOfWorkServices;
        }
        #endregion

        #region Methods
        [HttpGet(Name = "GetAllStates")]
        public async Task<object> GetAllStates()
        {
            return await unitOfWorkServices.stateService.GetAllStatesWithCountryAsync();
        }

        [HttpGet("{StateId:int}", Name = "GetStateById")]
        public async Task<object> GetStateById(int StateId)
        {
            return await unitOfWorkServices.stateService.GetStateWithCountryByStateIdAsync(StateId);
        }

        [HttpPost(Name = "SaveState")]
        public async Task<object> SaveState([FromBody] StatesCreateDto model)
        {
            return await unitOfWorkServices.stateService.SaveAsync(model);
        }

        [HttpPut(Name = "UpdateState")]
        public async Task<object> UpdateState([FromBody] StatesUpdateDto model)
        {
            return await unitOfWorkServices.stateService.UpdateAsync(model);
        }

        [HttpDelete("{StateId:int}", Name = "DeleteState")]
        public async Task<object> DeleteState(int StateId)
        {
            return await unitOfWorkServices.stateService.DeleteAsync(StateId);
        } 
        #endregion
    }
}
