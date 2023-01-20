
namespace BO;

public class Product
{
    public int ID { get; set; }
    public string? Print { get; set; }
    public double? Price { get; set; }
    public Enums.Category? category { get; set; }
    public int? instock { get; set; }
    public override string ToString() => $@"
Product ID={ID}:
print: {Print}, 
category -{category}
Price:{Price}
Amount in stock:{instock}
	";
}
