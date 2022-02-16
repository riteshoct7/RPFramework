using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class CityRepositoryAsync:RepositoryAsync<Cities>,ICityRepositoryAsync
    {
        #region Fields
        private readonly AppDbContext db; 
        #endregion

        #region Methods
        public CityRepositoryAsync(AppDbContext db) : base(db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        public void UpdateAsync(Cities obj)
        {
            var originalData = db.Cities.AsNoTracking().FirstOrDefault(m => m.CityId == obj.CityId);
            obj.CreatedDate = originalData.CreatedDate;
            db.Cities.Update(obj);
        }

        public async Task<ICollection<Cities>> GetAllCitiesAsync()
        {
            return await db.Cities.Include(x => x.States).ThenInclude(x => x.Countries).ToListAsync();            
        }

        public async Task<Cities> GetCityDetailsByCityIdAsync(int cityId)
        {
            var result = await db.Cities.Include(c => c.States).ThenInclude(x => x.Countries).Where(c => c.CityId == cityId).ToListAsync();
            return result.FirstOrDefault();
        }

        #endregion
    }
}
