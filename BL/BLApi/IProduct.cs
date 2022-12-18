
using BO;

namespace BLApi;

public interface IProduct
{
    public IEnumerable<BO.ProductForList> GetProducts();
    public IEnumerable<BO.ProductForList> GetProductsByCategory(BO.Enums.Category category);
    public Product ProductInfoManeger(int id);
    public ProductItem ProductInfoClient(int id, cart c);
    public void AddProductmaneger(BO.Product P);
    public void RemoveProductmaneger(int id);
    public void UpdateProductmaneger(BO.Product P);



}
