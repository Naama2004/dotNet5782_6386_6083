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
using System.Collections.ObjectModel;


namespace PL
{

    /// the same window is used for adding a product and for updating one, when adding is needed the window is constructed by a 
    /// constructor that doed not get any value it just initialize the components and binds the combo boxes to the enuums
    /// the other constructor , which is used TO UPDATE a product builds the same components but puts in the values that where
    /// sent to him as values
    /// each option has its on buttnwhich is used to confirm the action (adding or updating)

    public partial class AddOrUpdateProductWindow : Window
    {
        BLApi.IBl? bl = BLApi.Factory.Get();
        //Action<BO.Product> action;
        public ObservableCollection<BO.ProductForList> ProductsS;

        public AddOrUpdateProductWindow(ObservableCollection<BO.ProductForList> Products)
        {
            InitializeComponent();
            ProductsS=Products;
            ConfirmAdding.Visibility = System.Windows.Visibility.Visible;
            confirmUpdatingProduct.Visibility = System.Windows.Visibility.Hidden;
            Selected_Category.ItemsSource = Enum.GetValues(typeof(DO.Enums.Category));
            id.IsEnabled = false;
            categoryViewer.IsEnabled = false;
            PrintOnItem.IsEnabled = false;
            price.IsEnabled = false;
            in_stock.IsEnabled = false;
        }
        public AddOrUpdateProductWindow(BO.Product productToUpdate, ObservableCollection <BO.ProductForList> Products)
        { 
            InitializeComponent();
            ProductsS = Products;
            id.IsEnabled = false;
            categoryViewer.IsEnabled = false;
            PrintOnItem.IsEnabled = false;
            price.IsEnabled = false;
            in_stock.IsEnabled = false;
            Selected_Category.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            ConfirmAdding.Visibility = System.Windows.Visibility.Hidden;
            confirmUpdatingProduct.Visibility = System.Windows.Visibility.Visible;

            string temp = Convert.ToString(productToUpdate.ID);
            SelectedId.Text = productToUpdate.ID.ToString();
            SelectedId.IsEnabled = false;
            SelectedPrice.Text = productToUpdate.Price.ToString();
            Selected_Instock.Text = productToUpdate.instock.ToString();
            Selected_Category.Text = productToUpdate.category.ToString();
           SelectedPrint.Text = productToUpdate.Print.ToString();
        }

        #region confirm all data
        private void Confirm(object sender, RoutedEventArgs e, bool isUpdating)
        {
            try
            {

                //this function will work when the manger typed in the product details and wants to add that product 

                //get all of the wanted info from the text boxes
                int wantedID = int.Parse(SelectedId.Text);
                double wantedPrice = double.Parse(SelectedPrice.Text);
                int WantedStock = int.Parse(Selected_Instock.Text);
                bool flag = true;
                #region check the id
                if (wantedID <=9999 || wantedID >= 1000000)
                {
                    //if the id isnt valid show a messege box 
                    MessageBox.Show(
                        "The ID you entered is is not valid",
                        "Invalid input",
                        MessageBoxButton.OK,
                        MessageBoxImage.Hand

                        );
                    flag= false;    
                }
                #endregion
                #region check if the category and price match
                switch (Selected_Category.Text)
                {
                    case "Tshirt":
                        {
                            if (wantedPrice != 30)
                            {
                                MessageBox.Show(
                       "The price you entered doesnt matches the category",
                       "Invalid input",
                       MessageBoxButton.OK,
                       MessageBoxImage.Hand);
                                flag = false;
                            }
                            break;
                        }
                    case "Sweatshirt":
                        {
                            if (wantedPrice != 50)
                            {
                                MessageBox.Show(
                       "The price you entered doesnt matches the category",
                       "Invalid input",
                       MessageBoxButton.OK,
                       MessageBoxImage.Hand);
                                flag = false;
                            }
                            break;
                        }
                    case "Sweatpant":
                        {
                            if (wantedPrice != 40)
                            {
                                MessageBox.Show(
                       "The price you entered doesnt matches the category",
                       "Invalid input",
                       MessageBoxButton.OK,
                       MessageBoxImage.Hand);
                                flag = false;
                            }
                            break;
                        }
                    case "BucketHat":
                        {
                            if (wantedPrice != 25)
                            {
                                MessageBox.Show(
                       "The price you entered doesnt matches the category",
                       "Invalid input",
                       MessageBoxButton.OK,
                       MessageBoxImage.Hand);
                                flag = false;
                            }
                            break;
                        }
                    case "Socks":
                        {
                            if (wantedPrice != 15)
                            {
                                MessageBox.Show(
                       "The price you entered doesnt matches the category",
                       "Invalid input",
                       MessageBoxButton.OK,
                       MessageBoxImage.Hand);
                                flag = false;
                            }
                            break;
                        }
                }
                #endregion
                #region check the price
                if (wantedPrice < 0)
                {

                    MessageBox.Show(
                        "The price you entered is incorrect",
                        "Invalid input",
                        MessageBoxButton.OK,
                        MessageBoxImage.Hand);
                    flag = false;
                }
                #endregion
                #region check the stock
                if (WantedStock < 0)
                {
                    MessageBox.Show(
                        "The stock you entered is incorrect",
                        "Invalid input",
                        MessageBoxButton.OK,
                        MessageBoxImage.Hand);
                    flag = false;
                }
                #endregion
                #region check the category
                if (Selected_Category.Text == "")
                {
                    MessageBox.Show(
                     "you didnt choose a Category",
                     "missing input",
                     MessageBoxButton.OK,
                     MessageBoxImage.Hand);
                    flag = false;

                }
                #endregion
                #region check the print
                if (SelectedPrint.Text == "")
                {
                    MessageBox.Show(
                    "you didnt choose a Print",
                    "missing input",
                    MessageBoxButton.OK,
                    MessageBoxImage.Hand);
                    flag = false;
                }
                #endregion
                if (flag)//all the inputs are correct
                {
                    BO.Product TEMP = bl!.Product.createProductByValues(wantedID, SelectedPrint.Text, WantedStock, wantedPrice, Selected_Category.Text);
                    if (isUpdating == true)
                    {
                        bl.Product.UpdateProductmaneger(TEMP);
                        ProductForList help = new ProductForList();
                        help.price = TEMP.Price;
                        help.ProductId = TEMP.ID;
                        help.Category = (Enums.Category)TEMP.category;
                        help.Print = TEMP.Print;

                        ProductsS.Add(help);
                        // action(TEMP);
                    }
                    //adding the product to BO
                    else
                    {
                        bl.Product.AddProductmaneger(TEMP);
                        ProductForList help=new ProductForList();
                        help.price = TEMP.Price;
                        help.ProductId = TEMP.ID;
                        help.Category = (Enums.Category)TEMP.category;
                        help.Print=TEMP.Print;

                        ProductsS.Add(help);
                        //action(TEMP);
                    }




                }
                //open a new list window(which calls the get all method which updates the list to include this item

               // new PL.ProductListForManager().Show();
                    this.Close();
              
            }
            #region catch the exeptions
            catch (BO.IdExistException)
            {

                MessageBox.Show(
                "this item id already Exist",
                "invalid input",
                MessageBoxButton.OK,
                MessageBoxImage.Hand);
            }
            catch (BO.InValidIdException)
            {

                MessageBox.Show(
                "one or more of the valus are incorrect",
                "invalid input",
                MessageBoxButton.OK,
                MessageBoxImage.Hand);
            }
            catch (NotFoundException ex)
            {
                MessageBox.Show(
                      "id was not fount",
                      "Unknown error",

                     MessageBoxButton.OK,
                      MessageBoxImage.Hand);

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                      "Somthing went worng...\n please try again later",
                      "Unknown error",

                     MessageBoxButton.OK,
                      MessageBoxImage.Hand);

            }
            #endregion
        }
        #endregion

        private void ConfirmAdding_Click(object sender, RoutedEventArgs e)
        {
            Confirm(sender, e, false);

        }

        private void confirmUpdatingProduct_Click(object sender, RoutedEventArgs e)
        {

            Confirm(sender, e, true);

        }


    }
}
