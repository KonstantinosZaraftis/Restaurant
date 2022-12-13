using Mango.Web.Models;

namespace Mango.Web.Services
{
    public class ProductService :BaseService,IProductService
    {
        private readonly  IHttpClientFactory  _clientFactory ;      
        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory; 
        }

       

       

        public async Task<T> GetAllRpoductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = (SD.ApiType)SD.ApiType.GET,
                ApiUri = SD.ProductApiBase + "api/products"
            });
          
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                ApiUri = SD.ProductApiBase + "api/products" + id
            });
        }
        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                ApiUri = SD.ProductApiBase + "api/products",
                Data = productDto

            });
        }
        public async Task<T>UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType=SD.ApiType.PUT,
                Data=productDto,
                ApiUri=SD.ProductApiBase + "api/products"

            });
        }
        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                ApiUri = SD.ProductApiBase + "api/products" + id
            });
        }
    }
}
