using Entities.Models;

namespace Repository.Interfaces
{
    public interface ICategoryRepositoryAsync : IRepositoryAsync<Categories>
    {

        #region Methods
        void UpdateAsync(Categories obj);
        #endregion
    }
}
