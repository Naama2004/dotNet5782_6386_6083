using DO;

namespace DalApi;

public interface IOrderItem: ICrud<OrderItem>
{
    public OrderItem GetByOrderAndProduct(int OID, int PID);
   
}
