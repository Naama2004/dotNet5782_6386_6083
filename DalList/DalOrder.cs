
using DalApi;
using DO;
using System.Data;

namespace DAL;

public struct DalOrder : ICrud<Order>
{
    public void ADD(Order O)
    {
            if (DataSource.orders.BinarySearch(O) == 1)
            {
                throw new ExistIdException("this order already exist");
            }
            DataSource.orders.Add(O);
    }

    public void DELETE(int id)
    {

        //DataSource.orders.RemoveAll(x => x.ID == id);

        foreach (Order O in DataSource.orders)
        {
            if (O.ID == id)
                DataSource.orders.Remove(O);
        }

    }

    public Order GET(int id)//should be static?
    {
        //return DataSource.orders.Find(x=>x.Value.ID == id);//הפיינד מחזיר נלאבל אז צריך לטפל בזה 
        foreach (Order O in DataSource.orders)
        {
            if (O.ID == id)
                return O;
        }
        throw new UnfounfException(" id not found");


    }

    public void UPDATE(Order entity)
    {
        GET(entity.ID);//the GET will throw in case it does not exist
        DELETE(entity.ID);
        ADD(entity);
    }
    public IEnumerable<Order> GetAll()
    {
        return (from Order order in DataSource.orders select order).ToList();
    }
}
