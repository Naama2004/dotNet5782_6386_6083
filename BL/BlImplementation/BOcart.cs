using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using BLApi;
using BO;
using DalApi;
using DO;
namespace BlImplementation;

public class BOcart : ICart
{
    DalApi.IDal? factor = DalApi.Factory.Get();
    #region add product to cart
    public BO.cart addProduct(BO.cart C, int ProductID)
    {
        try
        {
            DO.Product PDetails = factor!.Product.GET(ProductID);
            C.items = C.items ?? new();
            if (PDetails.InStock > 0)
            {
                BO.OrderItem item = C.items.FirstOrDefault(x => x.ProductId == ProductID) ?? new()
                {
                    ProductId = ProductID,
                    OrderId = 0,
                    price = PDetails.Price,
                    Print = PDetails.Print,
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
                throw new NotInStockException("there is not enough in stock");
            }
        }
        catch(ExistIdException ex)
        {
            throw new IdExistException("id already exist", ex);
        }
    }
    #endregion

    #region update amount in cart
    public BO.cart updateAmountInCart(BO.cart C, int ID, int newAmount)

    {
        if(newAmount < 0)
        {
            throw new InValidIdException("the new amount can not be negative");
        }
        try
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
        }
        catch (UnfounfException ex)
        {
            throw new NotFoundException("the product id was not found",ex);
        }

    }
    #endregion

    #region copy all order items
    public BO.OrderItem copyOrderItem(BO.OrderItem from)
    {
        BO.OrderItem TO = new BO.OrderItem();
        TO.price = from.price;
        TO.amount = from.amount;
        TO.TotalPrice = from.amount * from.price;
        TO.OrderId = from.OrderId;
        TO.Print = from.Print;
        TO.ProductId = from.ProductId;
        return TO;
    }
    #endregion

    #region approves order or makes a new one
    public bool OrderConfirm(BO.cart c)
    {
        //data tast
        if ((!c.CustomerEmail.Contains('@')) || (c.CustomerName == "") || (c.CustomerAddres == ""))
            throw new InValidIdException("the data is not valid");

        DO.Order newOrder = new DO.Order();

        int idOfOrder = factor.Order.ADD(newOrder);//return the id of the new order
        if (idOfOrder < 0)
            throw new InValidIdException();
        newOrder.OrderDate = DateTime.Now;
        newOrder.ShipDate = null;
        newOrder.DeliveryDate = null;

        foreach (var item in c.items)
        {
            //check if the product is in stock
            DO.Product product = (DO.Product)factor.Product.GET(idOfOrder);
            if (product.InStock - item.amount < 0)
                return false;
            //if the produt in stock so add to order
            DO.OrderItem newOrderItem = new DO.OrderItem()
            {

                ProductID = product.ID,
                OrderID = item.OrderId,
                Price = item.price,
                Amount = item.amount,
                ID = idOfOrder
            };

            factor.OrderItem.ADD(newOrderItem);
        }
        Console.WriteLine("your order number is : " + idOfOrder);
        return true;
    }
    #endregion
}

































