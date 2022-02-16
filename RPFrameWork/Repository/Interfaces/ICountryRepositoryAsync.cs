using Entities.Models;


namespace Repository.Interfaces
{
    public interface ICountryRepositoryAsync :  IRepositoryAsync<Countries>
    {
        #region Methods        
        void UpdateAsync(Countries obj);
        #endregion
    }
}
