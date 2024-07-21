using Microlink.Front.Models;
using Microlink.Front.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using static Microlink.Front.Utility.SD;

namespace Microlink.Front.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto?> SendRequest(RequestDto requestDto)
        {
            try
            {

                HttpClient client = _httpClientFactory.CreateClient("MicroLinkAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                //token


                message.RequestUri = new Uri(requestDto.Url);
                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiResponse = null;

                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;

                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { ISSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { ISSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { ISSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { ISSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex) {

                var dto = new ResponseDto()
                {
                    Message = ex.Message.ToString(),
                    ISSuccess = false
                };
                return dto;

            }

        }
    }
}

 