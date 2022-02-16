using Dtos.Models;
using Newtonsoft.Json;
using System.Text;
using Web.ApiServices.Interfaces;
using static Common.Helpers.Constants;

namespace Web.ApiServices.Implementations
{
    public class BaseService : IBaseService
    {
        #region Constructors
        public BaseService(IHttpClientFactory httpClient)
        {
            this.response = new ApiResponseDto();
            this.httpClient = httpClient;
        }
        #endregion

        #region Fields
        public ApiResponseDto response { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        #endregion

        #region Methods

        public async Task<T> SendAsync<T>(ApiRequest request)
        {
            try
            {
                var client = httpClient.CreateClient("Api");
                HttpRequestMessage  message  = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(request.Url);
                client.DefaultRequestHeaders.Clear();
                if(request.Data !=null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(request.Data),Encoding.UTF8,"application/json");
                }
                HttpResponseMessage apiRepsonse = null;
                switch(request.ApiType)
                {
                    case ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;

                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;

                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiRepsonse = await client.SendAsync(message);
                var apiContent = await apiRepsonse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;
            }
            catch (Exception ex)
            {
                var dto = new ApiResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;                
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        } 

        #endregion
    }
}
