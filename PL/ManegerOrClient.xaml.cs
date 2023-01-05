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
    /// Interaction logic for ManegerOrClient.xaml
    /// </summary>
    public partial class ManegerOrClient : Window
    {
        const string manegerPassward = "PASSWORD";

        public ManegerOrClient()
        {
            InitializeComponent();
            PasswordText.Visibility = Visibility.Hidden;
            pass.Visibility = Visibility.Hidden;
            passwordContent.Visibility = Visibility.Hidden;
        }

        private void ManegerButton_Click(object sender, RoutedEventArgs e)
        {
            Maneger.Visibility = Visibility.Hidden;
            Client.Visibility = Visibility.Hidden;
            entry.Visibility = Visibility.Hidden;
            PasswordText.Visibility = Visibility.Visible;
            pass.Visibility = Visibility.Visible;
            passwordContent.Visibility = Visibility.Visible;

        }

        private void pass_Click(object sender, RoutedEventArgs e)
        {
            string temp=passwordContent.Text;
            if (temp == manegerPassward)
            {
                new OrdersOrProducts().Show();
                Close();
            }
            else
            {
                MessageBox.Show("wrong password, try again!"
    , "ERROR"
    , MessageBoxButton.OK,
    MessageBoxImage.Hand);
            }
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
          //  BO.OrderTracking temp=new BO.OrderTracking();
          //  temp.OrderId = 123456;
          //  temp.State = BO.Enums.State.send;
          ////  new TrackOrder(temp).Show();
          CatalogWindow C=new CatalogWindow();
            C.Show();

        }
    }
}
