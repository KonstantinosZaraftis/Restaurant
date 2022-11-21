using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Mango.Services.ProductAPI.DbContexts
{
    //first step to create a class name ApplicationDbContext
    public class ApplicationDbContext:DbContext
    {
        //in constructor pass  dbcontectOptios

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
        {

           
        }
        public DbSet<Product>Products { get; set; }

    }
}
