using Entities.Models;

namespace Repository.Interfaces
{
    public interface ICityRepositoryAsync : IRepositoryAsync<Cities>
    {
        #region Methods

        void UpdateAsync(Cities obj);
        
        Task<ICollection<Cities>> GetAllCitiesAsync();

        Task<Cities> GetCityDetailsByCityIdAsync(int cityId);


        #endregion
    }
}
