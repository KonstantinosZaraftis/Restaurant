using Mango.Web.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Newtonsoft.Json;
using System.Text;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService
    {

        public ProductDto _productDto { get; set; }
        public IHttpClientFactory httpClient{ get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {

            _productDto = new ProductDto(); 
            this.httpClient = httpClient;
           
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            var client = httpClient.CreateClient("clientSendHttpRequest");
            HttpRequestMessage message = new HttpRequestMessage();
           
            message.Headers.Add("Accept", "application/json");//Accept header is used to inform the server by the client that which content type is understandable by the client 

            switch (apiRequest.ApiType)
            {

                case SD.ApiType.POST:
                    message.Method= HttpMethod.Post;
                    break;
                case SD.ApiType.PUT:
                    message.Method=HttpMethod.Put;
                    break;
                case SD.ApiType.DELETE:
                    message.Method= HttpMethod.Delete;  
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
                
            }
            
            
            message.RequestUri = new Uri(apiRequest.ApiUri);
            if(apiRequest.Data != null)
            {
                //converting . NET objects such as strings into a JSON format 
                message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),Encoding.UTF8,"application/json");
            }

            //apiresponse
            var apiResponse= await client.SendAsync(message);// is the same with  httpClient.GetAsync(https://localhost:44324/api/Reservation)
            var apiContentResponse=await apiResponse.Content.ReadAsStringAsync();
            var  apiProductDto = JsonConvert.DeserializeObject<T>(apiContentResponse);
            return apiProductDto;
            
           
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
