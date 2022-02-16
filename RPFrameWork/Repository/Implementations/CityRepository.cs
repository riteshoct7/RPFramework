using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class CityRepository:Repository<Cities>,ICityRepository
    {
        #region Fields
        private readonly AppDbContext db;
        #endregion

        #region Constuctors
        public CityRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        public Cities GetCityByName(string cityName)
        {
            return db.Cities.Where(x => x.CityName.Trim().ToUpper() == cityName.Trim().ToUpper()).FirstOrDefault();
        }

        public  bool IsExist(object cityId)
        {
            return db.Cities.Any(x => x.CityId == (int)cityId);
        }

        public  bool IsExist(string cityName, object cityId)
        {
            return db.Cities.Any(x => x.CityName.Trim().ToUpper() == cityName.Trim().ToUpper() && x.CityId != (int)(cityId));
        }

        public  void Update(Cities obj)
        {
            var originalData = db.Cities.AsNoTracking().FirstOrDefault(m => m.CityId == obj.CityId);
            obj.CreatedDate = originalData.CreatedDate;
            db.Cities.Update(obj);
        }

        public ICollection<Cities> GetAllCities()
        {
            return db.Cities.Include(x => x.States).ThenInclude(x => x.Countries).ToList();
        }

        public Cities GetCityDetailsByCityId(int cityId)
        {
            return db.Cities.Include(c => c.States).ThenInclude(c => c.Countries).Where(c => c.CityId == cityId).ToList().FirstOrDefault();
        }

        #endregion
    }
}
