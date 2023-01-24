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
using System.ComponentModel;
using System.Threading;
namespace PL
{

    public partial class OrdersSimulator : Window
    {
        private IBl bl = BLApi.Factory.Get();
        public ObservableCollection<BO.OrderForList> Orders { set; get; }
        public BackgroundWorker Worker { set; get; }  
       static DateTime timer=DateTime.Now;
        public OrdersSimulator()
        {
            InitializeComponent();
            Orders = new ObservableCollection<BO.OrderForList>(bl.Order.GETOrders());
           OrderListview.DataContext = Orders;
            Worker = new BackgroundWorker();
            Worker.DoWork += backgroungWorker_DoWork;
            Worker.ProgressChanged += backgroungWorker_ProgressChanged;
            Worker.RunWorkerCompleted += backgroungWorker_RunWorkerCompleted;

            Worker.WorkerReportsProgress=true;
            Worker.WorkerSupportsCancellation=true;
           // OrderListview.DataContext=Orders;   

        }
        private void backgroungWorker_DoWork(object sender, DoWorkEventArgs e)//לר יכול לגשת לגרפיקה אלא היא תשלח לוורקר פרוגרס בוי=מעי
        {



            while (true)
            {
                if (Worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    if (Worker.WorkerReportsProgress == true)
                    {
                        timer = timer.AddDays(1);
                        Worker.ReportProgress(1);
                  
                       
                    }
                    Thread.Sleep(2000);
                }
            }


        }
       
            


    private void backgroungWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            Orders = new(bl.Order.GETOrders());//כל ההזמנות 
            OrderListview.DataContext = Orders;

            BO.Order temp2 = new BO.Order();

            foreach (var order in Orders)
            {
                BO.Order o = bl.Order.GetOrderInfo(order.OrderId);
                if (o.OrderDate != null && o.ShipDate == null && o.DeliveryDate == null)//עוד לא נשלח 
                {
                    if ((timer - o.OrderDate)?.TotalDays > 2)
                    {
                        temp2 = bl.Order.UpdateShip(o.Id);
                        // Orders.Remove(temp.Find(x => x.OrderId == o.Id)!);
                        // Orders.Add(bl.Order.GetOrderForList(temp2.Id));
                    }
                    //אם עבר 5 ימים מאז שהוא הזמין תשלח 
                    //updat ship 
                }
                else
                {
                    if (o.OrderDate != null && o.ShipDate != null && o.DeliveryDate == null)//עוד לא נשלח 
                    {
                        if ((timer - o.ShipDate)?.TotalDays > 5)
                        {
                            temp2 = bl.Order.UpdateDelivery(o.Id);
                            // Orders.Remove(temp.Find(x => x.OrderId == o.Id)!);
                            //Orders.Add(bl.Order.GetOrderForList(temp2.Id));
                        }
                        //שלחנו והוא לא קיבל
                        //אם עבר 2 ימים מהשילוח תדלבר 
                    }
                }
                //   Orders = new ObservableCollection<BO.OrderForList>(bl.Order.GETOrders());
                //                OrderListview.DataContext = Orders;
               
            }

            //    Orders.Remove(temp.Find(x => x.OrderId == o.Id)!);
            // Orders.Add(bl.Order.GetOrderForList(temp2.Id));
            //temp = new(bl.Order.GETOrders());
            //Orders = new(bl.Order.GETOrders());

        }
        private void backgroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("stopped"
      , "the order tracking was stopped"
      , MessageBoxButton.OK,
      MessageBoxImage.Hand);
            // סיום התהליכון נדפיס הודעה
        }

        private void startTracking_Click(object sender, RoutedEventArgs e)
        {
            if(Worker.IsBusy!=true)
            {
                Worker.RunWorkerAsync("hi");//מפעיל את הדו ווקר ושולח לו רתהארגיומנט פקמרטר 
            }
        }

        private void stopTracking_Click(object sender, RoutedEventArgs e)
        {
            Worker.CancelAsync();
        }
    }
}

