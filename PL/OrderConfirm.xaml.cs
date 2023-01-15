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
    /// Interaction logic for OrderConfirm.xaml
    /// </summary>
    public partial class OrderConfirm : Window
    {
        private IBl bl = BLApi.Factory.Get();
       public  BO.cart Cart;
        public OrderConfirm()
        {
            InitializeComponent();
        }

        public OrderConfirm(BO.cart c)
        {
            InitializeComponent();
            Cart = c;
   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;
            if(Name.Text=="")
            {
                MessageBox.Show("meesing input"
                      , "please enter your name"
                      , MessageBoxButton.OK,
                      MessageBoxImage.Hand);
                flag = false;
            }
            if (!Email.Text.Contains("@gmail.com"))
            {
                MessageBox.Show("invalid input"
                      , "your E-mail address is not valid"
                      , MessageBoxButton.OK,
                      MessageBoxImage.Hand);
                flag = false;
            }
            if (Address.Text=="")
            {
                MessageBox.Show("meesing input"
                      , "please enter your address"
                      , MessageBoxButton.OK,
                      MessageBoxImage.Hand);
                flag = false;
            }
            if (flag)
            {
                try
                {
                    Cart.CustomerEmail = Email.Text;
                    Cart.CustomerAddres = Address.Text;
                    Cart.CustomerName = Name.Text;
                    int id = bl.Cart.OrderConfirm(Cart);
                    MessageBox.Show("Order " + id+" is confirm",
                            "Thank you for your order"
                            , MessageBoxButton.OK
                            );
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR"
                    , "sorry something went wrong with your order, try again"
                    , MessageBoxButton.OK,
                      MessageBoxImage.Hand);
                }
            
                Close();
            }
        }
}
}
