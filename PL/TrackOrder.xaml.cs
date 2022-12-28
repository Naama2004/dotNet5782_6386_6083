using BLApi;
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
    /// Interaction logic for TrackOrder.xaml
    /// </summary>
    public partial class TrackOrder : Window
    {
        private IBl bl = BLApi.Factory.Get();
        public TrackOrder()
        {
            InitializeComponent();
        }

        public TrackOrder(int id)
        {
            InitializeComponent();
            BO.OrderTracking  order =bl.Order.trackOrder(id);
            OrderID.Text = order.OrderId.ToString();
            OrderState.Text = order.State.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           Close();
        }
    }
}
