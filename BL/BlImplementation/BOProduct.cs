//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//using BLApi;
////using DalApi;
//namespace BlImplementation;

//public class BOProduct : IProduct
//{
//    DalApi.IDal? p = DalApi.Factory.Get();

//    public IEnumerable<BO.ProductForList> GetProducts()
//    {
//        //DAL.DalProduct product = new DAL.DalProduct();
//        List<DO.Product> doproductList = p.Product.GetAll().ToList();/*GetAll().ToList();*/
//        return (from P in doproductList
//                let productFromBl = p.Product.GET(P.ID)
//                select new BO.ProductForList()
//                {
//                    ProductId = P.ID,
//                    ProductName = productFromBl.Name,
//                    price = P.Price,
//                    Category = (BO.Enums.Category)P.Category,
//                }).ToList();
//    }


//    public BO.Product ProductInfomaneger(int id)// menager
//    {
//        if (id > 0)
//        {
//            //DAL.DalProduct product = new DAL.DalProduct();

//            DO.Product productDO = p.Product.GET(id);
//            BO.Product productBO = new BO.Product();
//            productBO.ID = productDO.ID;
//            productBO.Name = productDO.Name;
//            productBO.Price = productDO.Price;
//            productBO.category = (BO.Enums.Category)productDO.Category;
//            productBO.instock = productDO.InStock;
//            return productBO;
//        }
//        throw new Exception();
//        // זריקה 
//    }

//    public void AddProductmaneger(BO.Product P)
//    {
//        if (P.ID > 0 && P.Name != " " && P.Price > 0 && P.instock >= 0)
//        {
//            DO.Product DOp = new DO.Product();
//            DOp.ID = P.ID;
//            DOp.Name = P.Name;
//            DOp.Price = P.Price;
//            DOp.InStock = P.instock;

//            //DAL.DalProduct product = new DAL.DalProduct();
//            try
//            {
//                p.Product.ADD(DOp);
//            }
//            catch
//            {
//                // תפיסת חריגה כלשהי
//                // נראה לי  שצריך גם לזרוק פה
//            }
//        }
//    }

//    public void RemoveProductmaneger(int id)
//    {
//        // בדיקה שהמוצר ךא מופיע באף הזמנה
//        //אם עבד

//        //DAL.DalProduct product = new DAL.DalProduct();
//        try
//        {
//            p.Product.DELETE(id);
//        }
//        catch
//        {
//            //תפיסה אם לא הצליח למחוק 
//            //נראה לי גם זריקה אם לא הצליח למחוק
//        }
//    }

//    public void UpdateProductmaneger(BO.Product P)
//    {
//        if (P.ID > 0 && P.Name != " " && P.Price > 0 && P.instock >= 0)
//        {

//            //DAL.DalProduct product = new DAL.DalProduct();
//            DO.Product DOp = new DO.Product();
//            DOp.ID = P.ID;
//            DOp.Name = P.Name;
//            DOp.Price = P.Price;
//            DOp.InStock = P.instock;
//            try
//            {
//                p.Product.UPDATE(DOp);
//            }
//            catch
//            {
//                //תפיסת החריגה
//                //
//            }
//        }
//    }

//    public IEnumerable<BO.ProductForList> GetProductsByCategory(BO.Enums.Category category)
//    {

//        //DAL.DalProduct product = new DAL.DalProduct();
//        List<DO.Product> doproductList = p.Product.GetAll().ToList();
//        return (from P in doproductList
//                    // let productFromBl = product.GET(P.ID)
//                where P.Category == (DO.Enums.Category)category
//                select new BO.ProductForList()
//                {
//                    ProductId = P.ID,
//                    ProductName = P.Name,
//                    price = P.Price,
//                    Category = (BO.Enums.Category)P.Category,
//                }).ToList();
//    }
//    //זריקה אם הקטגוריה אינה קיימת

//}


