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
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    ///    //לזרוק אם העגלה ריקה
    //לברר את הפרייסים
    // לשנות את ההכנסה הלעגלה שיהיה לפי האמאונט
    //מסג בוקס בקטלוג 
    //מחיקה מהאובזרבל 
    //פונצקיית  מחיקה של פריט בעגלה
    //אפשרות לשנות אמאונט בעגלה 
    public partial class Cart : Window
    {
        private IBl bl = BLApi.Factory.Get();
        //public BO.cart thisCart = new BO.cart();
        public ObservableCollection<BO.OrderItem> items { get; set; }
   
        public Cart(BO.cart C)
        {
            InitializeComponent();
            var i= bl.Cart.getCartList(C);

            items= new ObservableCollection<BO.OrderItem>(i);

            ProductList.ItemsSource = items;


        }
        public void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
           //delete in data sorse!!!
          

        }
    }
}
