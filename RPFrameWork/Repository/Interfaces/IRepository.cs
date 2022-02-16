namespace Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        #region Methods

        IEnumerable<T> GetAll();
        T GetById(object id);
        void Save(T obj);        
        void Remove(T obj);
        void Remove(object id);
        void BulkAdd(IEnumerable<T> model);
        void BulkUpdate(IEnumerable<T> model);
        void BulkDelete(IEnumerable<T> model);


        #endregion  
    }
}
