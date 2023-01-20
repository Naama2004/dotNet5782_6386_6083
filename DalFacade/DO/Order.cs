

using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DO;
[XmlRoot("Orders")]
public struct Order
{
    [XmlElement("ID")]
    public int ID { get; set; }

    [XmlElement("CustomerName")]
    public string? CustomerName { get; set; }

    [XmlElement("CustomerEmail")]
    public string? CustomerEmail { get; set; }

    [XmlElement("CustomerAddress ")]
    public string? CustomerAddress { get; set; }

    [XmlElement("OrderDate")]
    public DateTime? OrderDate { get; set; }

    [XmlElement("ShipDate")]
    public DateTime? ShipDate { get; set; }

    [XmlElement("DeliveryDate")]
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
