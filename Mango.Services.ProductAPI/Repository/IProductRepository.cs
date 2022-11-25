using Mango.Services.ProductAPI.Models;

namespace Mango.Services.ProductAPI.Repository
{
     //For crud operations we use the Repository pattern
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);




    }
}
