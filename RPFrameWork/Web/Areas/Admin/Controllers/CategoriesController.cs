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
    public class CategoriesController : BaseController
    {
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices;
        private readonly IApiService apiService;
        private readonly INotyfService notyf;        
        #endregion

        #region Constructors
        public CategoriesController(IUnitOfWorkServices unitOfWorkServices, INotyfService notyf, IApiService apiService) :base(unitOfWorkServices)
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
                            notyf.Success(Entity.Category + Constants.Space + Constants.InsertedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Update:
                        {
                            notyf.Success(Entity.Category + Constants.Space + Constants.UpdatedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Delete:
                        {
                            notyf.Success(Entity.Category + Constants.Space + Constants.DeletedSuccesfully, 10);
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
        public async Task<IActionResult> GetAllCategories()
        {            
            List<CategoriesListDto> categories = new();
            var response= await apiService.categoryApiService.GetAllCategoriesAsync<ApiResponseDto>();
            if(response!=null && response.IsSuccess)
            {
                 categories = JsonConvert.DeserializeObject<List<CategoriesListDto>>(Convert.ToString(response.Result));
            }
            return Json(new
            {
                data = categories
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            CategoriesCreateDto model = new CategoriesCreateDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriesCreateDto model)
        {
            // Check for validity
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //Check for Duplicate
            var catExist = unitOfWorkServices.categoryService.IsExist(model.CategoryName, 0);
            if (catExist)
            {
                ModelState.AddModelError("", model.CategoryName + " Already Exist");
                notyf.Warning(Entity.Category + Constants.Space + model.CategoryName + Constants.Space + Constants.AlreadyExist, 10);
                return View(model);
            }
            
            // call api and save
            var saveResponseResult = await apiService.categoryApiService.CreateCategoryAsync<ApiResponseDto>(model);
            if (saveResponseResult != null && saveResponseResult.IsSuccess)
            {
                TempData["ShowMessage"] = CrudOperationType.Insert;
                return RedirectToAction("Index");
            }
            else
            {
                notyf.Error(Constants.SomethingWentWrong + Constants.Space + Constants.Saving + Entity.Category + Constants.Space + Constants.Space + model.CategoryName, 10);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var responseSingle = await apiService.categoryApiService.GetCategoriesByIdAsync<ApiResponseDto>(id.Value);
            CategoriesUpdateDto obj = new();
            if (responseSingle != null && responseSingle.IsSuccess)
            {
                obj = JsonConvert.DeserializeObject<CategoriesUpdateDto>(Convert.ToString(responseSingle.Result));
            }            
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoriesUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (unitOfWorkServices.categoryService.IsExist(model.CategoryName, model.CategoryId))
            {
                notyf.Warning(Entity.Category + Constants.Space + model.CategoryName + Constants.Space + Constants.AlreadyExist, 10);
                ModelState.AddModelError("", model.CategoryName + " Already Exist");
                return View(model);
            }
            if (!unitOfWorkServices.categoryService.IsExist(model.CategoryId))
            {
                notyf.Warning(Entity.Category + Constants.Space + model.CategoryName + Constants.Space + Constants.NotFound, 10);
                return NotFound();
            }                        
            var updateResponseResult = await apiService.categoryApiService.UdpateCategoryAsync<ApiResponseDto>(model);
            if (updateResponseResult != null && updateResponseResult.IsSuccess)
            {
                TempData["ShowMessage"] = CrudOperationType.Update;
                return RedirectToAction("Index");
            }            
            else
            {
                notyf.Error(Constants.SomethingWentWrong + Constants.Space + Constants.Updating + Entity.Country + Constants.Space + Constants.Space + model.CategoryName, 10);
                return View(model);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {            
            var deleteResponseResult = await apiService.categoryApiService.DeleteCategoryAsync<ApiResponseDto>(id);
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
