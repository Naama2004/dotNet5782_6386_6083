namespace BO;

public class cart
{
    public string? CustomerName { get; set; }  
    public string? CustomerEmail { get; set; }   
    public string? CustomerAddres { get; set; } 
    public List<OrderItem>? items { get; set; } 
    public double? price { get; set; }

    public override string ToString() => $@"
Customer Name: ={CustomerName},
Customer Email: {CustomerEmail},
Customer Addres: {CustomerAddres},
price: {price},
items
    
	";

}
