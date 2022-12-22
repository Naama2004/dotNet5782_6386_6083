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
    /// Interaction logic for AddProductWindowxaml.xaml
    /// </summary>
    
    public partial class AddProductWindowxaml : Window
    {
        BLApi.IBl? bl = BLApi.Factory.Get();


        public AddProductWindowxaml()
        {
            InitializeComponent();
            //make the category combo box be the category enums options
           // Selected_Category.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            //make the prints combo box be the print enum options
            // SelectedPrint.ItemsSource=Enum.GetValues(typeof(BO.Enums.print));



            //מה זה האייטמ סורס והאם צריך אותו ולמה 
           
            //זה תקין שאפשר לגשת לבאו ולדאו ??
            //נלאבלים
            //הפוהקציות מחזירות רפרנס?
            //למה יש זריקה בהשמה של הליסט בחלון הקודם?
        }

        private void ConfirmAdding_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //this function will work when the manger typed in the product details and wants to add that product 

                //get all of the wanted info from the text boxes
                int wantedID = int.Parse(SelectedId.Text);
                double wantedPrice = double.Parse(SelectedPrice.Text);
                int WantedStock = int.Parse(Selected_Instock.Text);
                bool flag = true;

                if (wantedID <= 99999 || wantedID >= 1000000)
                    //if the id isnt valid show a messege box 
                    MessageBox.Show(
                        "The ID you entered is is not valid",
                        "Invalid input",
                        MessageBoxButton.OK,
                        MessageBoxImage.Hand
                       
                        );

                if (wantedPrice < 0)
                {
                    // לעניות דעתי יש צורך פה לבדוק שהמחיר שהוא הכניס תואם למחיר הקבוע בחנות עבור המוצר
                    // אחרת הוא יכול להכניס מחירים רנדומליים ואז כמובן צריך לתת אפשרות למנהל לשנות את המחיר הקבוע בחנות 
                    //כלומר לשאול האם הקטגוריה שלו והמחיר תואמים לצפיות ואםלא להראות מסך הודעה
                    MessageBox.Show(
                        "The price you entered is incorrect",
                        "Invalid input",
                        MessageBoxButton.OK,
                        MessageBoxImage.Hand);
                    flag = false;
                }
                if (WantedStock < 0)
                {
                    MessageBox.Show(
                        "The stock you entered is incorrect",
                        "Invalid input",
                        MessageBoxButton.OK,
                        MessageBoxImage.Hand);
                    flag = false;
                }
                if (Selected_Category.Text == "")
                {
                    MessageBox.Show(
                     "you didnt choose a Category",
                     "missing input",
                     MessageBoxButton.OK,
                     MessageBoxImage.Hand);
                    flag = false;

                }
                if (SelectedPrint.Text == "")
                {
                    MessageBox.Show(
                    "you didnt choose a Print",
                    "missing input",
                    MessageBoxButton.OK,
                    MessageBoxImage.Hand);
                    flag = false;
                }
                if (flag)//all the inputs are correct
                {
                    //adding the product to BO
                    BO.Product TEMP = bl.Product.createProductByValues(wantedID, SelectedPrint.Text, WantedStock, wantedPrice, Selected_Category.Text);
                    bl.Product.AddProductmaneger(TEMP);
                    //open a new list window(which calls the get all method which updates the list to include this item
                    new PL.ProductListForManager().Show();

                    this.Close();




                }




            }
            catch (BO.IdExistException)
            {

                MessageBox.Show(
                "this item id already Exist",
                "invalid input",
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
        }    }
}
