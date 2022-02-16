using AspNetCoreHero.ToastNotification.Abstractions;
using Common.Helpers;
using Dtos.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Interfaces;
using Web.ApiServices.Interfaces;
using static Common.Helpers.Constants;

namespace Web.Areas.Admin.Controllers
{
    public class StatesController : BaseController
    {
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices;
        private readonly IApiService apiService;
        private readonly INotyfService notyf;
        #endregion

        #region Constructors
        public StatesController(IUnitOfWorkServices unitOfWorkServices, INotyfService notyf, IApiService apiService) : base(unitOfWorkServices)
        {
            this.unitOfWorkServices = unitOfWorkServices;
            this.apiService = apiService;
            this.notyf = notyf;
        }
        #endregion

        #region Methods

        public void ShowMessage()
        {
            if (TempData.ContainsKey("ShowMessage"))
            {
                CrudOperationType tempDataShowMessage = (CrudOperationType)TempData["ShowMessage"];
                switch (tempDataShowMessage)
                {
                    case CrudOperationType.Insert:
                        {
                            notyf.Success(Entity.State + Constants.Space + Constants.InsertedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Update:
                        {
                            notyf.Success(Entity.State + Constants.Space + Constants.UpdatedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Delete:
                        {
                            notyf.Success(Entity.State + Constants.Space + Constants.DeletedSuccesfully, 10);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public IActionResult Index()
        {
            ShowMessage();
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllStates()
        {
            List<StatesListDto> states = new();
            var response = await apiService.stateApiService.GetAllStatesAsync<ApiResponseDto>();
            if (response != null && response.IsSuccess)
            {
                states = JsonConvert.DeserializeObject<List<StatesListDto>>(Convert.ToString(response.Result));
            }
            return Json(new
            {
                data = states
            });
        }

        #endregion
    }
}
