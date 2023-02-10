using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;
using DalApi;
using DO;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.Serialization;

internal class Order : IOrder
{
    static string filePath = @"..\Orders.xml";
    public IEnumerable<DO.Order> GetAll()
    {
        try
        {
            if (File.Exists(filePath))
            {
                List<DO.Order> list;
                XmlSerializer x = new XmlSerializer(typeof(List<DO.Order>), new XmlRootAttribute("Orders"));
                FileStream file = new FileStream(filePath, FileMode.Open);
                list = (List<DO.Order>)x.Deserialize(file)!;
                file.Close();
                return list!;
            }
            else
                return new List<DO.Order>();
        }
        catch (Exception )
        {
            throw new Exception("what");
            //throw new LoadingException(suffixPath + filePath, $"fail to load xml file: {suffixPath + filePath}", ex);
        }
    }

    public void UPDATE(DO.Order entity)
    {
        try
        {
            DELETE(entity.ID);// the method delete will throw an exeption if the id does not exist
            ADD(entity);
        }
        catch (Exception)
        {
            throw new Exception("Order does not Exist");
        }
    }

    public DO.Order GET(int id)
    {
        List<DO.Order> dronesList = GetAll().ToList();

        DO.Order OReturn = (from O in dronesList
                            where O.ID == id
                            select O).FirstOrDefault();

        if (OReturn.Equals(default(DO.Order)))
            throw new Exception("the Order doesn't exist");

        return OReturn;
    }
    public int ADD(DO.Order p)
    {
        if (p.ID != 0)
        {
            XElement OrderRoot = XElement.Load(filePath);  //get all the elements from the file

            //check if the customer exists in th file
            var OrderTemp = (from O in OrderRoot.Elements()
                             where (O.Element("ID").Value == p.ID.ToString())
                             select O).FirstOrDefault();
            //throw an exception
            if (OrderTemp != null)
                throw new Exception("the Order already exit");
            //add the customer to the root element
            if (p.ShipDate == null && p.DeliveryDate == null)
            {
                OrderRoot.Add(
                    new XElement("Order",
                    new XElement("ID", p.ID),
                    new XElement("CustomerName", p.CustomerName),
                    new XElement("CustomerEmail", p.CustomerEmail),
                    new XElement("CustomerAddress", p.CustomerAddress),
                    new XElement("OrderDate", p.OrderDate)));
            }
            else
            {
                if (p.ShipDate != null && p.DeliveryDate == null)
                {
                    OrderRoot.Add(
                        new XElement("Order",
                        new XElement("ID", p.ID),
                        new XElement("CustomerName", p.CustomerName),
                        new XElement("CustomerEmail", p.CustomerEmail),
                        new XElement("CustomerAddress", p.CustomerAddress),
                        new XElement("OrderDate", p.OrderDate),
                        new XElement("ShipDate", p.ShipDate)));
                }
                else
                {
                    if (p.ShipDate != null && p.DeliveryDate != null)
                        OrderRoot.Add(
                            new XElement("Order",
                            new XElement("ID", p.ID),
                            new XElement("CustomerName", p.CustomerName),
                            new XElement("CustomerEmail", p.CustomerEmail),
                            new XElement("CustomerAddress", p.CustomerAddress),
                            new XElement("OrderDate", p.OrderDate),
                            new XElement("ShipDate", p.ShipDate),
                            new XElement("DeliveryDate", p.DeliveryDate)));
                }
            }

            //if (p.ShipDate != null)
            //    OrderRoot.Add(new XElement("ShipDate", p.ShipDate));
            //if (p.DeliveryDate != null)
            //    OrderRoot.Add(new XElement("DeliveryDate", p.DeliveryDate));
            //      new XElement("ShipDate", p.ShipDate),
            //      new XElement("DeliveryDate", p.DeliveryDate)));
            //save the root in the file
            try
            {
                OrderRoot.Save(filePath);
                return p.ID;
            }
            catch (Exception )
            {
                throw new Exception("couldnt load the file");
            }
        }
        else
        {
            int RunNum;
           // XElement configRoot = XElement.Load(@"C:\Users\אריאל דרעי\Desktop\תואר\miniProject\dotNet5782_6386_6083\cconfig.xml");  //get all the elements from the file

            using FileStream file = new FileStream(filePath, FileMode.Open);
            XmlSerializer x = new XmlSerializer(typeof(List<ConfigNumbers>), new XmlRootAttribute("RunNumbers"));
            List<Dal.ConfigNumbers> helpListCharge = x.Deserialize(file) as List<ConfigNumbers>;
            file.Close();
            ConfigNumbers newNum= helpListCharge.Find(x => x.type == "Order");
            RunNum = newNum.num;
            helpListCharge.Remove(newNum);
            newNum.num += 1;
            helpListCharge.Add(newNum);

            FileStream file1 = new FileStream(filePath, FileMode.Create);
            XmlSerializer x1 = new XmlSerializer(typeof(List<ConfigNumbers>), new XmlRootAttribute("RunNumbers"));
            x.Serialize(file1, helpListCharge);
            file1.Close();
            //   List<ImportentNumbers> helpListCharge = XmlTools.LoadListFromXMLSerializer<ImportentNumbers>(configPath);
            //   ImportentNumbers newImp = helpListCharge.Find(x => x.typeOfnumber == "Charge Running Number");
            //  helpListCharge.Remove(newImp);
            //  newImp.numberSaved = 0;
            //helpListCharge.Add(newImp);
           // XmlTools.SaveListToXMLSerializer<ImportentNumbers>(helpListCharge, configPath);
            return RunNum;
        }
    }

    public void DELETE(int id)
    {
        using FileStream file = new FileStream(filePath, FileMode.Open);
        XmlSerializer x = new XmlSerializer(typeof(List<DO.Order>), new XmlRootAttribute("Orders"));
        List<DO.Order> pList;
        pList = x.Deserialize(file) as List<DO.Order>;
        file.Close();
        DO.Order p = new DO.Order();
        p = GET(id);
        try
        {
            pList.RemoveAll(x => x.ID == id);
            using FileStream file1 = new FileStream(filePath, FileMode.Create);
            XmlSerializer x1 = new XmlSerializer(typeof(List<DO.Order>), new XmlRootAttribute("Orders"));
            x1.Serialize(file1, pList);
            file1.Close();
        }
        catch (Exception)
        {
            throw new Exception("Order does not exist");
        }
    }
}
