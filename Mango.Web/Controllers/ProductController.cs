using Mango.Web.Models;
using Mango.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {   //the controller wich consume api is the same with the controller in mvc
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;   
        }
        public async Task <IActionResult> ProductIndex()
        {
            List<ProductDto> list = new List<ProductDto>();
            var response = await _productService.GetAllRpoductsAsync<ProductDto>();
            if (response != null)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response));
            }
            return View(list);
        }


        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            var response = await _productService.CreateProductAsync<ProductDto>(productDto);
            if(response != null)
            {
                return RedirectToAction("ProductIndex");
            }
            return View(response);
        }


        public async Task<IActionResult> EditProduct(int productId)
        {
            var response = await _productService.GetProductByIdAsync<ProductDto>(productId);
            if (response != null)
            {
                var productDto = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response));
                return View(productDto);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductDto productDto)
        {
            var response = await _productService.UpdateProductAsync<ProductDto>(productDto);
            if (response != null)
            {
                return RedirectToAction("ProductIndex");
            }
            return View(response);
        }

        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var response = await _productService.GetProductByIdAsync<ProductDto>(productId);
            if (response != null)
            {
                var productDto = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response));
                return View(productDto);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(ProductDto productDto)
        {
            var response = await _productService.DeleteProductAsync<ProductDto>(productDto.ProductId);
            if (response!=null)
            {
                return RedirectToAction("ProductIndex");
            }
            return View(response);
        }


    }
}
