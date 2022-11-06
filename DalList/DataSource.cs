using DO;
namespace DAL;

static internal class DataSource
{
    internal static class config
    {
        internal const int s_startOrderNumber = 1000;

        private static int s_nextOrderNumber = s_startOrderNumber;
        internal static int NextOrderNumber { get => ++s_nextOrderNumber; }
    }
    static readonly Random R = new Random();
    static internal List<Order?> orders { get;}= new List<Order?>();
    static internal List<OrderItem?> ordersItems { get; } = new List<OrderItem?>();
    static internal List<Product?> products_ { get; } = new List<Product?>();

    static DataSource() { }
    static private void AddProduct();
    static private void AddOrder();
    static private void AddOrderItem();

    static private void s_initalize();
}
