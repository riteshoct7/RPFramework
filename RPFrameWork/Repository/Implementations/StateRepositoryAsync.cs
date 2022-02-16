using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class StateRepositoryAsync:RepositoryAsync<States>,IStateRepositoryAsync
    {
        #region Fields
        private readonly AppDbContext db; 
        #endregion

        #region Constructors
        public StateRepositoryAsync(AppDbContext db) : base(db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        public void UpdateAsync(States obj)
        {
            var originalData = db.States.AsNoTracking().FirstOrDefault(m => m.StateId == obj.StateId);
            obj.CreatedDate = originalData.CreatedDate;
            db.States.Update(obj);
        }

        public async Task<ICollection<States>> GetAllStatesWithCountryAsync()
        {
            return await db.States.Include(x => x.Countries).ToListAsync();
        }
        public async Task<States> GetStateWithCountryByStateIdAsync(int stateId)
        {
            var result =  await db.States.Include(c => c.Countries).Where(c => c.StateId == stateId).ToListAsync();
            return result.FirstOrDefault();
        }

        #endregion
    }
}
