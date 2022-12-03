using DO;


namespace DalApi;

public interface IProduct: ICrud<Product>
{
    public IEnumerable<Product> GetAll();
}
