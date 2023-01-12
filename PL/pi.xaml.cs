using BlImplementation;
using BO;
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
    /// Interaction logic for pi.xaml
    /// </summary>
    public partial class pi : Window
    {
        public pi()
        {
            InitializeComponent();
            textNumber.Text = "0";

        }
        public void Up_Click(object sender, RoutedEventArgs e)
        {
            int currentA = int.Parse(textNumber.Text);
            currentA++;
            textNumber.Text = currentA.ToString();


        }
        public void Down_Click(object sender, RoutedEventArgs e)
        {
            int currentA = int.Parse(textNumber.Text);
            if (currentA > 0)
            {
                currentA--;
                textNumber.Text = currentA.ToString();
            }
            else //0 amount
            {
                MessageBox.Show(
                      "brrr its cold here below zero",
                      "Invalid amount",
                      MessageBoxButton.OK,
                      MessageBoxImage.Hand);

            }

        }
    }
}
//        private void cmdDown_Click(object sender, RoutedEventArgs e)
//        {
//            var b = (Button)sender;
//            int amount = ((PO.OrderItemPO)b.DataContext).Amount;
//            if (amount == 1)
//                return;
//            UpdateAmount(sender, amount - 1);
//        }

//        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
//        {
//            var t = (TextBox)sender;
//            int amount = int.Parse(t.Text);
//            if (amount == 0)
//                return;
//            UpdateAmount(sender, amount, true);
//        }

//        private void cmdUp_Click(object sender, RoutedEventArgs e)
//        {
//            var b = (Button)sender;
//            int amount = ((PO.OrderItemPO)b.DataContext).Amount;
//            UpdateAmount(sender, amount + 1);
//        }
//        private void UpdateAmount(object sender, int amount, bool isTextBox = false)
//        {
//            try
//            {
//                PO.OrderItemPO item = new();
//                TextBox t;
//                Button b;
//                if (isTextBox)
//                {
//                    t = (TextBox)sender;
//                    item = (PO.OrderItemPO)t.DataContext;
//                }
//                else
//                {
//                    b = (Button)sender;
//                    item = (PO.OrderItemPO)b.DataContext;
//                }
//                bl.Cart.UpdateAmountProduct(cartBo, item.ProductID, amount);
//                item = myCart.OrderItems.FirstOrDefault(x => x.ID == item.ID);
//                myCart.TotalPrice = cartBo.TotalPrice;
//                if (amount == 0)
//                {
//                    myCart.OrderItems.Remove(item);
//                    myCart.TotalPrice = cartBo.TotalPrice;
//                    return;
//                }
//                item.Amount = amount;
//            }
//            catch (BO.OutOfStockException ex)
//            {
//                MessageBox.Show("אין עוד מהמוצר הזה במלאי" +
//                   "", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
//                return;
//            }
//        }
//    }
//}
