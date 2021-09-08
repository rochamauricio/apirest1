using Microsoft.EntityFrameworkCore;
using PricingCalculatorApi.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PricingCalculatorApiTest.ModelTests
{
  public class ProductServiceTest
  {
    private ProductService _productService;
    public ProductServiceTest()
    {
      var options = new DbContextOptionsBuilder<ProductContext>()
          .UseInMemoryDatabase(databaseName: "productServiceDBTest")
          .Options;
      var productContext = new ProductContext(options);
      _productService = new ProductService(productContext);
    }

    [Fact]
    public void GetPriceTest()
    {
      string category;
      float cost;
      float expected;
      float actual;

      // preço de custo negativo
      category = "brinquedos";
      cost = -100f;
      expected = 0f;
      actual = _productService.GetPrice(category, cost);
      Assert.Equal(expected, actual);

      // preço de custo postivo
      category = "brinquedos";
      cost = 100f;
      expected = 125f;
      actual = _productService.GetPrice(category, cost);
      Assert.Equal(expected, actual);

      // outra categoria qualquer
      category = "blabla";
      cost = 100;
      expected = 115f;
      actual = _productService.GetPrice(category, cost);
      Assert.Equal(expected, actual);

      category = "bebidas";
      cost = 100;
      expected = 130f;
      actual = _productService.GetPrice(category, cost);
      Assert.Equal(expected, actual);

      category = "informática";
      cost = 100;
      expected = 110f;
      actual = _productService.GetPrice(category, cost);
      Assert.Equal(expected, actual);

      category = "softplan";
      cost = 100;
      expected = 105f;
      actual = _productService.GetPrice(category, cost);
      Assert.Equal(expected, actual);

      category = "outros";
      cost = 100;
      expected = 115f;
      actual = _productService.GetPrice(category, cost);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetProfitTest()
    {
      string category;
      float expected;
      float actual;

      category = "brinquedos";
      expected = 25f;
      actual = _productService.GetProfit(category);
      Assert.Equal(expected, actual);

      category = "bebidas";
      expected = 30f;
      actual = _productService.GetProfit(category);
      Assert.Equal(expected, actual);

      category = "informática";
      expected = 10f;
      actual = _productService.GetProfit(category);
      Assert.Equal(expected, actual);

      category = "softplan";
      expected = 5f;
      actual = _productService.GetProfit(category);
      Assert.Equal(expected, actual);

      category = "outros";
      expected = 15f;
      actual = _productService.GetProfit(category);
      Assert.Equal(expected, actual);

      category = "blabla";
      expected = 15f;
      actual = _productService.GetProfit(category);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ListProductsTest()
    {
      List<Product> expected = new List<Product>();
      List<Product> actual = _productService.ListProducts().ToList();

      expected.Add(new Product { Id = 1, Category = "Brinquedos", ProfitMargin = 25f });
      expected.Add(new Product { Id = 2, Category = "Bebidas", ProfitMargin = 30f });
      expected.Add(new Product { Id = 3, Category = "Informática", ProfitMargin = 10f });
      expected.Add(new Product { Id = 4, Category = "Softplan", ProfitMargin = 5f });
      expected.Add(new Product { Id = 5, Category = "Outros", ProfitMargin = 15f });

      Assert.Equal(expected.Count, actual.Count);

      for (int i = 0; i < expected.Count; i++)
      {
        Assert.Equal(expected[i].Id, actual[i].Id);
        Assert.Equal(expected[i].Category, actual[i].Category);
        Assert.Equal(expected[i].ProfitMargin, actual[i].ProfitMargin);
      }
    }
  }
}