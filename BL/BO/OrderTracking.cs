using DO;

namespace BO;

public class OrderTracking
{
    public int OrderId { get; set; }
    public Enums.State State { get; set; }
    Tuple<BO.Enums.State,DateTime> tracking { get; set; }   
    // public //tupels

    public override string ToString() => $@"
order id: ={OrderId},
status: {State},
	";
}
