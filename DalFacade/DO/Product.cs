﻿

namespace DO;
public struct Product
{
    public string? Name { get; set; }
    public int ID { get; set; }
    public double? Price { get; set; }
    public int? InStock { get; set; }
    public Enums.Category? Category { get; set; }

    public override string ToString() => $@"
	Product ID={ID}:
    pruduct name: {Name}, 
	category -{Category}
    Price:{Price}
    Amount in stock:{InStock}
	";



}