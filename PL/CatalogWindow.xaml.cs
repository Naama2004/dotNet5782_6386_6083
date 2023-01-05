using BLApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace PL
{
    public partial class CatalogWindow : Window
    {
        private IBl bl = BLApi.Factory.Get();
        public BO.cart currentCart =new BO.cart();  
        public IEnumerable<BO.ProductForList> Products { get; set; }

        
        public CatalogWindow()
        {
            InitializeComponent();
            Products = bl.Product.GetProducts();
            ProductList.ItemsSource = Products;
            DataContext = this;

            bl.Cart.EmptyCart(currentCart);
        }
        public void Add_To_Cart_click(object sender, MouseButtonEventArgs e)
        {
            BO.ProductForList item = ProductList.SelectedItem as BO.ProductForList;
            var temp = ProductList.SelectedItem;
            int id = item.ProductId;
            bl.Cart.addProduct(currentCart, id);
        }

        public void ViewCart(object sender, MouseButtonEventArgs e)
        {
           new Cart().Show();
        }
        private void Track_Order(object sender, RoutedEventArgs e)
        {
            TrackOrder trackOrder = new TrackOrder();
            trackOrder.Show();

        }
       
    }
}
