using Entities.Models;

namespace Repository.Interfaces
{
    public interface IStateRepository : IRepository<States>
    {
        #region Methods

        States GetStateByName(string stateName);

        bool IsExist(object stateId);

        bool IsExist(string stateName, object stateId);

        void Update(States obj);

        ICollection<States> GetAllStatesWithCountry();

        States GetStateWithCountryByStateId(int stateId);

        #endregion
    }
}
