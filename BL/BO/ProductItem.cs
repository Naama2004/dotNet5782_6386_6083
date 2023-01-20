namespace BO;

public class ProductItem
{
    public int ProductId { get; set; }
    public string? Print { get; set; }
    public double Price { get; set; }
    public Enums.Category category { get; set; }
    public bool InStock { get; set; }
    public int AmountInCart { get; set; }

    public override string ToString() => $@"
Product Id: ={ProductId},
print: {Print},
price: {Price},
Category: {category},
	";

}
