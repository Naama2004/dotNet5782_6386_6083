using BLApi;
using BlImplementation;
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
using static System.Net.Mime.MediaTypeNames;

namespace PL
{
    /// <summary>
    /// Interaction logic for ProductInfo.xaml
    /// </summary>
    public partial class ProductInfo : Window
    {
        public PL.Product productInfo = new PL.Product();
        private IBl bl = BLApi.Factory.Get();
       public BO.cart cart { get; set; } 
        public ProductInfo()
        {
            InitializeComponent();
        }

        public  ProductInfo(BO.cart c,PL.Product p)
        {
            InitializeComponent();
            productInfo = p;
                category.Content = p.Category;
                print.Content = p.Print;
                price.Content = p.price;
                ID.Content = p.ProductId;
                img.Source = p.ImageSource;
            amount.Text = "0";
            cart = c;
        }

        public void Add_To_Cart_click(object sender, MouseButtonEventArgs e)
        {
            //productInfo.amount = int.Parse(amount.Text);
            bl.Cart.addProduct(cart, productInfo.ProductId, int.Parse(amount.Text));
            Close();
        }

        public void Up_Click(object sender, RoutedEventArgs e)
        {
            int currentA = int.Parse(amount.Text);
            currentA++;
            amount.Text = currentA.ToString();
        }

        public void Down_Click(object sender, RoutedEventArgs e)
        {
            int currentA = int.Parse(amount.Text);
            if (currentA > 0)
            {
                currentA--;
                amount.Text = currentA.ToString();
            }
            else //0 amount
            {
                MessageBox.Show(
                      "brrr its cold here below zero",
                      "Invalid amount",
                      MessageBoxButton.OK,
                      MessageBoxImage.Hand);
            }

        }
    }
}
