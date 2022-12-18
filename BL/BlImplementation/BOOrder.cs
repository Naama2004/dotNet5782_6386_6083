
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BO;

//using DAL;
//using DO;

namespace BlImplementation;

public class BOOrder : IOrder
{
    DalApi.IDal? factor = DalApi.Factory.Get();
    #region get all aorders
    public IEnumerable<BO.OrderForList> GETOrders()
    {

        List<DO.Order> tempDOList = factor.Order.GetAll().ToList();//copy the entire order list in DO to temp DO list 

        return (from O in tempDOList//returns a IEnumerable of orderitems 
                select new BO.OrderForList()
                {//update the O to be  a BO ordertiem
                    OrderId = O.ID,
                    state = FindState(O),
                    Amount = TotalProductsAmount(O.ID),
                    TotalPrice = TotalPrice(O.ID)
                });
    }
    #endregion

    #region get order info
    public BO.Order GetOrderInfo(int id)
    {
        if (id > 0)

        {

            try
            {

                List<DO.OrderItem> tempList = factor.OrderItem.GetAll().ToList();

                DO.Order wantedOrder = factor.Order.GET(id);
                BO.Order returnOrder = new BO.Order();
                returnOrder.Id = wantedOrder.ID;
                returnOrder = copyvalues(wantedOrder);
                returnOrder.Items = getallorderItem(id);
                returnOrder.State = FindState(wantedOrder);
                returnOrder.price = TotalProductsAmount(id);
                return returnOrder;
            }
            catch (DO.UnfounfException ex) 
            {
                throw new NotFoundException("the order was not found", ex);
                //if Get threw an Exeption - the order wasnt found catch it and throw an Exeption 
            }

        }
        throw new InValidIdException("the id is not valid");
        //if the id isnt valid throws an Exepsion 

    }
    #endregion
    #region update ship // חסרה זריקה 
    public BO.Order UpdateShip(int id)
    {
        try
        {

            DO.Order temp = factor.Order.GET(id);//find the wanted order
            if (DateTime.Today < temp.ShipDate)
            {
                //updating the DO entity
                DO.Order updatedDO = new DO.Order();
                updatedDO.ID = temp.ID;
                updatedDO.CustomerEmail = temp.CustomerEmail;
                updatedDO.CustomerAddress = temp.CustomerAddress;
                updatedDO.CustomerName = temp.CustomerName;
                updatedDO.OrderDate = temp.OrderDate;
                updatedDO.DeliveryDate = temp.DeliveryDate;
                updatedDO.ShipDate = DateTime.Today;
                factor.Order.UPDATE(updatedDO);
                //return an updated BO entity
                BO.Order updatedBO = copyvalues(updatedDO);
                updatedBO.Items = getallorderItem(id);
                updatedBO.State = FindState(updatedDO);
                updatedBO.price = TotalPrice(id);
                return updatedBO;
            }
            else
            {
                throw new Exception();//צריך להחזיר משהו לא הצלחתי להבין מה
            }

        }
        catch(DO.UnfounfException ex)
        {
            throw new NotFoundException("the order was not found", ex);
        }
        //catch : if GET couldnt find 
        //catch: updatet couldnt delete because it does ot exist


    }
    #endregion

    #region update delivery // חסרה זריקה
    public BO.Order UpdateDelivery(int id)
    {
        try
        {

            DO.Order temp = factor.Order.GET(id);//find the wanted order
            if (FindState(temp) == BO.Enums.State.send)
            {
                //updating the DO entity
                DO.Order updatedDO = new DO.Order();
                updatedDO.ID = temp.ID;
                updatedDO.CustomerEmail = temp.CustomerEmail;
                updatedDO.CustomerAddress = temp.CustomerAddress;
                updatedDO.CustomerName = temp.CustomerName;
                updatedDO.OrderDate = temp.OrderDate;
                updatedDO.DeliveryDate = DateTime.Today;
                updatedDO.ShipDate = temp.ShipDate;
                factor.Order.UPDATE(updatedDO);
                //return an updated BO entity
                BO.Order updatedBO = copyvalues(updatedDO);
                updatedBO.Items = getallorderItem(id);
                updatedBO.State = FindState(updatedDO);
                updatedBO.price = TotalPrice(id);
                return updatedBO;
            }
            else
            {
                throw new Exception();//צריך להחזיר משהו לא הצלחתי להבין מה
            }

        }
        catch (DO.UnfounfException ex)
        {
            throw new NotFoundException("the order was not found", ex);
        }
        //catch : if GET couldnt find 
        //catch: updatet couldnt delete because it does ot exist


    }
    #endregion

    #region track order // לא גמור
    public BO.OrderTracking trackOrder(int ID)
    {
        try
        {
            DO.Order help = factor.Order.GET(ID);
            BO.OrderTracking returnOrderTracking = new BO.OrderTracking();
            returnOrderTracking.OrderId = ID;
            returnOrderTracking.State = FindState(help);
            //put the tuple
            //
            //
            //
            //
            //
            //
            //

            return returnOrderTracking;
        }
        catch (DO.UnfounfException ex)
        {
            throw new NotFoundException("the order was not found", ex);
        }
        //catch if get throws


    }

    #endregion


    #region copy values
    public BO.Order copyvalues(DO.Order d)
    {
        BO.Order b = new BO.Order();
        b.Id = d.ID;
        b.CustomerName = d.CustomerName;
        b.CustomerEmail = d.CustomerEmail;
        b.OrderDate = d.OrderDate;
        b.ShipDate = d.ShipDate;
        b.DeliveryDate = d.DeliveryDate;
        b.CustomerAddres = d.CustomerAddress;
        return b;


    }
    #endregion

    #region find state
    public BO.Enums.State FindState(DO.Order O)
    {
        if (DateTime.Today >= O.OrderDate && DateTime.Today < O.ShipDate)
            return BO.Enums.State.approved;
        if (DateTime.Today >= O.ShipDate && DateTime.Today < O.DeliveryDate)
            return BO.Enums.State.send;
        if (DateTime.Today >= O.DeliveryDate)
            return BO.Enums.State.provided;
        throw new Exception("check");
    }
    #endregion

    #region total poduct amount
    public int TotalProductsAmount(int ID)
    {
        int total = 0;
        List<DO.OrderItem> temp = factor.OrderItem.GetAll().ToList();
        foreach (DO.OrderItem item in temp)
        {
            if (item.ID == ID)
                total += (int)item.Amount;

        }
        return total;

    }
    #endregion

    #region total price
    public Double TotalPrice(int ID)
    {
        Double total = 0;
        List<DO.OrderItem> temp = factor.OrderItem.GetAll().ToList();
        foreach (DO.OrderItem item in temp)
        {
            if (item.ID == ID)
                total += (Double)item.Price;

        }
        return total;

    }
    #endregion

    #region get all order utems
    public List<BO.OrderItem>? getallorderItem(int ID)
    {
        List<DO.OrderItem> tempDolist = factor.OrderItem.GetAll().ToList();

        return (from O in tempDolist
                where O.OrderID == ID
                select new BO.OrderItem()
                {
                    OrderId = ID,
                    ProductId = O.ProductID,
                    price = O.Price,
                    amount = O.Amount,
                    TotalPrice = O.Price * O.Amount,
                    ProductName = factor.Product.GET((int)O.ProductID).Name
                }).ToList();
    }
    #endregion


}
