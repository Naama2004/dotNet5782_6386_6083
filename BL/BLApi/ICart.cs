

namespace BLApi;

public interface ICart
{

    public BO.cart addProduct(BO.cart C, int id);
    public BO.cart updateAmountInCart(BO.cart C, int ID, int newAmount);
    public void OrderConfirm(BO.cart c);
    public BO.OrderItem copyOrderItem(BO.OrderItem from);
}
