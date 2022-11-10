

using DalApi;
using DO;

namespace DAL;

public class DalProduct : ICrud<Product>
{
    public void ADD(Product P)
    {
        DataSource.products_.Add(P);    
    }

    public void DELETE(int id)
    {
        Product OrderNULL = new Product();//דרך להחזיר אם לא נמצא 
        OrderNULL.ID = 0;
        foreach (Product P in DataSource.products_)
        {
            if (P.ID == id)
                DataSource.products_.Remove(P);
        }
    }

    public Product GET(int id)
    {
        Product productNULL = new Product();//דרך להחזיר אם לא נמצא 
        productNULL.ID = 0;
        foreach (Product p in DataSource.products_)
        {
            if (p.ID == id)
                return p;
        }
        return productNULL;
    }

    public void UPDATE(Product entity)
    {
        DELETE((int)entity.ID);
        ADD(entity);
    }
}
