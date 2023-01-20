using BLApi;
using BO;
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
    /// Interaction logic for UpdateOrder.xaml
    /// </summary>
    public partial class UpdateOrder : Window
    {
        private IBl bl = BLApi.Factory.Get();
        public UpdateOrder()
        {
            InitializeComponent();
        }
        public UpdateOrder(BO.OrderForList order)
        {
            InitializeComponent();
            OrderIdDetails.Text = order.OrderId.ToString();
            CustomerNameDetails.Text = order.CustomerName!.ToString();
            StateDetails.Text = order.state.ToString();
            AmountDetails.Text=order.Amount!.ToString();    
            PriceDetails.Text = order.TotalPrice.ToString();

        }

        private void shipUpdate_Click(object sender, RoutedEventArgs e)
        {
            int orderID = int.Parse(OrderIdDetails.Text);
            try
            {
                if(bl.Order.UpdateShip(orderID).ShipDate!=null)
                {
                    MessageBox.Show(

     "order shiping date was updated",
     "succses"
     , MessageBoxButton.OK,
     MessageBoxImage.Information
     );
                }

                new OrderListForManeger().Show();
                this.Close();
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show(
                    
                    ex.Message+":(",
                    "invalid input"
                    , MessageBoxButton.OK,
                    MessageBoxImage.Hand
                    );    
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                   ex.Message+":)",
                   "sorry"
                   , MessageBoxButton.OK,
                   MessageBoxImage.Information
                   );
            }

        }

        private void deliveryUpdate_Click(object sender, RoutedEventArgs e)
        {
            int orderID = int.Parse(OrderIdDetails.Text);
            try
            {
                bl.Order.UpdateDelivery(orderID);
                new OrderListForManeger().Show();
                this.Close();
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show(
                    ex.Message + ":(",
                    "invalid input"
                    , MessageBoxButton.OK,
                    MessageBoxImage.Hand
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                   ex.Message+":)",
                   "sorry"
                   , MessageBoxButton.OK,
                   MessageBoxImage.Information
                   );
            }

        }
    }
}

