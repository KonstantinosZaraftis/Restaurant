using AutoMapper;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig  = new MapperConfiguration(con=> {
                con.CreateMap<ProductDto, Product>();
                con.CreateMap<Product, ProductDto>();

            });
            return mappingConfig;
        }



    }
}
