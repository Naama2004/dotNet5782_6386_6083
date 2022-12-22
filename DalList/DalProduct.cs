

using DalApi;
using DO;
using System.Linq;
using System.Linq.Expressions;
using static Dal.DataSource;

namespace Dal;

public class DalProduct : IProduct/*ICrud<Product>*/
{
    public int ADD(Product P)
    {
        if (P.ID != 0)
        {
            if (DataSource.products.Exists(x => x?.ID == P.ID))//is exist returns true P is alredy in the list
                throw new ExistIdException("this product already exist");
            DataSource.products.Add(P);//if the product isnt already in the list , adds it . 
            return P.ID;
        }
        else
        {
            P.ID = config.NextP;
            return P.ID;
        }
    }

    public void DELETE(int id)
    {
        //if the function finds the product it removes it , if not it returns null and the code throws an exeption.
       if(DataSource.products.RemoveAll(x => x?.ID == id)==0)
            throw new UnfounfException("cant delete a no existing item"); 



        //GET(id);// if it does not exsit the method GET will throw exeption
        //foreach (Product P in DataSource.products)
        //{
        //    if (P.ID == id)
        //    {
        //        DataSource.products.Remove(P); 
        //        break;  
        //    }
        //}
    }

    public Product GET(int id)
    {
        Product? help = DataSource.products.FirstOrDefault(x => x?.ID == id);
        if (help != null)//if the product exist in the list , return in 
            return (Product)help;
        else//first or default returned null which means the product doesnt exist 
            throw new UnfounfException(" id not found");




        //foreach (Product P in DataSource.products)
        //{
        //    if (P.ID == id)
        //        return P;
        //}
        //throw new UnfounfException(" id not found");
    }

    public void UPDATE(Product entity)
    {
        DELETE((int)entity.ID);// the method delete will throw an exeption if the id does not exist
        ADD(entity);
    }

    public IEnumerable<DO.Product> GetAll()
    {
        return (from Product P in DataSource.products select P).ToList();
    }
}
