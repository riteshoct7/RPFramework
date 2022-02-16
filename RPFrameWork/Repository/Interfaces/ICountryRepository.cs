using Entities.Models;

namespace Repository.Interfaces
{
    public interface ICountryRepository : IRepository<Countries>
    {

        #region Methods

        Countries GetCountryByName(string countryName);

        bool IsExist(object countryId);

        bool IsExist(string countryName, object countryId);

        void Update(Countries obj);

        #endregion   
    }
}
