using static BO.Enums;

namespace BO;

public class OrderForList
{
    public int OrderId { get; set; }
    public Enums.State state { get; set; }
    public int Amount { get; set; }
    public Double TotalPrice { get; set; }

    public override string ToString() => $@"
order id: ={OrderId}
status: {state}
amount: {Amount}
total price: {TotalPrice}
	";
}
