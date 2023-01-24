
using DalApi;
using DO;
using System.Data;
using static Dal.DataSource;

namespace Dal;

public class DalOrder :IOrder 
{
    public int ADD(Order O)
    {
        if (O.ID != 0)
        {
            if (orders.Exists(x => x?.ID == O.ID))
                throw new ExistIdException("this order already exist");
            orders.Add(O);
            return O.ID;
        }
        else
        {
            O.ID = config.NextO;
            return O.ID;
        }
    }

    public void DELETE(int id)
    {

        if (orders.RemoveAll(x => x?.ID == id) == 0)
            throw new UnfounfException("cant delete a no existing item");

    }

    public Order GET(int id)//should be static?
    {
     
        return orders.FirstOrDefault(x => x?.ID == id)
                    ?? throw new UnfounfException("id not found");
    }

    public void UPDATE(Order entity)
    {
        
        DELETE(entity.ID);
        ADD(entity);
    }
    public IEnumerable<Order> GetAll()
    {
        return (from Order order in orders
                select order);
    }



}
