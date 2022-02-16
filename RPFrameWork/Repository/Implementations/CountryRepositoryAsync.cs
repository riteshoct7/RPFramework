using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class CountryRepositoryAsync : RepositoryAsync<Countries>, ICountryRepositoryAsync
    {

        #region Fields
        private readonly AppDbContext db;
        #endregion

        #region Constructors
        public CountryRepositoryAsync(AppDbContext db) : base(db)
        {
            this.db = db;
        }
        #endregion

        #region Methods
        public void UpdateAsync(Countries obj)
        {
            var originalData = db.Countries.AsNoTracking().FirstOrDefault(m => m.CountryId == obj.CountryId);
            obj.CreatedDate = originalData.CreatedDate;
            obj.UpdatedDate = DateTime.UtcNow;
            db.Countries.Update(obj);
        }


        #endregion
    }
}
