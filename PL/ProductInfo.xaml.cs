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
        public ProductInfo()
        {
            InitializeComponent();
        }
        public ProductInfo(BO.ProductForList p)
        {
            InitializeComponent();
            BO.Enums.print temp =new BO.Enums.print();
            category.Content = p.Category;
            print.Content = p.Print;
            price.Content = p.price;
            ID.Content = p.ProductId;
            switch (p.Print)
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
            
            //var bitmapImage = new BitmapImage();
            ////  Source = "\images\Sweatpantgive_me_a_break.png"
            //bitmapImage.BeginInit();
            //bitmapImage.UriSource = new Uri(@"\images\" + p.Category + temp + @".png");
            //bitmapImage.EndInit();
            //img.Source = bitmapImage;
            //bind the photo url
        }
    }
}
