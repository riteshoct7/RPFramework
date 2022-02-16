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
    public class CountriesController : BaseController
    {
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices;
        private readonly INotyfService notyf;
        //private readonly ICountryApiService countryApiService;
        private readonly IApiService apiService;
        #endregion

        #region Constructors        
        public CountriesController(IUnitOfWorkServices unitOfWorkServices, INotyfService notyf, IApiService apiService) : base(unitOfWorkServices)
        {
            this.unitOfWorkServices = unitOfWorkServices;
            this.notyf = notyf;            
            this.apiService = apiService;
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
                            notyf.Success(Entity.Country + Constants.Space + Constants.InsertedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Update:
                        {
                            notyf.Success(Entity.Country + Constants.Space + Constants.UpdatedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Delete:
                        {
                            notyf.Success(Entity.Country + Constants.Space + Constants.DeletedSuccesfully, 10);
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
            //nomal db call
            //var result = await unitOfWorkServices.categoryService.GetAllAsync();                        
            ShowMessage();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            List<CountriesListDto> categories = new();
            var response = await apiService.countryApiService.GetAllCountriesAsync<ApiResponseDto>();
            if (response != null && response.IsSuccess)
            {
                categories = JsonConvert.DeserializeObject<List<CountriesListDto>>(Convert.ToString(response.Result));
            }
            return Json(new
            {
                data = categories
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            CountriesCreateDto model = new CountriesCreateDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CountriesCreateDto model)
        {
            // Check for validity
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //Check for Duplicate
            var catExist = unitOfWorkServices.countryService.IsExist(model.CountryName, 0);
            if (catExist)
            {
                ModelState.AddModelError("", model.CountryName + " Already Exist");
                notyf.Warning(Entity.Category + Constants.Space + model.CountryName + Constants.Space + Constants.AlreadyExist, 10);
                return View(model);
            }

            // call api and save
            var saveResponseResult = await apiService.countryApiService.CreateCountryAsync<ApiResponseDto>(model);
            if (saveResponseResult != null && saveResponseResult.IsSuccess)
            {
                TempData["ShowMessage"] = CrudOperationType.Insert;
                return RedirectToAction("Index");
            }
            else
            {
                notyf.Error(Constants.SomethingWentWrong + Constants.Space + Constants.Saving + Entity.Country + Constants.Space + Constants.Space + model.CountryName, 10);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var responseSingle = await apiService.countryApiService.GetCountryByIdAsync<ApiResponseDto>(id.Value);
            CountriesUpdateDto obj = new();
            if (responseSingle != null && responseSingle.IsSuccess)
            {
                obj = JsonConvert.DeserializeObject<CountriesUpdateDto>(Convert.ToString(responseSingle.Result));
            }
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CountriesUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (unitOfWorkServices.countryService.IsExist(model.CountryName, model.CountryId))
            {
                notyf.Warning(Entity.Country + Constants.Space + model.CountryName + Constants.Space + Constants.AlreadyExist, 10);
                ModelState.AddModelError("", model.CountryName + " Already Exist");
                return View(model);
            }
            if (!unitOfWorkServices.countryService.IsExist(model.CountryId))
            {
                notyf.Warning(Entity.Country + Constants.Space + model.CountryName + Constants.Space + Constants.NotFound, 10);
                return NotFound();
            }
            var updateResponseResult = await apiService.countryApiService.UdpateCountryAsync<ApiResponseDto>(model);
            if (updateResponseResult != null && updateResponseResult.IsSuccess)
            {
                TempData["ShowMessage"] = CrudOperationType.Update;
                return RedirectToAction("Index");
            }
            else
            {
                notyf.Error(Constants.SomethingWentWrong + Constants.Space + Constants.Updating + Entity.Country + Constants.Space + Constants.Space + model.CountryName, 10);
                return View(model);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var deleteResponseResult = await apiService.countryApiService.DeleteCountryAsync<ApiResponseDto>(id);
            if (deleteResponseResult != null && deleteResponseResult.IsSuccess)
            {
                TempData["ShowMessage"] = CrudOperationType.Delete;
                return Json(new { success = true, message = "Delete Successful" });
            }
            return Json(new { success = false, message = "Delete not Successful" });
        }

        #endregion
    }
}
