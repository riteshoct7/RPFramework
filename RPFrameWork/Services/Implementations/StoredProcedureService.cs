using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class StoredProcedureService : IStoredProcedureService
    {
        #region Fields
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        #endregion

        #region Constructors
        public StoredProcedureService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
        #endregion

        #region Methods
        #endregion
    }
}
