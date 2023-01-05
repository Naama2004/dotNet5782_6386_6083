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
            category.Content = p.Category;
            print.Content = p.Print;
            price.Content = p.price;
            ID.Content = p.ProductId;
            //bind the photo url
        }
    }
}
