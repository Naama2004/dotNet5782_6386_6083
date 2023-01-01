using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
//using BL;
using BLApi;
using BlImplementation;
using Microsoft.VisualBasic;

namespace PL
{

    /// <summary>
    /// Interaction logic for ProductListForManager.xaml
    /// </summary>
    public partial class ProductListForManager : Window
    {
        private IBl bl = BLApi.Factory.Get();
        
        

        // public ObservableCollection<BO.ProductForList> Products { set; get; }
        //public List<BO.ProductForList> Products { set; get; }

        public  IEnumerable<BO.ProductForList> Products { get; set; }
        public ProductListForManager()
        {
            InitializeComponent();
            Products = bl.Product.GetProducts();
            ProductsListview.ItemsSource=Products;  
            //DataContext = this;
            CategorySelector.ItemsSource =  Enum.GetValues(typeof (DO.Enums.Category));
        }

        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategorySelector.SelectedItem != null)
            {
                BO.Enums.Category category = (BO.Enums.Category)CategorySelector.SelectedItem;

                //Products = new ObservableCollection<BO.ProductForList>(bl.Product.GetProductsByCondition(product => product.Category == category, Products));
                ProductsListview.ItemsSource = bl.Product.GetProductsByCondition(product => product.Category == category, Products);
            }
            else
                ProductsListview.ItemsSource = bl.Product.GetProducts().ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddOrUpdateProductWindow help = new AddOrUpdateProductWindow();
            help.Show();
          //  ProductsListview.ItemsSource = bl.Product.GetProducts();// איך לעשות שלר נצטרך כל פעם לקחת מחדש את הרשימה??
               this.Close();
        }

       private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

             BO.ProductForList? item = ProductsListview.SelectedItem as BO.ProductForList;
            if (item != null) 
            {
                BO.Product update = new BO.Product();
                update.ID = item.ProductId;
                update.Print = item.Print;
                update.category = item.Category;
                update.Price = item.price;
                update.instock = 1;// need to be changed
                new AddOrUpdateProductWindow(update).Show();//open the ADD or Update window but send it value which makes it the updaate window
                this.Close();
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
