using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Implementations;
using Repository.Interfaces;
using Services.Implementations;
using Services.Interfaces;
using System.Text.Json.Serialization;

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

//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Added For Routing
app.UseRouting(); 
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

#region Added For Areas

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
}); 
#endregion

app.MapControllers();

app.Run();
