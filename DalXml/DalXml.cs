using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Dal;
using DalApi;
using DO;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("RunNumbers")]
public struct ConfigNumbers
{
    [XmlElement("num")]
    public int num { get; set; }

    [XmlElement("type")]
    public string type { get; set; }
}

sealed internal class DalXml : IDal
{
    public static IDal Instance { get; } = new DalXml();


    public IOrder Order { get; } = new Dal.Order();

    public IProduct Product { get; } = new Dal.Product();

    public IOrderItem OrderItem { get; } = new Dal.OrderItem();

}
