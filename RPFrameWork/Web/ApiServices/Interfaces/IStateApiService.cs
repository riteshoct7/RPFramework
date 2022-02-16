using Dtos.Models;


namespace Web.ApiServices.Interfaces
{
    public interface IStateApiService : IBaseService
    {
        #region Methods
        Task<T> GetAllStatesAsync<T>();
        Task<T> GetStatesByIdAsync<T>(object id);
        Task<T> CreateStateAsync<T>(StatesCreateDto model);
        Task<T> UdpateStateAsync<T>(StatesUpdateDto model);
        Task<T> DeleteStateAsync<T>(object id);
        #endregion
    }
}
