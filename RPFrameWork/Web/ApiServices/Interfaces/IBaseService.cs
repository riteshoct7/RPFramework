using Dtos.Models;

namespace Web.ApiServices.Interfaces
{
    public interface IBaseService : IDisposable
    {
        ApiResponseDto response {get;set;}
        Task<T> SendAsync<T>(ApiRequest request);

    }
}
