using Dtos.Models;
using Entities.Models;
using Repository.Interfaces;
using Services.Helpers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CityService : ICityService
    {
        #region Fields
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        protected ApiResponseDto response;
        #endregion

        #region Constructors
        public CityService(IUnitOfWorkRepository unitOfWorkRepository)
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
                var resultFromDb = unitOfWorkRepository.cityRepository.GetAll();
                var result = new List<CitiesListDto>();
                foreach (var item in resultFromDb)
                {
                    result.Add(ObjectMapper.Mapper.Map<CitiesListDto>(item));
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
                var resultFromDb = unitOfWorkRepository.cityRepository.GetById(id);
                var result = new CitiesUpdateDto();
                result = ObjectMapper.Mapper.Map<CitiesUpdateDto>(resultFromDb);
                response.Result = result;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public object Save(CitiesCreateDto model)
        {
            try
            {
                unitOfWorkRepository.cityRepository.Save(ObjectMapper.Mapper.Map<Cities>(model));
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

        public object Update(CitiesUpdateDto model)
        {
            try
            {
                unitOfWorkRepository.cityRepository.Update(ObjectMapper.Mapper.Map<Cities>(model));
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
                unitOfWorkRepository.cityRepository.Remove(id);
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
                var resultFromDb = await unitOfWorkRepository.cityRepositoryAsync.GetAllAsync();
                var result = new List<CitiesListDto>();
                foreach (var item in resultFromDb)
                {
                    result.Add(ObjectMapper.Mapper.Map<CitiesListDto>(item));
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
                var resultFromDb = await unitOfWorkRepository.cityRepositoryAsync.GetByIdAsync(id);
                var result = new CitiesUpdateDto();
                result = ObjectMapper.Mapper.Map<CitiesUpdateDto>(resultFromDb);
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public async Task<object> SaveAsync(CitiesCreateDto model)
        {
            try
            {
                var obj = ObjectMapper.Mapper.Map<Cities>(model);
                obj.CreatedDate = DateTime.UtcNow;
                obj.UpdatedDate = DateTime.UtcNow;
                unitOfWorkRepository.cityRepositoryAsync.SaveAsync(obj);
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

        public async Task<object> UpdateAsync(CitiesUpdateDto model)
        {
            try
            {
                var obj = ObjectMapper.Mapper.Map<Cities>(model);
                unitOfWorkRepository.cityRepositoryAsync.UpdateAsync(obj);
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
                unitOfWorkRepository.cityRepositoryAsync.RemoveAsync(id);
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

        public object GetCityByName(string cityName)
        {
            var resultFromDb = unitOfWorkRepository.cityRepository.GetCityByName(cityName);
            var finalResult = ObjectMapper.Mapper.Map<CitiesListDto>(resultFromDb);
            return finalResult;
        }

        public bool IsExist(object cityId)
        {
            return unitOfWorkRepository.cityRepository.IsExist(cityId);
        }

        public bool IsExist(string cityName, object cityId)
        {
            return unitOfWorkRepository.cityRepository.IsExist(cityName, cityId);
        }

        public object GetAllCities()
        {
            try
            {
                var repoResult = unitOfWorkRepository.cityRepository.GetAllCities();
                var result = new List<CitiesListDto>();
                if (repoResult == null)
                {
                    return response;
                }
                foreach (var item in repoResult)
                {
                    result.Add(ObjectMapper.Mapper.Map<CitiesListDto>(item));
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

        public object GetCityDetailsByCityId(int cityId)
        {
            try
            {
                var repoResult = unitOfWorkRepository.cityRepository.GetCityDetailsByCityId(cityId);
                var result = new CitiesListDto();
                if (repoResult == null)
                {
                    return response;
                }
                result = ObjectMapper.Mapper.Map<CitiesListDto>(repoResult);
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public async Task<object> GetAllCitiesAsync()
        {
            try
            {
                var repoResult = await unitOfWorkRepository.cityRepositoryAsync.GetAllCitiesAsync();
                var result = new List<CitiesListDto>();
                if (repoResult == null)
                {
                    return response;
                }
                foreach (var item in repoResult)
                {
                    result.Add(ObjectMapper.Mapper.Map<CitiesListDto>(item));
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

        public async Task<object> GetCityDetailsByCityIdAsync(int cityId)
        {
            try
            {
                var repoResult = await unitOfWorkRepository.cityRepositoryAsync.GetCityDetailsByCityIdAsync(cityId);
                var result = new CitiesListDto();
                if (repoResult == null)
                {
                    return response;
                }
                result = ObjectMapper.Mapper.Map<CitiesListDto>(repoResult);
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
