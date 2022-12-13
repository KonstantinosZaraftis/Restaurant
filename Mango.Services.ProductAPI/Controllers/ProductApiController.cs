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
      
        private IProductRepository _productRepository;
        public ProductDto productDto { get; set; }

        public ProductApiController( IProductRepository productRepository)
        {
             productDto = new ProductDto();
            _productRepository = productRepository;

        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
           
            IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
            return productDtos;
        }

        [HttpGet]
        [Route("id")]
        //Get/api/product/id
       
        public async Task<ProductDto> GetProduct(int id)
        {
            

            var productDto= await _productRepository.GetProductById(id);
            return productDto;
            
        }

        [HttpPost]
        //Post/api/product

        public async Task<ProductDto> Post(ProductDto productDto)
        {
           var productDtoInDb= await _productRepository.CreateUpdateProduct(productDto);
            return productDtoInDb;
        }
        [HttpDelete]
        [Route("{id}")]
        //Delete/api/product
        public async Task<bool> Delete(int id)
        {
            var productDtoInDb= await _productRepository.DeleteProduct(id);
            return productDtoInDb;
        }

        

    }
}
