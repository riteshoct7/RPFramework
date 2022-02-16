using AspNetCoreHero.ToastNotification;
using Common.Helpers;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Implementations;
using Repository.Interfaces;
using Services.Implementations;
using Services.Interfaces;
using System.Text.Json.Serialization;
using Web.ApiServices.Implementations;
using Web.ApiServices.Interfaces;
using Web.Helpers.Implementations;
using Web.Helpers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Modified

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.Configure<IdentityOptions>(opt =>
{
    //password length
    opt.Password.RequiredLength = 5;
    //requires lowercase
    opt.Password.RequireLowercase = true;
    //requires uppercase
    opt.Password.RequireUppercase = true;
    //Time span for lockout
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
    //maximum no of failed login attempts
    opt.Lockout.MaxFailedAccessAttempts = 2;
});
builder.Services.AddScoped<IUnitOfWorkServices, UnitOfWorkServices>();
builder.Services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
builder.Services.AddTransient<IUserAccessor, UserAccessor>();

#region For Api
//builder.Services.AddHttpClient();
////builder.Services.AddHttpClient<ICategoryApiService, CategoryApiService>();
////builder.Services.AddHttpClient<ICountryApiService, CountryApiService>();
builder.Services.AddHttpClient<IApiService, ApiService>();
Constants.ApiBaseUrl = builder.Configuration["ServiceUrls:Api"];
//builder.Services.AddScoped<ICategoryApiService, CategoryApiService>();
//builder.Services.AddScoped<ICountryApiService, CountryApiService>();
builder.Services.AddScoped<IApiService, ApiService>();
#endregion

builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddViewLocalization().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

#region Added For Areas
//added for areas
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//      name: "areas",
//      pattern: "{area=Admin}/{controller=Dashboard}/{action=Index}/{id?}"
//    );
//});
#endregion


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
