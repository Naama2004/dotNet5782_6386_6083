
namespace BLApi;

public interface IProduct
{
    public IEnumerable<BO.ProductForList> GetProducts();
    public BO.Product ProductInfomaneger(int id);
    public void AddProductmaneger(BO.Product P);
    public void RemoveProductmaneger(int id);    
    public void UpdateProductmaneger (BO.Product P);   

    
}
