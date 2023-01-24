
using BO;
namespace BLApi;

public interface IOrder
{
    public IEnumerable<BO.OrderForList> GETOrders();
    public BO.Order GetOrderInfo(int id);
    public BO.Order UpdateShip(int id);
    public BO.Order copyvalues(DO.Order d);//we need to write it here???
    public BO.Enums.State FindState(DO.Order O);
    public int TotalProductsAmount(int ID);
    public Double? TotalPrice(int ID);
    public List<BO.OrderItem>? getallorderItem(int ID);
    public BO.Order UpdateDelivery(int id);
    public BO.OrderTracking trackOrder(int ID);

    public BO.OrderForList GetOrderForList(int ID);


}
