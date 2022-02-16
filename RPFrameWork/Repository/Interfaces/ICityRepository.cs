using Entities.Models;

namespace Repository.Interfaces
{
    public interface ICityRepository : IRepository<Cities>
    {
        #region Methods

        Cities GetCityByName(string cityName);

        bool IsExist(object cityId);

        bool IsExist(string cityName, object cityId);

        void Update(Cities obj);

        ICollection<Cities> GetAllCities();

        Cities GetCityDetailsByCityId(int cityId);

        #endregion      
    }
}
