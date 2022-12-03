
using BO;
namespace BLApi;

public interface IOrder
{
    public IEnumerable<OrderForList> GETOrders();
    public BO.Order GetOrderDetails(int id);
    public BO.Order UpdateShip(int id);

}
