using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PricingCalculatorApi.Models;

namespace PricingCalculatorApi.Controllers
{
  [Route("api1")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private ProductService _productService;

    public ProductController(ProductService productService)
    {
      _productService = productService;
    }

    // GET: http://localhost:5000/api1
    [HttpGet]
    public ActionResult<List<Product>> GetProductItems()
    {
      return Ok(_productService.ListProducts());
    }

    // GET: http://localhost:5000/api1/price?category=brinquedos&cost=100
    [HttpGet("price")]
    public ActionResult<float> GetPrice(string category, float cost)
    {
      return Ok(_productService.GetPrice(category, cost));
    }
  }
}
