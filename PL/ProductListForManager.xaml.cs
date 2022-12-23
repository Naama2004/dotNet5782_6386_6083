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
            InitializeComponent();
            ProductsListview.ItemsSource = bl.Product.GetProducts();
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
            AddOrUpdateProductWindow help = new AddOrUpdateProductWindow();
            //help.ShowDialog();
            help.Show();
        }

        void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as BO.Product;
            if (item != null)//null or one of them is missing we need to check 
            {
                AddOrUpdateProductWindow help = new AddOrUpdateProductWindow(item);
                help.Show();//open the ADD or Update window but send it value which makes it the updaate window

            }
            else
            {
                MessageBox.Show("please choose an item to update"
                    , "missing input"
                    , MessageBoxButton.OK);
            }


        }

    }
    }
