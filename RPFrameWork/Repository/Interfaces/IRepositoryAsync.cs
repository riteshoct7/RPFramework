namespace Repository.Interfaces
{
    public interface IRepositoryAsync<T> where T : class
    {
        #region Methods

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        void SaveAsync(T obj);        
        void RemoveAsync(T obj);
        void RemoveAsync(object id);
        void BulkAddAsync(IEnumerable<T> model);
        void BulkUpdateAsync(IEnumerable<T> model);
        void BulkDeleteAsync(IEnumerable<T> model);

        #endregion
    }
}
