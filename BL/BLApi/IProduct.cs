
using BO;

namespace BLApi;

public interface IProduct
{
    public IEnumerable<BO.ProductForList> GetProductsByCondition(Func<ProductForList, bool> func, IEnumerable<BO.ProductForList> productForLists);
    public IEnumerable<BO.ProductForList> GetProducts();
   
    public Product ProductInfoManeger(int id);
    public ProductItem ProductInfoClient(int id, cart c);
    public void AddProductmaneger(BO.Product P);
    public void RemoveProductmaneger(int id);
    public void UpdateProductmaneger(BO.Product P);
    public BO.Product createProductByValues(int id, string name, int instock, double price,string cat);
}
