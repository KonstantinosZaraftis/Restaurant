using Mango.Web.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;

namespace Mango.Web.Services.IServices
{
    public class BaseService : IBaseService
    {

        //Implement the interface
        public IHttpClientFactory _httpClient { get; set; }
        public ProductDto  productDto { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            productDto = new ProductDto();
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
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

            HttpResponseMessage response = null;

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
            response = await client.SendAsync(message);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var productDto = JsonConvert.DeserializeObject<T>(apiResponse);
            return productDto;

        }

        // this method will be called by the consumer of the object when resoursen are released
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }


}
