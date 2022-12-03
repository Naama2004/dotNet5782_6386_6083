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
namespace PL
{
    
    /// <summary>
    /// Interaction logic for ProductListForManager.xaml
    /// </summary>
    public partial class ProductListForManager : Window
    {
        public ProductListForManager()
        {
            InitializeComponent();
        }

        private void ProductsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
