using System;
using System.Collections.Generic;
using System.Linq;

namespace PricingCalculatorApi.Models
{
  public class ProductService
  {
    private ProductContext _context;

    public ProductService(ProductContext context)
    {
      _context = context;
    }

    public float GetPrice(string cat, float cost)
    {
      float profit = GetProfit(cat);
      if (profit == 0f || cost <= 0f)
      {
        return 0f;
      }
      else
      {
        return ((100f + profit) * cost) / 100f; // preço de venda
      }
    }

    public float GetProfit(string cat)
    {
      if (String.IsNullOrEmpty(cat))
      {
        return 0f;
      }
      else
      {
        string category = cat.ToLower();
        List<Product> products = _context.Products.Where(i => (i.Category.ToLower() == category)).ToList();

        if (products.Count() == 0)
          return 15f; // lucro é 15% se categoria não estiver tabelada
        else
          return products[0].ProfitMargin;
      }
    }
    public List<Product> ListProducts()
    {
      return _context.Products.ToList();
    }
  }
}
