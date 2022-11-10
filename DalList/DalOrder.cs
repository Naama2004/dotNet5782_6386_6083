
using DalApi;
using DO;

namespace DAL;

public struct DalOrder : ICrud<Order>
{
    public void ADD(Order O)
    {
        DataSource.orders.Add(O);
    }

    public void DELETE(int id)
    {
        Order OrderNULL = new Order();//דרך להחזיר אם לא נמצא 
        OrderNULL.ID = 0;
        foreach (Order O in DataSource.orders)
        {
            if (O.ID == id)
                DataSource.orders.Remove(O);
        }
    }

    public Order GET(int id)//should be static?
    {
        Order OrderNULL = new Order();//דרך להחזיר אם לא נמצא 
        OrderNULL.ID = 0;
        foreach (Order O in DataSource.orders)
        {
            if (O.ID == id)
                return O;
        }
        return OrderNULL; ;
    }

    public void UPDATE(Order entity)
    {
        DELETE(entity.ID);
        ADD(entity);
        

    }
}
