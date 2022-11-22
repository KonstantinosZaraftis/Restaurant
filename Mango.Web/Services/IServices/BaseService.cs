using Mango.Web.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;

namespace Mango.Web.Services.IServices
{
    public class BaseService : IBaseService
    {
        public IHttpClientFactory _httpClient { get; set; }
        public ProductDto  productDto { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            productDto = new ProductDto();
        }

        public async Task<T> Send1Async<T>(ApiRequest apiRequest)
        {
            var client = _httpClient.CreateClient("FirstApiCall");

            HttpRequestMessage message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(apiRequest.ApiUrl);
            client.DefaultRequestHeaders.Clear();
            if (apiRequest != null)
            {
                message.Content=new StringContent(JsonConvert.SerializeObject(apiRequest.Data),Encoding.UTF8,"application/json");
            }

            HttpResponseMessage apiResponse = null;

            switch (apiRequest.ApiType)
            {
                case SD.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case SD.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case SD.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;

                    default:
                    message.Method = HttpMethod.Get;
                    break;


            }
            apiResponse = await client.SendAsync(message);
            var apiContect = await apiResponse.Content.ReadAsStringAsync();
            var productDto = JsonConvert.DeserializeObject<T>(apiContect);
            return productDto;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }


}
