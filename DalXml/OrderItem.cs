using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;
using DalApi;
using DO;
using System.Xml.Linq;
using System.Xml.Serialization;

internal class OrderItem : IOrderItem
{
    static string filePath = @"..\OrderItems.xml";
    public DO.OrderItem GetByOrderAndProduct(int OID, int PID)
    {
        List<DO.OrderItem> OrderIList = GetAll().ToList();

        DO.OrderItem? item = OrderIList.Find(x => x.OrderID == OID && x.ProductID == PID);
        if (item == null)
            throw new Exception("the order item was not found");
        else return (DO.OrderItem)item;
    }
    public IEnumerable<DO.OrderItem> GetAll()
    {
        try
        {
            if (File.Exists(filePath))
            {
                List<DO.OrderItem> list;
              //  XmlSerializer x = new XmlSerializer(typeof(List<DO.OrderItem>));
                XmlSerializer x = new XmlSerializer(typeof(List<DO.OrderItem>), new XmlRootAttribute("OrderItems"));

                FileStream file = new FileStream(filePath, FileMode.Open);
                list = (List<DO.OrderItem>)x.Deserialize(file)!;
                file.Close();
                return list!;
            }
            else
                return new List<DO.OrderItem>();
        }
        catch (Exception)
        {
            throw new Exception("what");
           
        }
    }

    public void UPDATE(DO.OrderItem entity)
    {
        try
        {
            DELETE(entity.ID);// the method delete will throw an exeption if the id does not exist
            ADD(entity);
        }
        catch (Exception)
        {
            throw new Exception("Product does not Exist");
        }
    }

    public DO.OrderItem GET(int id)
    {
        List<DO.OrderItem> OrderIList = GetAll().ToList();

        DO.OrderItem OIReturn = (from OI in OrderIList
                                 where OI.ID == id
                                 select OI).FirstOrDefault();

        if (OIReturn.Equals(default(DO.OrderItem)))
            throw new Exception("the OrderItem doesn't exist");

        return OIReturn;
    }
    public int ADD(DO.OrderItem p)
    {
        if (p.ID != 0)
        {
            XElement OIRoot = XElement.Load(filePath);  //get all the elements from the file

            //check if the customer exists in th file
            var OITemp = (from customer in OIRoot.Elements()
                          where (customer.Element("ID").Value == p.ID.ToString())
                          select customer).FirstOrDefault();
            //throw an exception
            if (OITemp != null)
                throw new Exception("the order item already exit");
            //add the customer to the root element
            OIRoot.Add(
                new XElement("OrderItem",
                new XElement("ID", p.ID),
                new XElement("ProductID", p.ProductID),
                new XElement("OrderID", p.OrderID),
                new XElement("Price", p.Price),
                new XElement("Amount", p.Amount)));
            //save the root in the file
            try
            {
                OIRoot.Save(filePath);
                return p.ID;
            }
            catch (Exception ex)
            {
                throw new Exception("couldnt load the file");
            }
        }
        else
        {
            int RunNum;
            using FileStream file = new FileStream(filePath, FileMode.Open);
            XmlSerializer x = new XmlSerializer(typeof(List<ConfigNumbers>), new XmlRootAttribute("RunNumbers"));
            List<Dal.ConfigNumbers> helpListCharge = x.Deserialize(file) as List<ConfigNumbers>;
            file.Close();
            ConfigNumbers newNum = helpListCharge.Find(x => x.type == "OrderItem");
            RunNum = newNum.num;
            helpListCharge.Remove(newNum);
            newNum.num += 1;
            helpListCharge.Add(newNum);
            FileStream file1 = new FileStream(filePath, FileMode.Create);
            XmlSerializer x1 = new XmlSerializer(typeof(List<ConfigNumbers>), new XmlRootAttribute("RunNumbers"));
            x.Serialize(file1, helpListCharge);
            file1.Close();
            return RunNum;// להחזיר מספר רץ
        }
        // XmlTools.SaveListToXMLElement(customerRoot, customerPath);
    }

    public void DELETE(int id)
    {
        XElement ProductRoot = XElement.Load(filePath);
        List<DO.OrderItem> pList = GetAll().ToList();
        DO.OrderItem OI = new DO.OrderItem();
        try
        {
            OI = GET(id);
            pList.Remove(OI);
            ProductRoot.Save(filePath);
        }
        catch (Exception)
        {
            throw new Exception("Order item does not exist");
        }
    }
}
