using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductAPI.Models
{
    public class ProductDto
    {
        //We use Dto to transef Data and not directly from the model
        public int ProductId { get; set; }
      
        public string Name { get; set; }
        
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }




    }
}
