using static BO.Enums;

namespace BO;

public class OrderItem
{
    public int OrderId { get; set; }
    public int? ProductId { get; set; }
    public string? Print { get; set; }
    public double? price { get; set; }
    public int? amount { get; set; }
    public double? TotalPrice { get; set; }

    public override string ToString() => $@"
order id: ={OrderId},
Product Id: {ProductId},
Product Name: {Print},
price: {price},
amount: {amount},
Total Price: {TotalPrice}
	";

}
