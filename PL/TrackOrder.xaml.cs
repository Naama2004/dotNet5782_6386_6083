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
            order_Status.Visibility = Visibility.Hidden;
            Text_Order_status.Visibility = Visibility.Hidden;
        }

        private void Entered_Oid_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                order_Status.Visibility = Visibility.Visible;
                Text_Order_status.Visibility = Visibility.Visible;
                Entered_Oid.IsEnabled = false;
                string WantedID = OrderID.Text;
                BO.Enums.State State = bl.Order.trackOrder(int.Parse(WantedID)).State;
                Text_Order_status.Text = State.ToString();
               
            }
           
       
            catch (BO.InValidIdException ex)
            {
                MessageBox.Show("this ID isnt Valid"
                   , "inValid input"
                   , MessageBoxButton.OK);
                Entered_Oid.IsEnabled = true;


            }
            catch(BO.NotFoundException ex)
            {
                MessageBox.Show("this ID does not exist"
                   , "inValid input"
                   , MessageBoxButton.OK);
                Entered_Oid.IsEnabled = true;
            }


        }
    }
}
