

namespace DO;
public struct Product
{
    public string? Print { get; set; }
    public int ID { get; set; }
    public double? Price { get; set; }
    public int? InStock { get; set; }
    public Enums.Category? Category { get; set; }

    public override string ToString() => $@"
	Product ID={ID}:
    pruduct name: {Print}, 
	category -{Category}
    Price:{Price}
    Amount in stock:{InStock}
	";



}
