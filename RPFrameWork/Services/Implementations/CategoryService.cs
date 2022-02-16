using Dtos.Models;
using Entities.Models;
using Repository.Interfaces;
using Services.Helpers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        #region Fields
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        protected ApiResponseDto response;
        #endregion

        #region Constructors
        public CategoryService(IUnitOfWorkRepository unitOfWorkRepository)
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
                var resultFromDb = unitOfWorkRepository.categoryRepository.GetAll();
                var result = new List<CategoriesListDto>();
                foreach (var item in resultFromDb)
                {
                    result.Add(ObjectMapper.Mapper.Map<CategoriesListDto>(item));
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
                var resultFromDb = unitOfWorkRepository.categoryRepository.GetById(id);
                var result = new CategoriesUpdateDto();
                result = ObjectMapper.Mapper.Map<CategoriesUpdateDto>(resultFromDb);
                response.Result = result;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public object Save(CategoriesCreateDto model)
        {
            try
            {
                unitOfWorkRepository.categoryRepository.Save(ObjectMapper.Mapper.Map<Categories>(model));
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

        public object Update(CategoriesUpdateDto model)
        {
            try
            {
                unitOfWorkRepository.categoryRepository.Update(ObjectMapper.Mapper.Map<Categories>(model));
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
                unitOfWorkRepository.categoryRepository.Remove(id);
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
                var resultFromDb = await unitOfWorkRepository.categoryRepositoryAsync.GetAllAsync();
                var result = new List<CategoriesListDto>();
                foreach (var item in resultFromDb)
                {
                    result.Add(ObjectMapper.Mapper.Map<CategoriesListDto>(item));
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
                var resultFromDb = await unitOfWorkRepository.categoryRepositoryAsync.GetByIdAsync(id);
                var result = new CategoriesUpdateDto();
                result = ObjectMapper.Mapper.Map<CategoriesUpdateDto>(resultFromDb);
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public async Task<object> SaveAsync(CategoriesCreateDto model)
        {
            try
            {
                var obj = ObjectMapper.Mapper.Map<Categories>(model);
                obj.CreatedDate = DateTime.UtcNow;
                obj.UpdatedDate = DateTime.UtcNow;
                unitOfWorkRepository.categoryRepositoryAsync.SaveAsync(obj);
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

        public async Task<object> UpdateAsync(CategoriesUpdateDto model)
        {
            try
            {                
                var obj = ObjectMapper.Mapper.Map<Categories>(model);                
                unitOfWorkRepository.categoryRepositoryAsync.UpdateAsync(obj);
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
                unitOfWorkRepository.categoryRepositoryAsync.RemoveAsync(id);
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

        public object GetCategoryByName(string categoryName)
        {
            var resultFromDb = unitOfWorkRepository.categoryRepository.GetCategoryByName(categoryName);
            var finalResult = ObjectMapper.Mapper.Map<CategoriesListDto>(resultFromDb);
            return finalResult;
        }

        public bool IsExist(object categoryId)
        {
            return unitOfWorkRepository.categoryRepository.IsExist(categoryId);
        }

        public bool IsExist(string categoryName, object categoryId)
        {
            return unitOfWorkRepository.categoryRepository.IsExist(categoryName, categoryId);
        }

        #endregion  

        #endregion

    }
}
