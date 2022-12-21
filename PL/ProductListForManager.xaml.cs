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
//using BL;
using BLApi;
using BlImplementation;

namespace PL
{

    /// <summary>
    /// Interaction logic for ProductListForManager.xaml
    /// </summary>
    public partial class ProductListForManager : Window
    {
        private IBl bl = BLApi.Factory.Get();
        public ProductListForManager()
        {
            //CategorySelector.ItemsSource = System.Enum.GetValues(typeof(BO.Enums.Category));
            ProductsListview.ItemsSource = bl.Product.GetProducts();
            InitializeComponent();
        }

        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsListview.ItemsSource != null)
            {
                ComboBoxItem cbi = (ComboBoxItem)ProductsListview.SelectedItem;
                string? selectedText = cbi.Content.ToString();
                switch (selectedText)
                {
                    case "T-shirt":
                        ProductsListview.ItemsSource = bl.Product.GetProductsByCategory(BO.Enums.Category.Tshirt);
                        break;
                    case "sweat shirt":
                        ProductsListview.ItemsSource = bl.Product.GetProductsByCategory(BO.Enums.Category.Sweatshirt);
                        break;
                    case "sweat Pants":
                        ProductsListview.ItemsSource = bl.Product.GetProductsByCategory(BO.Enums.Category.Sweatpant);
                        break;
                    case "Bucket Hat":
                        ProductsListview.ItemsSource = bl.Product.GetProductsByCategory(BO.Enums.Category.BucketHat);
                        break;
                    case "socks":
                        ProductsListview.ItemsSource = bl.Product.GetProductsByCategory(BO.Enums.Category.Socks);
                        break;
                }
            }
            else
                ProductsListview.ItemsSource = bl.Product.GetProducts();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //move to adding product window 
        }

      
    }
}
