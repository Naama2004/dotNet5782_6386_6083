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
using System.Windows.Navigation;
using System.Windows.Shapes;

using BLApi;
//using BlImplementation;
namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IBl bl = BLApi.Factory.Get();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void enterListSystem_Click(object sender, RoutedEventArgs e)
        {

             new ManegerOrClient().Show();
            //new pi().Show();
            this.Close();
        }
    }
}
