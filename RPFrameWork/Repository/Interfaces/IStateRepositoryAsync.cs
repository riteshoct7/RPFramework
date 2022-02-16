using Entities.Models;

namespace Repository.Interfaces
{
    public interface IStateRepositoryAsync : IRepositoryAsync<States>
    {
        void UpdateAsync(States obj);

        Task<ICollection<States>> GetAllStatesWithCountryAsync();
        Task<States> GetStateWithCountryByStateIdAsync(int stateId);
    }
}
