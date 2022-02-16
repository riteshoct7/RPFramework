using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class StoredProcedureRepository : IStoredPorcedureRepository
    {
        #region Fields
        private readonly AppDbContext db; 
        #endregion

        #region Constructors
        public StoredProcedureRepository(AppDbContext db)
        {
            this.db = db;
        }
        #endregion

        #region Methods
        #endregion
    }
}
