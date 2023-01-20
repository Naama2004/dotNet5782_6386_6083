
using System.Xml.Serialization;

namespace DO;

[XmlRoot("OrderItems")]
public struct OrderItem
{
    [XmlElement("ID")]
    public int ID {get; set; }

    [XmlElement("ProductID")]
    public int ?ProductID {get; set; }

    [XmlElement("OrderID")]
    public int? OrderID {get; set; }

    [XmlElement("Price")]
    public double? Price {get; set; }

    [XmlElement("Amount")]
    public int? Amount {get; set; }

    public override string ToString() => $@"
	Item ID={ID},
    Price: {Price},
    Amount= {Amount},
	";

}
