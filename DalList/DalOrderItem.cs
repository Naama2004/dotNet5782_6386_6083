

using DalApi;
using DO;
using static DAL.DataSource;

namespace DAL;

public class DalOrderItem : ICrud<OrderItem>
{
    public void ADD(OrderItem OI)
    {

            if (DataSource.ordersItems.BinarySearch(OI) == 1)
            {
                throw new ExistIdException("this order already exist");
            }
            DataSource.ordersItems.Add(OI);

    }

    public void DELETE(int id)
    {
        
        foreach (OrderItem P in ordersItems)
        {
            if (P.ID == id)
                ordersItems.Remove(P);
        }
    }

    public OrderItem GET(int id)
    {
        //return DataSource.ordersItems.Find(x=>x.Value.ID==id);

        foreach (OrderItem OI in ordersItems)
        {
            if (OI.ID == id)
                return OI;
        }
        throw new UnfounfException(" id not found");
    }

    public void UPDATE(OrderItem entity)
    {
        GET(entity.ID);
        DELETE(entity.ID);
        ADD(entity);
    }

    public OrderItem GetByOrderAndProduct(int OID, int PID)
    {
        foreach(var OI in DataSource.ordersItems)
        {
            OrderItem result = DataSource.ordersItems.Find(x => (x.Value.OrderID == OID && x.Value.ProductID == PID)); 
            return result;
        }
        throw new UnfounfException("the item was not found");
    }

    public IEnumerable<OrderItem> GetAll()
    {
        return (from OrderItem item in DataSource.ordersItems select item).ToList();
    }
}
