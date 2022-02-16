using Dtos.Models;
using Entities.Models;
using Repository.Interfaces;
using Services.Helpers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class StateService : IStateService
    {
        #region Fields
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        protected ApiResponseDto response;
        #endregion

        #region Constructors
        public StateService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
            response = new ApiResponseDto();
        }
        #endregion

        #region Methods

        #region Sync Methods

        public object GetAll()
        {
            try
            {
                var resultFromDb = unitOfWorkRepository.stateRepository.GetAll();
                var result = new List<StatesListDto>();
                foreach (var item in resultFromDb)
                {
                    result.Add(ObjectMapper.Mapper.Map<StatesListDto>(item));
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public object GetById(object id)
        {
            try
            {
                var resultFromDb = unitOfWorkRepository.stateRepository.GetById(id);
                var result = new StatesUpdateDto();
                result = ObjectMapper.Mapper.Map<StatesUpdateDto>(resultFromDb);
                response.Result = result;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public object Save(StatesCreateDto model)
        {
            try
            {
                unitOfWorkRepository.stateRepository.Save(ObjectMapper.Mapper.Map<States>(model));
                response.Result = unitOfWorkRepository.SaveChanges();
                response.DisplayMessage = "Saved Successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return response;
        }

        public object Update(StatesUpdateDto model)
        {
            try
            {
                unitOfWorkRepository.stateRepository.Update(ObjectMapper.Mapper.Map<States>(model));
                response.Result = unitOfWorkRepository.SaveChanges();
                response.DisplayMessage = "Updated Successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return response;
        }

        public object Delete(object id)
        {
            try
            {
                unitOfWorkRepository.stateRepository.Remove(id);
                response.Result = unitOfWorkRepository.SaveChanges();
                response.DisplayMessage = "Deleted Successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return response;
        }

        #endregion

        #region Aync Methods

        public async Task<object> GetAllAsync()
        {
            try
            {
                var resultFromDb = await unitOfWorkRepository.stateRepositoryAsync.GetAllAsync();
                var result = new List<StatesListDto>();
                foreach (var item in resultFromDb)
                {
                    result.Add(ObjectMapper.Mapper.Map<StatesListDto>(item));
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public async Task<object> GetByIdAsync(object id)
        {
            try
            {
                var resultFromDb = await unitOfWorkRepository.stateRepositoryAsync.GetByIdAsync(id);
                var result = new StatesUpdateDto();
                result = ObjectMapper.Mapper.Map<StatesUpdateDto>(resultFromDb);
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public async Task<object> SaveAsync(StatesCreateDto model)
        {
            try
            {
                var obj = ObjectMapper.Mapper.Map<States>(model);
                obj.CreatedDate = DateTime.UtcNow;
                obj.UpdatedDate = DateTime.UtcNow;
                unitOfWorkRepository.stateRepositoryAsync.SaveAsync(obj);
                response.Result = await unitOfWorkRepository.SaveChangesAsync();
                response.DisplayMessage = "Saved Successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public async Task<object> UpdateAsync(StatesUpdateDto model)
        {
            try
            {
                var obj = ObjectMapper.Mapper.Map<States>(model);
                unitOfWorkRepository.stateRepositoryAsync.UpdateAsync(obj);
                response.Result = await unitOfWorkRepository.SaveChangesAsync();
                response.DisplayMessage = "Updated Successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public async Task<object> DeleteAsync(object id)
        {
            try
            {
                unitOfWorkRepository.stateRepositoryAsync.RemoveAsync(id);
                response.Result = await unitOfWorkRepository.SaveChangesAsync();
                response.DisplayMessage = "Deleted Successfully";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return response;
        }

        #endregion

        #region Common Methods

        public object GetStateByName(string stateName)
        {
            var resultFromDb = unitOfWorkRepository.stateRepository.GetStateByName(stateName);
            var finalResult = ObjectMapper.Mapper.Map<StatesListDto>(resultFromDb);
            return finalResult;
        }

        public bool IsExist(object stateId)
        {
            return unitOfWorkRepository.stateRepository.IsExist(stateId);
        }

        public bool IsExist(string stateName, object stateId)
        {
            return unitOfWorkRepository.stateRepository.IsExist(stateName, stateId);
        }
        
        public object GetAllStatesWithCountry()
        {
            try
            {
                var repoResult = unitOfWorkRepository.stateRepository.GetAllStatesWithCountry();
                var result = new List<StatesListDto>();
                if (repoResult == null)
                {
                    return response;
                }
                foreach (var item in repoResult)
                {
                    result.Add(ObjectMapper.Mapper.Map<StatesListDto>(item));
                }
                response.Result = result;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
                
            }
            return response;
        }

        public async Task<object> GetAllStatesWithCountryAsync()
       {
            try
            {
                var repoResult = await unitOfWorkRepository.stateRepositoryAsync.GetAllStatesWithCountryAsync();
                var result = new List<StatesListDto>();
                if (repoResult == null)
                {
                    return response;
                }
                foreach (var item in repoResult)
                {
                    result.Add(ObjectMapper.Mapper.Map<StatesListDto>(item));
                }
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };                
            }
     
            return response;
        }

        public  object GetStateWithCountryByStateId(int stateId)
        {
            try
            {
                var repoResult = unitOfWorkRepository.stateRepository.GetStateWithCountryByStateId(stateId);
                var result = new StatesListDto();
                if (repoResult == null)
                {
                    return response;
                }                
                result = ObjectMapper.Mapper.Map<StatesListDto>(repoResult);                
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public async Task<object> GetStateWithCountryByStateIdAsync(int stateId)
        {
            try
            {
                var repoResult = await unitOfWorkRepository.stateRepositoryAsync.GetStateWithCountryByStateIdAsync(stateId);
                var result = new StatesListDto();
                if (repoResult == null)
                {
                    return response;
                }
                result = ObjectMapper.Mapper.Map<StatesListDto>(repoResult);
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };                
            }
            return response;
        }

        #endregion  

        #endregion
    }
}
