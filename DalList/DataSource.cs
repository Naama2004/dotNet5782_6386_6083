using DO;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace DAL;

static public class DataSource
{

    public static class config
    {
        internal const int start_Order_Number = 10000;

        internal static int next_Order_Number = start_Order_Number;
        internal static int NextO { get => ++next_Order_Number; }



        internal const int start_OrderItem_Number = 10000;

        internal static int next_OrderItem_Number = start_OrderItem_Number;
        internal static int NextOI { get => ++next_OrderItem_Number; }



        internal const int Start_product_id = 10000;

        internal static int NEXT_product_id = Start_product_id;
        internal static int NextP { get => ++NEXT_product_id; }

        internal const int TSstock = 50;//tSHIRT STOCK 2 LETTERS FOR THE CATEGORY NAME

        private static int Current_TS_stock = TSstock;
        internal static int TS_stock_update { get => --Current_TS_stock; }
        internal const int SSstock = 50;

        private static int Current_SS_stock = SSstock;
        internal static int SS_stock_update { get => --Current_SS_stock; }
        internal const int SPstock = 50;

        private static int Current_SP_stock = SPstock;
        internal static int SP_stock_update { get => --Current_SP_stock; }
        internal const int BHstock = 50;

        private static int Current_BH_stock = BHstock;
        internal static int BH_stock_update { get => --Current_BH_stock; }

        internal const int SKstock = 50;

        private static int Current_SK_stock = SKstock;
        internal static int SK_stock_update { get => --Current_SK_stock; }



    }
    static DataSource()
    {
        s_initalize();
    }

    static readonly Random R = new Random();
    static internal List<Order?> orders { get; } = new List<Order?>();
    static internal List<OrderItem?> ordersItems { get; } = new List<OrderItem?>();
    static internal List<Product?> products { get; } = new List<Product?>();
    static public Product randP()
    {
        Product p = new Product();//a new one to add

        int rand = R.Next(6);// choose a random num less then 6 
        Enums.Category choise = (Enums.Category)rand;
        p.Category = choise;
        rand = R.Next(6);
        switch (rand)
        {
            case 1:
                p.Name = "127.0.0.1 SWEET  127.0.0.1";
                break;
            case 2:
                p.Name = "Hello World!";
                break;
            case 3:
                p.Name = "a";
                break;
            case 4:
                p.Name = "b";
                break;
            case 5:
                p.Name = "c";
                break;

        }
        p.ID = config.NextP;
        switch (choise)
        {
            case Enums.Category.Tshirt:
                p.Price = 30;
                break;
            case Enums.Category.Sweatshirt:
                p.Price = 50;
                break;
            case Enums.Category.Sweatpant:
                p.Price = 40;
                break;
            case Enums.Category.BucketHat:
                p.Price = 25;
                break;
            case Enums.Category.Socks:
                p.Price = 15;
                break;


        }
        switch (choise)
        {


            case Enums.Category.Tshirt:
                p.InStock = config.TS_stock_update;
                break;
            case Enums.Category.Sweatshirt:
                p.InStock = config.SS_stock_update;
                break;
            case Enums.Category.Sweatpant:
                p.InStock = config.SP_stock_update;
                break;
            case Enums.Category.BucketHat:
                p.InStock = config.BH_stock_update;
                break;
            case Enums.Category.Socks:
                p.InStock = config.SK_stock_update;
                break;

        }
        return p;
    }

    static public Order randOrder()
    {
        //order id
        Order O = new Order();
        O.ID = config.NextO;//update id num

        //order date

        DateTime start = new DateTime(2022, 1, 1);//min date
        int range = (DateTime.Today - start).Days;//from start to this day 
        start.AddDays(R.Next(range));//add random amount of days to the start date
        O.OrderDate = start; //update the date   

        //ship Date

        DateTime ship = start;//ship date needs to be after the orderdate
        int range2 = (DateTime.Today - start).Days;
        ship.AddDays(R.Next(range2));//add random amount of days to the start date
        O.ShipDate = ship; //update the date  

        //delivery date
        DateTime delivery = ship;//the ship date needs to be before the delivery date
        int range3 = (DateTime.Today - delivery).Days;//the ship date needs to be before the delivery date
        delivery.AddDays(R.Next(range3));//add random amount of days to the start date
        O.DeliveryDate = delivery; //update the date  

        //costumer name
        Random R2 = new Random();
        int stringlen = R2.Next(3, 9);//random length to the name


        int randValue;
        string str = "";
        char letter;
        for (int i = 0; i < stringlen; i++)
        {

            // Generating a random number.
            randValue = R2.Next(0, 26);

            //turn the number into a char
            letter = Convert.ToChar(randValue + 65);//add 65 to make is ASCII value then make it a string

            // Appending the letter to string.
            str = str + letter;
        }
        O.CustomerName = str;



        //costumer emails
        string Email = O.CustomerName + "@gmail.com";


        //costumer adress
        Random R3 = new Random();
        int stringlength = R3.Next(1, 30);//random length to the name before the @
        int randVal;
        //string adress = "";
       
        for (int i = 0; i < stringlength; i++)
        {

            // Generating a random number.
            randVal = R3.Next(0, 26);

            //turn the number into a char
            letter = Convert.ToChar(randVal + 65);//add 65 to make is ASCII value then make it a string

            // Appending the letter to string.
            str = str + letter;
        }

        str = str + stringlength;
        O.CustomerAddress = str;
        return O;
    }

    static public OrderItem randOI()
    {
        OrderItem temp = new OrderItem();
        int Orand = R.Next(config.start_Order_Number, config.next_Order_Number);
        int Prand = R.Next(config.Start_product_id, config.NEXT_product_id);
        temp.OrderID = Orand;
        temp.ProductID = Prand;
        temp.ID = config.NextOI;
        int stock = 0;
        Enums.Category pCategory = new Enums.Category();
        foreach (Product p in products)
        {
            if (p.ID == Prand)
            {
                stock = (int)p.InStock;
                pCategory = (Enums.Category)p.Category;
                break;
            }
        }
        temp.Amount = R.Next(0, stock);
        switch (pCategory)
        {
            case Enums.Category.Tshirt:
                temp.Price = 30 * temp.Amount;
                break;
            case Enums.Category.Sweatshirt:
                temp.Price = 50 * temp.Amount;
                break;
            case Enums.Category.Sweatpant:
                temp.Price = 40 * temp.Amount;
                break;
            case Enums.Category.BucketHat:
                temp.Price = 25 * temp.Amount;
                break;
            case Enums.Category.Socks:
                temp.Price = 15 * temp.Amount;
                break;
        }
        return temp;
    }

        
        static void s_initalize()//בונה מוצר ואז אורדר ואז אורדר אייתם
        {
            Product tempP = DataSource.randP();
            Order tempO = DataSource.randOrder();
            OrderItem tempOI = DataSource.randOI();
            DalProduct p = new DalProduct();
            DalOrder pO = new DalOrder();
            DalOrderItem OI= new DalOrderItem();
            p.ADD(tempP);
            pO.ADD(tempO);
            OI.ADD(tempOI);
        }
}


