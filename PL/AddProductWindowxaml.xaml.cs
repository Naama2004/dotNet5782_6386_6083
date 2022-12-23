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

    /// the same window is used for adding a product and for updating one, when adding is needed the window is constructed by a 
    /// constructor that doed not get any value it just initialize the components and binds the combo boxes to the enuums
    /// the other constructor , which is used TO UPDATE a product builds the same components but puts in the values that where
    /// sent to him as values
    /// each option has its on buttnwhich is used to confirm the action (adding or updating)

    public partial class AddOrUpdateProductWindow : Window
    {
        BLApi.IBl? bl = BLApi.Factory.Get();


        public AddOrUpdateProductWindow()
        {

            InitializeComponent();
            ConfirmAdding.Visibility = System.Windows.Visibility.Visible;
            confirmUpdatingProduct.Visibility = System.Windows.Visibility.Hidden;
            //binding


            //make the category combo box be the category enums options
            ///Selected_Category.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            //make the prints combo box be the print enum options
            // SelectedPrint.ItemsSource=Enum.GetValues(typeof(BO.Enums.print));



            //לקשר דברים דרך הזאמל
            //ההבדל בין show ל showdialog

            //נלאבלים בכל הפורייקט
            //לשנות את השדה שם רשמית לפרינט 

            //אני עושה באטן מוחבא אבל לא אינאבל עדיין אפשר ללחוץ עליו?
            //ביצירה של פרודוקט חדש אנחנו שולחים לו כקטגוריה טקסט כי עוד לא עשינו ביידינג צריך לשנות את זה 
            // הזריקות של העדכון נכנסות בזריקות של ההוספה? תפיסות אם לא להוסיף
        }
     public AddOrUpdateProductWindow(BO.Product productToUpdate) 
        {
            InitializeComponent();

            //binding

            SelectedId.Text=productToUpdate.ID.ToString();
            SelectedId.IsEnabled = false;
            SelectedPrice.Text=productToUpdate.Price.ToString();
            Selected_Instock.Text=productToUpdate.instock.ToString();
            //Selected_Category = productToUpdate.category;
            //SelectedPrint=productToUpdate.Name

            
            ConfirmAdding.Visibility = System.Windows.Visibility.Hidden;
            confirmUpdatingProduct.Visibility = System.Windows.Visibility.Visible;




        }



        private void ConfirmAdding_Click(object sender, RoutedEventArgs e, bool isUpdating = false)
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
                    BO.Product TEMP = bl.Product.createProductByValues(wantedID, SelectedPrint.Text, WantedStock, wantedPrice, Selected_Category.Text);
                    if (isUpdating==true)
                    {
                        bl.Product.UpdateProductmaneger(TEMP);
                    }
                    //adding the product to BO
                   else
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

        }

        private void confirmUpdatingProduct_Click(object sender, RoutedEventArgs e)
        {
            //build a new product based on the valuse and attempt to update it 
            //in order to save needless repittion (the adding function does exactly the same exept from one line),
            //this function will call the adding function with a paramert to show that this time uptating in needed
            //of courrse the parameter has a deafult value so the function works fine on its own 
            ConfirmAdding_Click(sender, e, true);
            //the needed catchs will be on the adding function
            


            //whats worst needless repitition or higher dependence??



        }
    }
}
