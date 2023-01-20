

using System.Xml.Serialization;

namespace DO;
[XmlRoot("Products")]
public struct Product
{
    [XmlElement("ID")]
    public int ID { get; set; }
    [XmlElement("Category")]
    public Enums.Category? Category { get; set; }

    [XmlElement("Print")]
    public string? Print { get; set; }

    [XmlElement("Price")]
    public double? Price { get; set; }

    [XmlElement("InStock")]
    public int? InStock { get; set; }


    public override string ToString() => $@"
	Product ID={ID}:
    pruduct print: {Print}, 
	category :{Category}
    Price:{Price}
    Amount in stock:{InStock}
	";



}
