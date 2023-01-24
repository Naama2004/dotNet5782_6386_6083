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
    /// <summary>
    /// Interaction logic for OrderListForManeger.xaml
    /// </summary>
    public partial class OrderListForManeger : Window
    {
        private IBl bl = BLApi.Factory.Get();
        public ObservableCollection<BO.OrderForList> Orders { set; get; }
        public OrderListForManeger()
        {
            InitializeComponent();
            Orders = new ObservableCollection<BO.OrderForList>(bl.Order.GETOrders());
            DataContext = this;
          
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.OrderForList? item = OrderListview.SelectedItem as BO.OrderForList;
            if (item != null)
            {
                new UpdateOrder(item).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("please choose an item to update"
                    , "missing input"
                    , MessageBoxButton.OK,
                    MessageBoxImage.Hand);
            }
        }
        private void openOrderSimulator(object sender, MouseButtonEventArgs e)
        {
            new OrdersSimulator().Show();
        }


    }
}
