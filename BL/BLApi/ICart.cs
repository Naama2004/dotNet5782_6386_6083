

namespace BLApi;

public interface ICart
{

    public BO.cart addProduct(BO.cart C, int ProductID, int amount);
    public BO.cart DeleteProduct(BO.cart C, int ProductID);

    public BO.cart updateAmountInCart(BO.cart C, int ID, int newAmount);
    public int OrderConfirm(BO.cart c);
    public BO.OrderItem copyOrderItem(BO.OrderItem from);
    public void EmptyCart(BO.cart C);
    public IEnumerable<BO.OrderItem> getCartList(BO.cart C);

}
