using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PricingCalculatorApi.Controllers;
using PricingCalculatorApi.Models;
using System.Collections.Generic;
using Xunit;
using System;

namespace PricingCalculatorApiTest.ControllerTests
{
  public class ProductControllerTest
  {
    private ProductController _productController;

    public ProductControllerTest()
    {
      var options = new DbContextOptionsBuilder<ProductContext>()
          .UseInMemoryDatabase(databaseName: "productControllerDBTest")
          .Options;
      var productService = new ProductService(new ProductContext(options));
      _productController = new ProductController(productService);
    }

    [Fact]
    public void GetProductItemsTest()
    {
      List<Product> expected = new List<Product>();

      expected.Add(new Product { Id = 1, Category = "Brinquedos", ProfitMargin = 25f });
      expected.Add(new Product { Id = 2, Category = "Bebidas", ProfitMargin = 30f });
      expected.Add(new Product { Id = 3, Category = "Informática", ProfitMargin = 10f });
      expected.Add(new Product { Id = 4, Category = "Softplan", ProfitMargin = 5f });
      expected.Add(new Product { Id = 5, Category = "Outros", ProfitMargin = 15f });

      var result = _productController.GetProductItems().Result as OkObjectResult; // statusCode retornado pelo request
      var actual = Assert.IsType<List<Product>>(result.Value); // result.Value = objeto retornado, verifica se o retorno é uma lista de produtos

      Assert.Equal(expected.Count, actual.Count);

      for (int i = 0; i < expected.Count; i++)
      {
        Assert.Equal(expected[i].Id, actual[i].Id);
        Assert.Equal(expected[i].Category, actual[i].Category);
        Assert.Equal(expected[i].ProfitMargin, actual[i].ProfitMargin);
      }
    }

    [Fact]
    public void GetPriceTest()
    {
      string category;
      float cost;
      float expected;

      category = "";
      cost = 100f;
      expected = 0f;
      var result = _productController.GetPrice(category, cost).Result as OkObjectResult;
      var actual = Assert.IsType<float>(result.Value);
      Assert.Equal(expected, actual);

      category = "brinquedos";
      cost = 100f;
      expected = 125f;
      result = _productController.GetPrice(category, cost).Result as OkObjectResult;
      actual = Assert.IsType<float>(result.Value);
      Assert.Equal(expected, actual);

      category = "bebidas";
      cost = 100f;
      expected = 130f;
      result = _productController.GetPrice(category, cost).Result as OkObjectResult;
      actual = Assert.IsType<float>(result.Value);
      Assert.Equal(expected, actual);

      category = "informática";
      cost = 100f;
      expected = 110f;
      result = _productController.GetPrice(category, cost).Result as OkObjectResult;
      actual = Assert.IsType<float>(result.Value);
      Assert.Equal(expected, actual);

      category = "softplan";
      cost = 100f;
      expected = 105f;
      result = _productController.GetPrice(category, cost).Result as OkObjectResult;
      actual = Assert.IsType<float>(result.Value);
      Assert.Equal(expected, actual);

      category = "outros";
      cost = 100f;
      expected = 115f;
      result = _productController.GetPrice(category, cost).Result as OkObjectResult;
      actual = Assert.IsType<float>(result.Value);
      Assert.Equal(expected, actual);

      category = "blabla";
      cost = 100f;
      expected = 115f;
      result = _productController.GetPrice(category, cost).Result as OkObjectResult;
      actual = Assert.IsType<float>(result.Value);
      Assert.Equal(expected, actual);
    }
  }
}