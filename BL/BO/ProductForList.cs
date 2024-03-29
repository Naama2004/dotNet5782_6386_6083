﻿using DO;
using static BO.Enums;


namespace BO;

public class ProductForList
{
    public int ProductId { get; set; }
    public string? Print { get; set; }
    public double? price { get; set; }
    public Enums.Category Category { get; set; }

    public int? InStock { get; set; }    

    public override string ToString() => $@"
Product Id: ={ProductId},
Product print: {Print},
price: {price},
Category: {Category},
	";

}
