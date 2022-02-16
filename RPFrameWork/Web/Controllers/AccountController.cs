using AspNetCoreHero.ToastNotification.Abstractions;
using Common.Helpers;
using Dtos.ViewModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Web.ApiServices.Interfaces;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
       
        #region Fields
        private readonly IUnitOfWorkServices unitOfWorkServices;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IApiService apiService;
        private readonly INotyfService notyf;
        #endregion

        #region Constructors
        public AccountController(IUnitOfWorkServices unitOfWorkServices, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IApiService apiService, INotyfService notyf)
        {
            this.unitOfWorkServices = unitOfWorkServices;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.apiService = apiService;
            this.notyf = notyf;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await unitOfWorkServices.accountServices.RegisterUserAsync(model, model.Password, Constants.CustomerRoleTitle);
            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(String.Empty, error.Description);
            }
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl = null)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? ReturnUrl = null)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            ReturnUrl = ReturnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await unitOfWorkServices.accountServices.LoginAsync(model, false);
                if (result != null)
                {
                    foreach (var item in result.ApplicationRoles)
                    {
                        switch (item)
                        {
                            case Constants.CustomerRoleTitle:
                                {
                                    return RedirectToAction("Index", "Dashboard", new { Area = Constants.CustomerRoleTitle });
                                }
                            case Constants.AdminRoleTitle:
                                {
                                    return RedirectToAction("Index", "Dashboard", new { Area = Constants.AdminRoleTitle });
                                }
                            default:
                                {
                                    return LocalRedirect(ReturnUrl);
                                }
                        }
                    }
                }
            }
            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> LogOff()
        //{
        //    await signInManager.SignOutAsync();
        //    return RedirectToAction("LogOutComplete");
        //    //return RedirectToAction(nameof(HomeController.Index), "Home");
        //}

        
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogOutComplete");
            //return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        public IActionResult LogOutComplete()
        {
            return View();
        }

        public IActionResult Unauthorize()
        {
            return View();
        }


        #endregion

    }
}
