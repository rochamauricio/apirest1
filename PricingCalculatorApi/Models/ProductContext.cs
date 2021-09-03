using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PricingCalculatorApi.Models
{
  public class ProductContext : DbContext
  {
    public DbSet<Product> Products { get; set; }
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
      SetProductContext();
    }

    public void SetProductContext()
    {
      if (Products.Count() == 0)
      {
        Products.Add(new Product { Id = 1, Category = "Brinquedos", ProfitMargin = 25F });
        Products.Add(new Product { Id = 2, Category = "Bebidas", ProfitMargin = 30F });
        Products.Add(new Product { Id = 3, Category = "Informática", ProfitMargin = 10F });
        Products.Add(new Product { Id = 4, Category = "Softplan", ProfitMargin = 5F });
        Products.Add(new Product { Id = 5, Category = "Outros", ProfitMargin = 15F });
        SaveChanges();
      }
    }
  }
}
