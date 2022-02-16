using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;


namespace Repository.Implementations
{
    public class CountryRepository : Repository<Countries>, ICountryRepository
    {
        #region Fields
        private readonly AppDbContext db;
        #endregion

        #region Constructors
        public CountryRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        public Countries GetCountryByName(string countryName)
        {
            return db.Countries.Where(x => x.CountryName.Trim().ToUpper() == countryName.Trim().ToUpper()).FirstOrDefault();
        }

        public bool IsExist(object countryId)
        {
            return db.Countries.Any(x => x.CountryId == (int)countryId);
        }

        public bool IsExist(string countryName, object countryId)
        {
            return db.Countries.Any(x => x.CountryName.Trim().ToUpper() == countryName.Trim().ToUpper() && x.CountryId != (int)(countryId));
        }

        public void Update(Countries obj)
        {
            var originalData = db.Countries.AsNoTracking().FirstOrDefault(m => m.CountryId == obj.CountryId);
            obj.CreatedDate = originalData.CreatedDate;
            db.Countries.Update(obj);
        } 

        #endregion
    }
}
