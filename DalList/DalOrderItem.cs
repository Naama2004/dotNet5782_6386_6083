

using DalApi;
using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrderItem : IOrderItem
{
    public int ADD(OrderItem OI)
    {
        if (OI.ID != 0)
        {
            if (ordersItems.Exists(x => x?.ID == OI.ID))
                throw new ExistIdException("this order item already exist");
            ordersItems.Add(OI);
            return OI.ID;
        }
        else
        {
            OI.ID = config.NextOI;
            return OI.ID;
        }


    }

    public void DELETE(int id)
    { 
        if (ordersItems.RemoveAll(x => x?.ID == id) == 0)
            throw new UnfounfException("cant delete a no existing item");

    }

    public OrderItem GET(int id)
    {
        return ordersItems.FirstOrDefault(x => x?.ID == id)
                  ?? throw new UnfounfException("id not found");
    }

    public void UPDATE(OrderItem entity)
    {
        DELETE(entity.ID);
        ADD(entity);
    }

    public OrderItem GetByOrderAndProduct(int OID, int PID)
    {
        return ordersItems.Find(x => x?.OrderID == OID && x?.ProductID == PID)
            ?? throw new UnfounfException("the  order item was not found");

    
    }

    public IEnumerable<OrderItem> GetAll()
    {
        return (from OrderItem item in DataSource.ordersItems select item);
    }
}
