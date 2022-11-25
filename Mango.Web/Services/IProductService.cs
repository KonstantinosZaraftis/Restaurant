using Mango.Web.Models;

namespace Mango.Web.Services
{
    public interface IProductService
    {

        Task<T> GetAllRpoductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductDto<T>(int id);    
    }
}
