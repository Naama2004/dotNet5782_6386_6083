

namespace BLApi;

public interface ICart
{

    public BO.cart addProduct(BO.cart C, int id);
    public BO.cart UpdatePAmount ( BO.cart C , int id, int amount); 
    //public BO.cart confirmCart(BO.cart C);
}
