using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;
using DalApi;
using DO;
using System.Xml.Serialization;

//internal class Order : IOrder
//{
//    public IEnumerable<Order> GetAll()
//    {
//        List<Order> orders = new List<Order>();
//        XmlSerializer x = new XmlSerializer(typeof(List<Order>));
//        FileStream fs = new FileStream(@"Orders.xml", FileMode.Open);
//        orders = (List<Order>)x.Deserialize(fs)!;
//        return orders!;
//    }
//}
