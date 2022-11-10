

using DalApi;
using DO;
using static DAL.DataSource;

namespace DAL;

public class DalOrderItem : ICrud<OrderItem>
{
    public void ADD(OrderItem OI)
    {
        DataSource.ordersItems.Add(OI);
    }

    public void DELETE(int id)
    {
        OrderItem OrderNULL = new OrderItem();//דרך להחזיר אם לא נמצא 
        OrderNULL.ID = 0;
        foreach (OrderItem P in ordersItems)
        {
            if (P.ID == id)
                ordersItems.Remove(P);
        }
    }

    public OrderItem GET(int id)
    {
        OrderItem OrderItemNULL = new OrderItem();//דרך להחזיר אם לא נמצא 
        OrderItemNULL.ID = 0;
        foreach (OrderItem OI in ordersItems)
        {
            if (OI.ID == id)
                return OI;
        }
        return OrderItemNULL;
    }

    public void UPDATE(OrderItem entity)
    {
        DELETE(entity.ID);
        ADD(entity);
    }
}
