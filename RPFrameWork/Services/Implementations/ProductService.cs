using Dtos.Models;
using Entities.Models;
using Repository.Interfaces;
using Services.Helpers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class ProductService : IProductService
    {
        #region Fields
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        protected ApiResponseDto response;
        #endregion

        #region Constructors
        public ProductService(IUnitOfWorkRepository unitOfWorkRepository)
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
                var resultFromDb = unitOfWorkRepository.productRepository.GetAll();
                var result = new List<ProductsListDto>();
                foreach (var item in resultFromDb)
                {
                    result.Add(ObjectMapper.Mapper.Map<ProductsListDto>(item));
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
                var resultFromDb = unitOfWorkRepository.productRepository.GetById(id);
                var result = new ProductsUpdateDto();
                result = ObjectMapper.Mapper.Map<ProductsUpdateDto>(resultFromDb);
                response.Result = result;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public object Save(ProductsCreateDto model)
        {
            try
            {
                unitOfWorkRepository.productRepository.Save(ObjectMapper.Mapper.Map<Products>(model));
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

        public object Update(ProductsUpdateDto model)
        {
            try
            {
                unitOfWorkRepository.productRepository.Update(ObjectMapper.Mapper.Map<Products>(model));
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
                unitOfWorkRepository.productRepository.Remove(id);
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
                var resultFromDb = await unitOfWorkRepository.productRepositoryAsync.GetAllAsync();
                var result = new List<ProductsListDto>();
                foreach (var item in resultFromDb)
                {
                    result.Add(ObjectMapper.Mapper.Map<ProductsListDto>(item));
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
                var resultFromDb = await unitOfWorkRepository.productRepositoryAsync.GetByIdAsync(id);
                var result = new ProductsUpdateDto();
                result = ObjectMapper.Mapper.Map<ProductsUpdateDto>(resultFromDb);
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public async Task<object> SaveAsync(ProductsCreateDto model)
        {
            try
            {
                var obj = ObjectMapper.Mapper.Map<Products>(model);
                obj.CreatedDate = DateTime.UtcNow;
                obj.UpdatedDate = DateTime.UtcNow;
                unitOfWorkRepository.productRepositoryAsync.SaveAsync(obj);
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

        public async Task<object> UpdateAsync(ProductsUpdateDto model)
        {
            try
            {
                var obj = ObjectMapper.Mapper.Map<Products>(model);
                unitOfWorkRepository.productRepositoryAsync.UpdateAsync(obj);
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
                unitOfWorkRepository.productRepositoryAsync.RemoveAsync(id);
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

        public object GetProductByName(string productName)
        {
            var resultFromDb = unitOfWorkRepository.productRepository.GetProductByName(productName);
            var finalResult = ObjectMapper.Mapper.Map<ProductsListDto>(resultFromDb);
            return finalResult;
        }

        public bool IsExist(object productId)
        {
            return unitOfWorkRepository.productRepository.IsExist(productId);
        }

        public bool IsExist(string productName, object productId)
        {
            return unitOfWorkRepository.productRepository.IsExist(productName, productId);
        }

        public object GetAllProductsWithCategory()
        {
            try
            {
                var repoResult = unitOfWorkRepository.productRepository.GetAllProductsWithCategory();
                var result = new List<ProductsListDto>();
                if (repoResult == null)
                {
                    return response;
                }
                foreach (var item in repoResult)
                {
                    result.Add(ObjectMapper.Mapper.Map<ProductsListDto>(item));
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

        public async Task<object> GetAllProductsWithCategoryAsync()
        {
            try
            {
                var repoResult = await  unitOfWorkRepository.productRepositoryAsync.GetAllProductsWithCategoryAsync();
                var result = new List<ProductsListDto>();
                if (repoResult == null)
                {
                    return response;
                }
                foreach (var item in repoResult)
                {
                    result.Add(ObjectMapper.Mapper.Map<ProductsListDto>(item));
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

        public object GetProductWithCategoryByProductId(int productId)
        {
            try
            {
                var repoResult = unitOfWorkRepository.productRepository.GetProductWithCategoryByProductId(productId);
                var result = new ProductsListDto();
                if (repoResult == null)
                {
                    return response;
                }
                result = ObjectMapper.Mapper.Map<ProductsListDto>(repoResult);
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        public async Task<object> GetProductWithCategoryByProductIdAsync(int productId)
        {
            try
            {
                var repoResult = await unitOfWorkRepository.productRepositoryAsync.GetProductWithCategoryByProductIdAsync(productId);
                var result = new ProductsListDto();
                if (repoResult == null)
                {
                    return response;
                }
                result = ObjectMapper.Mapper.Map<ProductsListDto>(repoResult);
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
