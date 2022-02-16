using Dtos.Models;
using Entities.Models;
using Repository.Interfaces;
using Services.Helpers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CountryService : ICountryService
    {
        #region Fields
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        protected ApiResponseDto response;
        #endregion

        #region Constructors
        public CountryService(IUnitOfWorkRepository unitOfWorkRepository)
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
                var resultFromDb = unitOfWorkRepository.countryRepository.GetAll();
                var result = new List<CountriesListDto>();
                foreach (var item in resultFromDb)
                {
                    result.Add(ObjectMapper.Mapper.Map<CountriesListDto>(item));
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
                var resultFromDb = unitOfWorkRepository.countryRepository.GetById(id);
                var result = new CountriesUpdateDto();
                result = ObjectMapper.Mapper.Map<CountriesUpdateDto>(resultFromDb);
                response.Result = result;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public object Save(CountriesCreateDto model)
        {
            try
            {
                unitOfWorkRepository.countryRepository.Save(ObjectMapper.Mapper.Map<Countries>(model));
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

        public object Update(CountriesUpdateDto model)
        {
            try
            {
                unitOfWorkRepository.countryRepository.Update(ObjectMapper.Mapper.Map<Countries>(model));
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
                unitOfWorkRepository.countryRepository.Remove(id);
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
                var resultFromDb = await unitOfWorkRepository.countryRepositoryAsync.GetAllAsync();
                var result = new List<CountriesListDto>();
                foreach (var item in resultFromDb)
                {
                    result.Add(ObjectMapper.Mapper.Map<CountriesListDto>(item));
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
                var resultFromDb = await unitOfWorkRepository.countryRepositoryAsync.GetByIdAsync(id);
                var result = new CountriesUpdateDto();
                result = ObjectMapper.Mapper.Map<CountriesUpdateDto>(resultFromDb);
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public async Task<object> SaveAsync(CountriesCreateDto model)
        {
            try
            {
                var obj = ObjectMapper.Mapper.Map<Countries>(model);
                obj.CreatedDate = DateTime.UtcNow;
                obj.UpdatedDate = DateTime.UtcNow;
                unitOfWorkRepository.countryRepositoryAsync.SaveAsync(obj);
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

        public async Task<object> UpdateAsync(CountriesUpdateDto model)
        {
            try
            {
                var obj = ObjectMapper.Mapper.Map<Countries>(model);
                unitOfWorkRepository.countryRepositoryAsync.UpdateAsync(obj);
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
                unitOfWorkRepository.countryRepositoryAsync.RemoveAsync(id);
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

        public object GetCountryByName(string countryName)
        {
            var resultFromDb = unitOfWorkRepository.countryRepository.GetCountryByName(countryName);
            var finalResult = ObjectMapper.Mapper.Map<CountriesListDto>(resultFromDb);
            return finalResult;
        }

        public bool IsExist(object countryId)
        {
            return unitOfWorkRepository.countryRepository.IsExist(countryId);
        }

        public bool IsExist(string countryName, object countryId)
        {
            return unitOfWorkRepository.countryRepository.IsExist(countryName, countryId);
        }

        #endregion  

        #endregion

    }
}
