using System;
using System.Collections.Generic;
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
using BLApi;


namespace PL
{
   //איך לגרום לצק בוקס להיות לפי השורה בליסט ויו אם יש בסטוק וכו
    public partial class Catalog : Window
    {
        public bool InStock { get; set; }
      
        public IEnumerable<BO.ProductForList> Products { get; set; }
        private IBl bl = BLApi.Factory.Get();

        public Catalog()
        {
            InitializeComponent();
            Products = bl.Product.GetProducts();
            productListView.ItemsSource = Products;
           
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TrackOrder trackOrder = new TrackOrder();
            trackOrder.Show();
            
        }
    }
}
