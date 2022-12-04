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
using BL;
using BLApi;
//using BlImplementation;

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
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            ProductsListview.ItemsSource=bl.Product.GetProducts();    
            InitializeComponent();
        }

        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategorySelector.SelectedItem != null)
                ProductsListview.ItemsSource = bl.Product.GetProductsByCategory((BO.Enums.Category)ProductsListview.SelectedItem);
            else
                ProductsListview.ItemsSource = bl.Product.GetProducts();
        }
    }
}
