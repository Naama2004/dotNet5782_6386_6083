

namespace DO;
public struct Product
{
    public string? Name { get; set; }
    public int? ID { get; set; }
    public double? Price { get; set; }
    public int? InStock { get; set; }
    public Enums? Category { get; set; }

    public override string ToString() => $@"
	Product ID={ID}: {Name}, 
	category -{Category}
    Price:{Price}
    Amount in stock:{InStock}
	";



}
