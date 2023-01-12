namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

//internal class Product : IProduct
//{
//    public IEnumerable<Product> GetAll()
//    {
//       List<Product> products = new List<Product>();
//       XmlSerializer x = new XmlSerializer(typeof(List<Product>));
//       FileStream fs = new FileStream(@"Products.xml", FileMode.Open);
//       products = (List<Product>)x.Deserialize(fs)!;
//       return products!;
//    }

//    public int ADD(Product p)
//    {

//        return 0;
//    }
//}