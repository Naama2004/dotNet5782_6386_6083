using DO;

namespace DalApi;

public interface IOrder: ICrud<Order>
{
    public IEnumerable<Order> GetAll();
}
