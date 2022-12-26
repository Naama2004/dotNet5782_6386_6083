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

namespace PL
{
    /// <summary>
    /// Interaction logic for OrdersOrProducts.xaml
    /// </summary>
    public partial class OrdersOrProducts : Window
    {
        public OrdersOrProducts()
        {
            InitializeComponent();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            new OrderListForManeger().Show();
            Close();    
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            new ProductListForManager().Show();
            Close ();
        }
    }
}
