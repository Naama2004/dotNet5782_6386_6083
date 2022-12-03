using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using BLApi;



namespace BlImplementation;

public class BOProduct : IProduct
{
    public IEnumerable<BO.ProductForList> GetProducts()
    {
        DAL.DalProduct product = new DAL.DalProduct();
        List<DO.Product> doproductList = product.GetAll().ToList();
        return (from P in doproductList
                let productFromBl = product.GET(P.ID)
                select new BO.ProductForList()
                {
                    ProductId = P.ID,
                    ProductName = productFromBl.Name,
                    price = P.Price, 
                    Category=(BO.Enums.Category)P.Category,
                }).ToList();
    }


    public BO.Product ProductInfomaneger(int id)// menager
    {
        if (id > 0)
        {
            DAL.DalProduct product = new DAL.DalProduct();

            DO.Product productDO = product.GET(id);
            BO.Product productBO = new BO.Product();
            productBO.ID = productDO.ID;
            productBO.Name = productDO.Name;
            productBO.Price = productDO.Price;
            productBO.category = (BO.Enums.Category)productDO.Category;
            productBO.instock = productDO.InStock;
            return productBO;
        }
        throw new Exception();
        // זריקה 
    }

    public void AddProductmaneger(BO.Product P)
    {
        if(P.ID > 0 && P.Name!=" " && P.Price>0 && P.instock>=0)
        {
            DO.Product DOp = new DO.Product();
            DOp.ID = P.ID;
            DOp.Name = P.Name;  
            DOp.Price = P.Price;
            DOp.InStock = P.instock;
            DAL.DalProduct product = new DAL.DalProduct();
            try
            {
                product.ADD(DOp);
            }
            catch
            {
                // תפיסת חריגה כלשהי
                // נראה לי  שצריך גם לזרוק פה
            }
        }
    }

    public void RemoveProductmaneger(int id )
    {
        // בדיקה שהמוצר ךא מופיע באף הזמנה
        //אם עבד
        DAL.DalProduct product = new DAL.DalProduct();
        try
        {
            product.DELETE(id);
        }
        catch
        {
            //תפיסה אם לא הצליח למחוק 
            //נראה לי גם זריקה אם לא הצליח למחוק
        }
    }

    public void UpdateProductmaneger(BO.Product P)
    {
        if (P.ID > 0 && P.Name != " " && P.Price > 0 && P.instock >= 0)
        {
            DAL.DalProduct product = new DAL.DalProduct();
            DO.Product DOp = new DO.Product();
            DOp.ID = P.ID;
            DOp.Name = P.Name;
            DOp.Price = P.Price;
            DOp.InStock = P.instock;
            try
            {
                product.UPDATE(DOp);
            }
            catch
            {
                //תפיסת החריגה
                //
            }
        }
    }


}
        

