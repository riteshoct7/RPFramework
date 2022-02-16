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
    public class CitiesController : BaseController
    {
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices;
        private readonly IApiService apiService;
        private readonly INotyfService notyf;
        #endregion

        #region Constructors
        public CitiesController(IUnitOfWorkServices unitOfWorkServices, INotyfService notyf, IApiService apiService) : base(unitOfWorkServices)
        {
            this.unitOfWorkServices = unitOfWorkServices;
            this.apiService = apiService;
            this.notyf = notyf;
        }
        #endregion

        #region Methods
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            List<CitiesListDto> cities = new();
            var response = await apiService.cityApiService.GetAllCitiesAsync<ApiResponseDto>();
            if (response != null && response.IsSuccess)
            {
                cities = JsonConvert.DeserializeObject<List<CitiesListDto>>(Convert.ToString(response.Result));
            }
            return Json(new
            {
                data = cities
            });
        }

        #endregion
    }
}
