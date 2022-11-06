

using System.Diagnostics;
using System.Xml.Linq;

namespace DO;

public struct Order
{
    public int ID { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerAddress { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public override string ToString() => $@"
	OrderID={ID}: {ID}, 
	Customer Name ={CustomerName}
    Customer Email = {CustomerEmail}
    Customer Address = {CustomerAddress}
    Order Date = {OrderDate}
    ship date ={ShipDate}
    delivery date{DeliveryDate}
	";

}
