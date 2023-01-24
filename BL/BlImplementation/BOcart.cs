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
    public BO.cart addProduct(BO.cart C, int ProductID, int amount)
    {
        try
        {
            DO.Product PDetails = factor!.Product.GET(ProductID);
            C.items = C.items ?? new();
            if (PDetails.InStock > amount)
            {
                BO.OrderItem item = C.items.FirstOrDefault(x => x.ProductId == ProductID) ?? new()
                {
                    ProductId = ProductID,
                    OrderId = 0,
                    price = PDetails.Price,
                    Print = PDetails.Print,
                    amount = amount,
                    TotalPrice = amount * PDetails.Price
                };
                C.items.Add(item);
                C.price += item.TotalPrice;
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
            throw new InValidIdException("the new amount can not be negative");
        
        try
        {
            C.items = C.items ?? new();
            BO.OrderItem temp = C.items?.FirstOrDefault(x => x.ProductId == ID) 
                ?? throw new Exception("product is not in the cart");
            if (newAmount == 0)
            {
                C.price -= temp?.TotalPrice;
                C.items.Remove(temp!);
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
                if (factor!.Product.GET(ID).InStock < newAmount)
                    throw new Exception();
                BO.OrderItem UpdatesOrderItem = copyOrderItem(temp);
                UpdatesOrderItem.amount = newAmount;
                UpdatesOrderItem.TotalPrice = newAmount * UpdatesOrderItem.price;
                C.price -= temp.TotalPrice;
                C.items.Remove(temp);
                C.items.Add(UpdatesOrderItem);
                C.price += UpdatesOrderItem.TotalPrice;
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
    public int OrderConfirm(BO.cart c)
    {
        DO.Order newOrder = new DO.Order();
        int idOfOrder = factor!.Order.ADD(newOrder);
        newOrder.ID = idOfOrder;
        newOrder.OrderDate = DateTime.Now;
        newOrder.ShipDate = null;
        newOrder.DeliveryDate = null;
        newOrder.CustomerAddress = c.CustomerAddres;
        newOrder.CustomerEmail = c.CustomerEmail;
        newOrder.CustomerName = c.CustomerName;

        c.items = c.items ?? new();
        foreach (var item in c.items)
        {
            DO.Product product = factor.Product.GET((int)item.ProductId!);
            if (product.InStock - item.amount < 0)
                throw new Exception("we couldnt approve your order");

            DO.Product update = product;
            update.InStock = product.InStock - item.amount;
            factor.Product.UPDATE(update);

            
            DO.OrderItem newOrderItem = new DO.OrderItem()
            {
                ProductID = product.ID,
                OrderID = idOfOrder,
                Price = item.price,
                Amount = item.amount,
            };
            newOrderItem.ID = factor.OrderItem.ADD(newOrderItem);
             factor.OrderItem.ADD(newOrderItem);
        }
        factor.Order.ADD(newOrder);
        return idOfOrder;
    }

    #endregion
    public void EmptyCart(BO.cart C)
    {
        C.items = null; 
        C.price = 0;
        

    }
    public IEnumerable<BO.OrderItem> getCartList(BO.cart C)
    {
        return (from P in C.items
                        select P)?? throw new NotFoundException("the cart is empty");
        //else
        //  throw new NotFoundException("the cart is empty");
    }

    public BO.cart DeleteProduct(BO.cart C, int ProductID)
    {


        C.items = C.items ?? throw new Exception("the cart is empty");
       BO.OrderItem help=C.items.Find(x=>x.ProductId== ProductID)
            ?? throw new NotFoundException("the product is not in the cart");
       C.items.Remove(help);
                    return C;
    }


}

































