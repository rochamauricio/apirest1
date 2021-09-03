namespace PricingCalculatorApi.Models
{
  public class Product
  {
    public long Id { get; set; }
    public string Category { get; set; }
    public float ProfitMargin { get; set; }
  }
}