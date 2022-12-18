using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using BLApi;
using BO;
using DO;
namespace BlImplementation;

public class BOcart : ICart
{
    DalApi.IDal? factor = DalApi.Factory.Get();
    public BO.cart addProduct(BO.cart C, int id)
    {
        DO.Product PDetails = factor.Product.GET(id);
        C.items = C.items ?? new();
        if (PDetails.InStock > 0)
        {
            BO.OrderItem item = C.items.FirstOrDefault(x => x.ProductId == id) ?? new()
            {
                ProductId = id,
                OrderId = 0,
                price = PDetails.Price,
                ProductName = PDetails.Name,
                amount = 0,
                TotalPrice = 0
            };


            //item is a new one OR Exsisting one 

            item.amount++;
            item.TotalPrice += item.price;
            C.items.Add(item);
            C.price += item.price;
            return C;
        }
        else
        {
            throw new Exception("there is not enough in stock");
        }

        //else
        //throw not in stock 
        




    }

    #region update amount in cart
    public BO.cart updateAmountInCart(BO.cart C, int ID, int newAmount)

    {
        C.items = C.items ?? new();
        BO.OrderItem temp = C.items?.FirstOrDefault(x => x.ProductId == ID) ?? throw new Exception("product is not in the cart");
        if (newAmount == 0)// which means to delete this orderitem from the cart 
        {
            C.price -= temp?.TotalPrice;
            C.items.Remove(temp);
            return C;
        }
        if (newAmount < temp.amount)
        {
            BO.OrderItem UpdatesOrderItem = copyOrderItem(temp);
            UpdatesOrderItem.amount = newAmount;
            UpdatesOrderItem.TotalPrice = newAmount * UpdatesOrderItem.price;
            C.price -= temp.TotalPrice;
            C.items.Remove(temp);
            C.items.Add(UpdatesOrderItem);
            C.price += UpdatesOrderItem.TotalPrice;
            return C;
        }
        if (newAmount > temp.amount)
        {
            if (factor.Product.GET(ID).InStock < newAmount)//if there is not enough in stock
                throw new Exception();//אין מספיק בסטוק
            BO.OrderItem UpdatesOrderItem = copyOrderItem(temp);
            UpdatesOrderItem.amount = newAmount;
            UpdatesOrderItem.TotalPrice = newAmount * UpdatesOrderItem.price;
            C.price -= temp.TotalPrice;
            C.items.Remove(temp);
            C.items.Add(UpdatesOrderItem);
            C.price += UpdatesOrderItem.TotalPrice;//update the cart price to the new correct one 
            return C;

        }
        throw new InValidIdException("the amount was not valid");

        //throw invalid amount 
    }
    #endregion
    public BO.OrderItem copyOrderItem(BO.OrderItem from)
    {
        BO.OrderItem TO = new BO.OrderItem();
        TO.price = from.price;
        TO.amount = from.amount;
        TO.TotalPrice = from.amount * from.price;
        TO.OrderId = from.OrderId;
        TO.ProductName = from.ProductName;
        TO.ProductId = from.ProductId;
        return TO;
    }
    public void OrderConfirm(BO.cart c)
    {
        c.items = c.items ?? new();
        List<DO.Product> Plist = factor.Product.GetAll().ToList();
        foreach (BO.OrderItem OI in c.items)
        {
            if (OI.amount > Plist.FirstOrDefault(x => x.ID == OI.ProductId).InStock)
                throw new Exception(" not anough products in stock");
        }
        if (c.CustomerName == null)
            throw new Exception(" missing costmer name");
        if (c.CustomerAddres == null)
            throw new Exception(" missing costmer adress");

        //check Email
        BO.Order returnorder = new BO.Order();
        returnorder.price = c.price;
        returnorder.CustomerName = c.CustomerName;
        returnorder.CustomerAddres = c.CustomerAddres;
        returnorder.CustomerEmail = c.CustomerEmail;
        returnorder.OrderDate = DateTime.Now;
        returnorder.ShipDate = null;
        returnorder.DeliveryDate = null;
        //לקבל מספר הזמנה בחזכה




    }





}

































