using BLApi;
using BO;
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
using static System.Net.Mime.MediaTypeNames;

namespace PL
{
    public partial class CatalogWindow : Window
    {
        private IBl bl = BLApi.Factory.Get();
        public BO.cart currentCart = new BO.cart();


        public ObservableCollection<PL.Product> Products;

        public CatalogWindow()
        {
            InitializeComponent();
            var i = getProducts(bl.Product.GetProducts());
            Products = new ObservableCollection<PL.Product>(i);
            catalog.ItemsSource = Products;
            DataContext = this;
            bl.Cart.EmptyCart(currentCart);
        }
        //public void Add_To_Cart_click(object sender, MouseButtonEventArgs e)
        //{
        //    try
        //    {
        //        var curItem = ((ListBoxItem)catalog.ContainerFromElement((Button)sender)).Content;
        //        //var temp1 = catalog.SelectedItem;
        //        PL.Product? item = curItem as PL.Product;

        //        int id = item.ProductId;
        //        int amount = 0;//get the amount that is in the text box
        //        if (amount == 0)
        //        {
        //            MessageBox.Show(
        //              "amount 0  ",
        //              "Invalid amount",
        //               MessageBoxButton.OK,
        //              MessageBoxImage.Hand);
        //            //}
        //            //else
        //            bl.Cart.addProduct(currentCart, id, 0);
        //                }
               
        //    }
        //    catch(BO.NotInStockException ex)
        //    {
        //        MessageBox.Show(
        //             "oops thats too much ",
        //             "Invalid stock",
        //              MessageBoxButton.OK,
        //             MessageBoxImage.Hand);
        //    }
        //}

        IEnumerable<PL.Product> getProducts(IEnumerable<BO.ProductForList> tempList)
        {

            BO.Enums.print temp = new BO.Enums.print();
            List<PL.Product> returnList = new List<PL.Product>();
            foreach (var P in tempList)
            {
                PL.Product temp1 = new Product();
                temp1.ProductId = P.ProductId;
                temp1.Print = P.Print;
                temp1.price = P.price;
                temp1.Category = (BO.Enums.Category)P.Category!;

                switch (P.Print)
                {
                    case "127.0.0.1 SWEET  127.0.0.1":
                        temp = BO.Enums.print.home_SWEET_home;
                        break;
                    case "Hello World!":
                        temp = BO.Enums.print.HelloWorld;
                        break;
                    case "give me a </br>":
                        temp = BO.Enums.print.give_me_a_break;
                        break;
                    case "2B || !2B":
                        temp = BO.Enums.print.to_B_or_not_to_be;
                        break;
                    case "roses are #FF0000 vilets are #0000FF":
                        temp = BO.Enums.print.roses_are_red_vilots_are_blue;
                        break;
                }
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
        
                bitmapImage.UriSource = new Uri(@"C:\Users\אריאל דרעי\Desktop\תואר\miniProject\dotNet5782_6386_6083\PL\images\" + P.Category + temp + @".png");
                bitmapImage.EndInit();
                temp1.ImageSource = bitmapImage;
                returnList.Add(temp1);
                
            }
            return (IEnumerable<PL.Product>)returnList;
        }
        public void ProductList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            PL.Product? item = catalog.SelectedItem as PL.Product;
            if(item != null)    
            new ProductInfo(currentCart,item!).Show();
        }
        public void ViewCart(object sender, MouseButtonEventArgs e)
        {
            new Cart(currentCart).Show();
        }
        private void Track_Order(object sender, RoutedEventArgs e)
        {
            TrackOrder trackOrder = new TrackOrder();
            trackOrder.Show();
        }
    }
}



