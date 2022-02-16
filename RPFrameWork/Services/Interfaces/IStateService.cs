using Dtos.Models;
namespace Services.Interfaces
{
    public interface IStateService
    {
        #region Sync Methods

        object GetAll();
        object GetById(object id);
        object Save(StatesCreateDto model);
        public object Update(StatesUpdateDto model);
        public object Delete(object id);

        #endregion

        #region Aync Methods

        Task<object> GetAllAsync();
        Task<object> GetByIdAsync(object id);
        Task<object> SaveAsync(StatesCreateDto model);
        Task<object> UpdateAsync(StatesUpdateDto model);
        public Task<object> DeleteAsync(object id);

        #endregion

        #region Common Methods

        object GetStateByName(string stateName);
        bool IsExist(object stateId);
        bool IsExist(string stateName, object stateId);

        object GetAllStatesWithCountry();
        Task<object> GetAllStatesWithCountryAsync();

        object GetStateWithCountryByStateId(int stateId);
        Task<object> GetStateWithCountryByStateIdAsync(int stateId);

        #endregion
    }
}
