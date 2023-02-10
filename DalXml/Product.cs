namespace Dal;
using DalApi;
using Dal;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Linq;
using DO;

using System;
using System.Linq;







internal class Product : IProduct
{
    static string filePath = @"..\Products.xml";

    public IEnumerable<DO.Product> GetAll()
    {
        try
        {
            if (File.Exists(filePath))
            {

                List<DO.Product> list;
                using FileStream file = new FileStream(filePath, FileMode.Open);
                //XmlSerializer x = new (typeof(List<DO.Product>));
                XmlSerializer x = new XmlSerializer(typeof(List<DO.Product>), new XmlRootAttribute("Products"));
                list = x.Deserialize(file)as List<DO.Product>;
                file.Close();
                return list!;
            }
            else
                return new List<DO.Product>();
        }
        catch (Exception ex)
        {
            throw new Exception("what");
            //throw new LoadingException(suffixPath + filePath, $"fail to load xml file: {suffixPath + filePath}", ex);
        }
    }

    public void UPDATE(DO.Product entity)
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

    public DO.Product GET(int id)
    {
        List<DO.Product> dronesList = GetAll().ToList();

        DO.Product PReturn = (from P in dronesList
                              where P.ID == id
                              select P).FirstOrDefault();

        if (PReturn.Equals(default(DO.Product)))
            throw new Exception("the Product doesn't exist");

        return PReturn;
    }
    public int ADD(DO.Product p)
    {
        if (p.ID != 0)
        {
            XElement ProductRoot = XElement.Load(filePath);  //get all the elements from the file

            //check if the customer exists in th file
            var ProductTemp = (from customer in ProductRoot.Elements()
                               where (customer.Element("ID").Value == p.ID.ToString())
                               select customer).FirstOrDefault();
            //throw an exception
            if (ProductTemp != null)
                throw new Exception("the product already exit");
            //add the customer to the root element
            ProductRoot.Add(
                new XElement("Product",
                new XElement("ID", p.ID),
                new XElement("Category", p.Category),
                new XElement("Print", p.Print),
                new XElement("Price", p.Price),
                new XElement("InStock", p.InStock)));
            //save the root in the file
            try
            {
                ProductRoot.Save(filePath);
                return p.ID;
            }
            catch (Exception ex)
            {
                throw new Exception("couldnt load the file");
            }
        }
        else
        {
            return 1;// להחזיר מספר רץ
        }
        // XmlTools.SaveListToXMLElement(customerRoot, customerPath);
    }

    public void DELETE(int id)
    {

        using FileStream file = new FileStream(filePath, FileMode.Open);
        XmlSerializer x = new XmlSerializer(typeof(List<DO.Product>), new XmlRootAttribute("Products"));
        List<DO.Product> pList;
        pList= x.Deserialize(file) as List<DO.Product>;
        file.Close();
        DO.Product p = new DO.Product();
        p = GET(id);
        try
        {   
            pList.RemoveAll(x=>x.ID==id);
            using FileStream file1 = new FileStream(filePath, FileMode.Create);
            XmlSerializer x1 = new XmlSerializer(typeof(List<DO.Product>), new XmlRootAttribute("Products"));
            x1.Serialize(file1, pList);
            file1.Close();
        }
        catch (Exception)
        {
            throw new Exception("Product does not exist");
        }
    }
}