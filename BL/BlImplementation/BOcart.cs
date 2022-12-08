using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using BLApi;


namespace BlImplementation;

public class BOcart : ICart
{
    public BO.cart addProduct(BO.cart C, int id)
    {
        BO.OrderItem? OI = C.items?.Find(x => x.ProductId == id); 
        {
            if(OI == null)//if the product is NOT already in the cart 
            {
                DO.Product productTemp=new DO.Product();
                List<DO.Product> help = productTemp.GetAll().ToList();

                productTemp = help.Find(x=>x.ID==id);
                if (productTemp.ID== id && productTemp.InStock > 0)//the product is in DO and in stock 
                {
                    OI.ProductId=productTemp.ID;
                    OI.price=productTemp.Price;
                    OI.ProductName = productTemp.Name;
                    //OI.OrderId=
                    OI.amount = 1;
                    OI.TotalPrice = productTemp.Price;//there is only one of that kind 
                    OI.price = productTemp.Price;
                    //creates an entity to add
                    C.items?.Add(OI);
                    //if add throws an exeption chatch it 


     

                }




            }
            else//the product is in the cart 
            {
                //does it actuallt change the cart ?
                from P in C.items
                where P.ProductId == id
                select new BO.OrderItem
                 {
                    // P.amount++;
                  //P.totslprice = ...


                 }
                

            }











        }
       //else
       //throws an Exeption the product is already in the cart 
      

    }
}












































//        //bool flag = false;
//        //foreach (BO.OrderItem? P in C.items)// האם צריך להשתמש בלינק
//        //{
//        //    if (P.ProductId==id)
//        //    {
//        //         flag = true;
//        //        break;
//        //    }
//        //}
//        //DAL.DalProduct product = new DAL.DalProduct();
//        //try
//        //{
//        //    DO.Product productDO = product.GET(id);
//        //    if (!flag)
//        //    {
//        //        if (productDO.InStock > 0)
//        //        {
//        //            BO.OrderItem orderItem = new BO.OrderItem();
//        //            orderItem.OrderId = 0;
//        //            orderItem.ProductId = id;
//        //            orderItem.price = productDO.Price;
//        //            orderItem.amount = 1;
//        //            orderItem.TotalPrice = orderItem.amount * productDO.Price;
//        //            C.items.Add(orderItem);
//        //            C.price += orderItem.TotalPrice;
//        //        }
//        //        // אולי זריקה לוידעת

//        //    }
//        //    else
//        //    {
//        //        if (productDO.InStock > 0)//צריך לבדוק מספיק אבל אין לי מושג כמה צריך
//        //        {
//        //            foreach (BO.OrderItem? P in C.items)
//        //            {
//        //                if (P.ProductId == id)
//        //                {
//        //                    P.amount += 1;
//        //                    P.TotalPrice += P.price;
//        //                    break;
//        //                }
//        //                C.price += P.price;
//        //            }
//        //        }
//        //        // אולי זריקה לוידעת 

//        //    }
//        //    return C;
//        //}
//        //catch
//        //{
//        //    //תפיסת הזריקה 
//        //    // ונראה לי גם זריקה כי לא החזרנו עגלה 
//        //}
//    }

//    public BO.cart UpdatePAmount(BO.cart C, int id, int amount)// עבור מסך קניות
//    {
//        foreach (BO.OrderItem? P in C.items)// האם צריך להשתמש בלינק
//        {
//            if (P.ProductId == id)
//            {
//                if (amount != P.amount)//the amount of the product in the cart has changed 
//                {
//                    if (amount != 0)//its bigger or samller then the currnt amount
//                    {
//                        P.amount = amount;
//                        P.TotalPrice = P.price * amount;

//                    }
//                    else//the new amount is 0
//                    {
//                        C.items.Remove(P);
//                    }

//                }
//            }
//            break; //אם לא מצא את הפרודקט חריגה
//        }
//        return C;
//    }


//}
////public BO.cart confirmCart(BO.cart C)


