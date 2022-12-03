

using DalApi;
using DO;
using System.Linq;

namespace DAL;

public class DalProduct : ICrud<Product>
{
    public void ADD(Product P)
    {
        if (DataSource.products_.FirstOrDefault(x => x.Value.ID == P.ID) != null)
            throw new ExistIdException("this product already exist");
        if (DataSource.products_.FirstOrDefault(x => x.Value.ID == P.ID) == null)
            DataSource.products_.Add(P);
    }

    public void DELETE(int id)
    {
        GET(id);
        foreach (Product P in DataSource.products_)
        {
            if (P.ID == id)
                DataSource.products_.Remove(P);
        }
    }

    public Product GET(int id)
    {

        if (DataSource.products_.FirstOrDefault(x => x.Value.ID == id) == null)
            throw new UnfounfException(" id not found");
        else
            return (DO.Product)DataSource.products_.FirstOrDefault(x => x.Value.ID == id);
        // להשאיר פור איצצצצצ או לאאאאאאאאאאאאא
        foreach (Product p in DataSource.products_)
        {
            if (p.ID == id)
                return p;
        }
        throw new UnfounfException(" id not found");

    }

    public void UPDATE(Product entity)
    {
        GET(entity.ID);
        DELETE((int)entity.ID);
        ADD(entity);
    }

    public IEnumerable<Product> GetAll()
    {
        return (from Product P in DataSource.products_ select P).ToList();
    }
}
