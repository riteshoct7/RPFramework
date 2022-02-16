using Entities.Models;

namespace Repository.Interfaces
{
    public interface ICategoryRepository:IRepository<Categories>
    {        
        #region Methods

        Categories GetCategoryByName(string categoryName);

        bool IsExist(object categoryId);

        bool IsExist(string categoryName, object categoryId);

        void Update(Categories obj);

   

        #endregion        
    }
}
