
using DalApi;
using DO;
using System.Data;

namespace DAL;

public class DalOrder :IOrder /*ICrud<Order>*/
{
    public void ADD(Order O)
    {
        if (DataSource.orders.Exists(x => x?.ID == O.ID))//if it exist returns true O is alredy in the list
            throw new ExistIdException("this product already exist");
        DataSource.orders.Add(O);//if the product isnt already in the list , adds it . 



        //if (DataSource.orders.Exists(x => x.Value.ID == O.ID))
        //{
        //    throw new ExistIdException("this product already exist");
        //}
        //DataSource.orders.Add(O);
    }

    public void DELETE(int id)
    {
        //if the function finds the order it removes it , if not it returns 0 and the code throws an exeption.
        if (DataSource.orders.RemoveAll(x => x?.ID == id) == 0)
            throw new UnfounfException("cant delete a no existing item");

        ////DataSource.orders.RemoveAll(x => x.ID == id);

        //foreach (Order O in DataSource.orders)
        //{
        //    if (O.ID == id)
        //        DataSource.orders.Remove(O);
        //}

    }

    public Order GET(int id)//should be static?
    {
        Order? help = DataSource.orders.FirstOrDefault(x => x?.ID == id);
        if (help != null)//if the product exist in the list , return it
            return (Order)help;
        else//first or default returned null which means the product doesnt exist 
            throw new UnfounfException(" id not found");



        ////return DataSource.orders.Find(x=>x.Value.ID == id);//הפיינד מחזיר נלאבל אז צריך לטפל בזה 
        //foreach (Order O in DataSource.orders)
        //{
        //    if (O.ID == id)
        //        return O;
        //}
        //throw new UnfounfException(" id not found");


    }

    public void UPDATE(Order entity)
    {
        //GET(entity.ID);//the GET will throw in case it does not exist
        DELETE(entity.ID);//the Delete function will throw an exeption if it does not exist 
        ADD(entity);
    }
    public IEnumerable<Order> GetAll()
    {
        return (from Order order in DataSource.orders select order).ToList();
    }
    
}
