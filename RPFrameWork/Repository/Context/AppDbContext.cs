using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class AppDbContext :IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        #region Constructors
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> db) : base(db)
        {

        }
        #endregion

        #region Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-V86F7GR;Initial Catalog=RPFrameWork;Persist Security Info=True;User ID=sa;Password=software@123");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Categories>().HasData(new Categories()
            {
                CategoryId = 1,
                CategoryName = "Shirts",
                CategoryDescription = "Shirts",
                Enabled = true,
                CreatedDate= DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            });
            builder.Entity<Categories>().HasData(new Categories()
            {
                CategoryId = 2,
                CategoryName = "Shoes",
                CategoryDescription = "Shoes",
                Enabled = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            });
            builder.Entity<Categories>().HasData(new Categories()
            {
                CategoryId = 3,
                CategoryName = "Jeans",
                CategoryDescription = "Jeans",
                Enabled = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            });
            builder.Entity<Categories>().HasData(new Categories()
            {
                CategoryId = 4,
                CategoryName = "Sarees",
                CategoryDescription = "Saress",
                Enabled = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            });
            builder.Entity<Categories>().HasData(new Categories()
            {
                CategoryId = 5,
                CategoryName = "Trousers",
                CategoryDescription = "Trousers",
                Enabled = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            });
            builder.Entity<Categories>().HasData(new Categories()
            {
                CategoryId = 6,
                CategoryName = "Electronics",
                CategoryDescription = "Electronics",
                Enabled = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            });
            builder.Entity<Categories>().HasData(new Categories()
            {
                CategoryId = 7,
                CategoryName = "Perfumes",
                CategoryDescription = "Perfumes",
                Enabled = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            });
            builder.Entity<Categories>().HasData(new Categories()
            {
                CategoryId = 8,
                CategoryName = "Softwares",
                CategoryDescription = "Softwares",
                Enabled = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            });
            builder.Entity<Categories>().HasData(new Categories()
            {
                CategoryId = 9,
                CategoryName = "Stationary",
                CategoryDescription = "Stationary",
                Enabled = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            });
            builder.Entity<Categories>().HasData(new Categories()
            {
                CategoryId = 10,
                CategoryName = "Watches",
                CategoryDescription = "Watches",
                Enabled = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            });
            builder.Entity<Categories>().HasData(new Categories()
            {
                CategoryId = 11,
                CategoryName = "Furniture",
                CategoryDescription = "Furniture",
                Enabled = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            });
            
        }

        #endregion

        #region Fields

        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<ApplicationRole> Role { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Cities> Cities { get; set; }        
        #endregion
    }
}


