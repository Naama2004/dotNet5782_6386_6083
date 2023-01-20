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


    public partial class ProductListForManager : Window
    {
        private IBl bl = BLApi.Factory.Get();
        //products contains the full list of products when sorting by category the matching products gets added to catalog poduct 
        //when sorting by print the matching products gets added to catalog poduct when clicking the deafult value in each the full list ([eoducts) comes up 


        public ObservableCollection<BO.ProductForList> Products;
        public ObservableCollection<BO.ProductForList> catalogProducts;
        IOrderedEnumerable<IGrouping<BO.Enums.Category, BO.ProductForList>> Categorygroups;
        IOrderedEnumerable<IGrouping<string, BO.ProductForList>> Printgroups;
        public IEnumerable<string> printOptions = new string[] { "all",
              "127.0.0.1 SWEET 127.0.0.1",
               "Hello World!",
            "give me a </br>"
            ,"2B || !2B",
            "roses are #FF0000 vilets are #0000FF"};
       
       
        public ProductListForManager()
        {
            InitializeComponent();
            //binding the product list 
            var TepProductsList = bl.Product.GetProducts();
            Products = new ObservableCollection<BO.ProductForList>(TepProductsList);



            ProductsListview.ItemsSource = Products;// try xml
            DataContext = this;
            CategorySelector.ItemsSource = Enum.GetValues(typeof(DO.Enums.Category));

            PrintSelector.ItemsSource = printOptions;


        }

        public void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            //BO.Enums.Category selectedCategory = (BO.Enums.Category)CategorySelector.SelectedItem;
            var selectedCategory = ((ComboBox)sender).SelectedItem.ToString();
            if (selectedCategory != BO.Enums.Category.none.ToString())
            {
                var groups = from p in Products
                             group p by p.Category into newGroup
                             orderby newGroup.Key
                             select newGroup;

                Categorygroups = groups;

                foreach (var g in Categorygroups)
                {
                    if (g.Key.ToString() == selectedCategory)
                    {
                        catalogProducts = new(g.TakeWhile(x => true));
                    }
                }
                ProductsListview.ItemsSource = catalogProducts;
            }
            else

                ProductsListview.ItemsSource = Products;


        }
        private void PrintSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedPrint = PrintSelector.SelectedItem;
            //var selectedPrint = PrintSelector.Text;


            if (selectedPrint != "all")
            {
                var groups = from p in Products
                             group p by p.Print into newGroup
                             orderby newGroup.Key
                             select newGroup;

                Printgroups = groups;
                //if (selectedPrint == "give me a /br")
                //    selectedPrint = "give me a </br>";
               foreach (var g in groups)
                {
                    if (g.Key== selectedPrint!)
                    {
                        catalogProducts = new(g.TakeWhile(x => true));
                    }
                }
                ProductsListview.ItemsSource = catalogProducts; 
            }
            else//the wanted print is default
            {
                ProductsListview.ItemsSource = Products;
            }








        }
















        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Action<BO.Product> action = update => Products.Add(bl.Product.GetProducts().FirstOrDefault(x=>x.ProductId==)
            new AddOrUpdateProductWindow(Products).Show(); ;

            //  ProductsListview.ItemsSource = bl.Product.GetProducts();// איך לעשות שלר נצטרך כל פעם לקחת מחדש את הרשימה??
            //  this.Close();
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
                Action<BO.Product> action = update => Products.Add(item);
                new AddOrUpdateProductWindow(update, Products).Show();//open the ADD or Update window but send it value which makes it the updaate window
                                                                      // this.Close();
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