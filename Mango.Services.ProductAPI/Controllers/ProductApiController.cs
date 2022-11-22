using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductApiController : ControllerBase
    {
      
        private readonly IProductRepository _productRepository;

        public ProductApiController(IProductRepository productRepository)
        {
           
            _productRepository = productRepository;
        }

        [HttpGet]//Get/api/products
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        [HttpGet]
        [Route("id")]
        //Get/api/product/id
       
        public async Task<ProductDto> GetProduct(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        [HttpPost]
        //Post/api/product

        public async Task<ProductDto> Post(ProductDto productDto)
        {
            return await _productRepository.CreateUpdateProduct (productDto);
        }

        [HttpPut]
        //Put/api/products
        public  async Task<ProductDto> Put(ProductDto product)
        {
            return await _productRepository.CreateUpdateProduct(product);
        }

        [HttpDelete] 
        //Delete/api/product
        public async Task<bool> Delete(int id)
        {
            return await _productRepository.DeleteProduct(id);
        }

        

    }
}
