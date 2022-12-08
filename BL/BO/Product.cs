
namespace BO;

public class Product
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public double? Price { get; set; }
    public Enums.Category? category { get; set; }
    public int? instock { get; set; }
}
