using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class StateRepository:Repository<States>,IStateRepository
    {
        #region Fields
        private readonly AppDbContext db; 
        #endregion

        #region Constructors
        public StateRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }
        #endregion

        #region Methods

        public States GetStateByName(string stateName)
        {
            return db.States.Where(x => x.StateName.Trim().ToUpper() == stateName.Trim().ToUpper()).FirstOrDefault();
        }

        public bool IsExist(object stateId)
        {
            return db.States.Any(x => x.StateId == (int)stateId);
        }

        public bool IsExist(string stateName, object stateId)
        {
            return db.States.Any(x => x.StateName.Trim().ToUpper() == stateName.Trim().ToUpper() && x.StateId != (int)(stateId));
        }

        public void Update(States obj)
        {
            var originalData = db.States.AsNoTracking().FirstOrDefault(m => m.StateId == obj.StateId);
            obj.CreatedDate = originalData.CreatedDate;
            db.States.Update(obj);
        }

        public ICollection<States> GetAllStatesWithCountry()
        {
            return db.States.Include(x => x.Countries).ToList();
        }

        public States GetStateWithCountryByStateId(int stateId)
        {
            return db.States.Include(c => c.Countries).Where(c => c.StateId == stateId).ToList().FirstOrDefault();
        }

        #endregion
    }
}
