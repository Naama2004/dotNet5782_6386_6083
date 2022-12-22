

using DalApi;
using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrderItem : IOrderItem/*ICrud<OrderItem>*/
{
    public int ADD(OrderItem OI)
    {
        if (OI.ID != 0)
        {
            if (DataSource.ordersItems.Exists(x => x?.ID == OI.ID))//is exist returns true OI is alredy in the list
                throw new ExistIdException("this order item already exist");
            DataSource.ordersItems.Add(OI);//if the orderitem isnt already in the list , adds it 
            return OI.ID;
        }
        else
        {
            OI.ID = config.NextOI;
            return OI.ID;   
        }





        //if (DataSource.ordersItems.Exists(x => x.Value.ID == OI.ID))
        //{
        //    throw new ExistIdException("this product already exist");
        //}
        //DataSource.ordersItems.Add(OI);

    }

    public void DELETE(int id)
    {
        //if the function finds the order item it removes it , if not it returns 0 and the code throws an exeption.
        if (DataSource.ordersItems.RemoveAll(x => x?.ID == id) == 0)
            throw new UnfounfException("cant delete a no existing item");




        //foreach (OrderItem P in ordersItems)
        //{
        //    if (P.ID == id)
        //        ordersItems.Remove(P);
        //}
    }

    public OrderItem GET(int id)
    {
        OrderItem? help=ordersItems.FirstOrDefault(x=>x?.ID==id);
        if(help==null)//the order item does not exist in the list 
            throw new UnfounfException("id not found");
        else
            return(OrderItem)help;  //return the wanted order item but not as nullable 




            //foreach (OrderItem OI in ordersItems)
            //{
            //    if (OI.ID == id)
            //        return OI;
            //}
            //throw new UnfounfException(" id not found");
    }

    public void UPDATE(OrderItem entity)
    {
        //GET(entity.ID);
        DELETE(entity.ID);//the Delete methos will throw an Exeption it the is does not exist if it does , it will remove the un - updated order item from the list 
        ADD(entity);//adds the updated one instead
    }

    public OrderItem GetByOrderAndProduct(int OID, int PID)
    {
        OrderItem? help = ordersItems.Find(x => x?.OrderID == OID && x?.ProductID == PID);
        if (help==null)//there is no order item that match these detalis
             throw new UnfounfException("the  order item was not found");
        else return(OrderItem)help;//Find did found the order item so it returns it but not as nullable 
    


        //foreach(var OI in DataSource.ordersItems)
        //{
        //    OrderItem result = (OrderItem)DataSource.ordersItems.Find(x => (x.Value.OrderID == OID && x.Value.ProductID == PID)); 
        //    return result;
        //}
        //throw new UnfounfException("the item was not found");
    }

    public IEnumerable<OrderItem> GetAll()
    {
        return (from OrderItem item in DataSource.ordersItems select item).ToList();
    }
}
