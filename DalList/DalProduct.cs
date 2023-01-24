

using DalApi;
using DO;
using System.Linq;
using System.Linq.Expressions;
using static Dal.DataSource;

namespace Dal;

public class DalProduct : IProduct
{
    public int ADD(Product P)
    {
        if (P.ID != 0)
        {
            if (Products.Exists(x => x?.ID == P.ID))
                throw new ExistIdException("this product already exist");
           Products.Add(P); 
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
        //if the function finds the product it removes it , if not it returns 0 and the code throws an exeption.
     if( Products.RemoveAll(x => x?.ID == id)==0)
            throw new UnfounfException("cant delete a no existing item"); 
    }

    public Product GET(int id)
    {
        return Products.FirstOrDefault(x => x?.ID == id)
            ?? throw new UnfounfException("id not found");

    }

    public void UPDATE(Product entity)
    {
        DELETE(entity.ID);//if the product doesnt exist DELETE will throw the Exception
        ADD(entity);
    }

    public IEnumerable<DO.Product> GetAll()
    {
        return (from Product P in Products
                select P);
    }
}
