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
using System.Collections.ObjectModel;
using BLApi;

namespace PL
{
   
    
   //הופעה כפולה בעגלה 
    
    //אפשרות לשנות אמאונט בעגלה 
    //נאל אבל 
    // טוטל פרייס בעגלה 
    
    public partial class Cart : Window
    {
        private IBl bl = BLApi.Factory.Get();
        public BO.cart thisCart = new BO.cart();
        public ObservableCollection<BO.OrderItem> items { get; set; } 
   
        public Cart(BO.cart C)
        {
            try
            {
                InitializeComponent();

                thisCart = C;
                //var i = bl.Cart.getCartList(C);
                smileySad.Visibility = Visibility.Hidden;
                emptyCart.Visibility = Visibility.Hidden;
                continueB.Visibility = Visibility.Hidden;
                items = new ObservableCollection<BO.OrderItem>(bl.Cart.getCartList(thisCart));
                ProductList.ItemsSource = items;
                totalCartPrice();

            }
            catch (BO.NotFoundException ex)
            {
                ProductList.Visibility = Visibility.Hidden;
                Layers.Visibility = Visibility.Hidden;


            }


        }

        public double? totalCartPrice()
        {
            double? total=0;
            foreach(var item in thisCart.items)
            {
                total += item.TotalPrice;
            }
            return total;
        }
        public void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            BO.OrderItem? item = ProductList.SelectedItem as BO.OrderItem;
            thisCart = bl.Cart.DeleteProduct(thisCart, (int)item.ProductId);
            items.Remove(item); 


        }
        public void continueB_click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new OrderConfirm(thisCart).Show();
            this.Close();
        }
    }
}
