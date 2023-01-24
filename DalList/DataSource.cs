using DO;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace Dal;

 public static class DataSource
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
    static internal List<Product?> Products { get; } = new List<Product?>();
    static public Product randP()
    {
        Product p = new Product();//a new one to add

        int rand = R.Next(5);// choose a random num less then 6 
        DO.Enums.Category choise = (DO.Enums.Category)rand;
        p.Category = choise;
        rand = R.Next(5);
        switch (rand)
        {
            case 0:
                p.Print = "127.0.0.1 SWEET 127.0.0.1";
                break;
            case 1:
                p.Print = "Hello World!";
                break;
            case 2:
                p.Print = "give me a </br>";
                break;
            case 3:
                p.Print = "2B || !2B";
                break;
            case 4:
                p.Print = "roses are #FF0000 vilets are #0000FF";
                break;
        }

        p.ID = config.NextP;
        switch (choise)
        {
            case Enums.Category.Tshirt:
                p.Price = (int)DO.Enums.Price.Tshirt;
                break;
            case Enums.Category.Sweatshirt:
                p.Price = (int)DO.Enums.Price.Sweatshirt;
                break;
            case Enums.Category.Sweatpant:
                p.Price = (int)DO.Enums.Price.Sweatpant;
                break;
            case Enums.Category.BucketHat:
                p.Price = (int)DO.Enums.Price.BucketHat;
                break;
            case Enums.Category.Socks:
                p.Price = (int)DO.Enums.Price.Socks;
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
        Random rand = new Random();
        int state=rand.Next(1,3);  
        switch (state)
        {
            case 3:
                {
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
                    break;
                }
            case 2:
                {
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
                    O.CustomerName = null;
                    break;
                }
            case 1:
                {
                    //order date
                    DateTime start = new DateTime(2022, 1, 1);//min date
                    int range = (DateTime.Today - start).Days;//from start to this day 
                    start.AddDays(R.Next(range));//add random amount of days to the start date
                    O.OrderDate = start; //update the date   

                    O.ShipDate = null;
                    O.CustomerName = null;
                    break;
                }
                //
        }
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
        foreach (Product p in Products)
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
                temp.Price = (int)DO.Enums.Price.Tshirt * temp.Amount;
                break;
            case Enums.Category.Sweatshirt:
                temp.Price = (int)DO.Enums.Price.Sweatshirt* temp.Amount;
                break;
            case Enums.Category.Sweatpant:
                temp.Price = (int)DO.Enums.Price.Sweatpant* temp.Amount;
                break;
            case Enums.Category.BucketHat:
                temp.Price = (int)DO.Enums.Price.BucketHat* temp.Amount;
                break;
            case Enums.Category.Socks:
                temp.Price = (int)DO.Enums.Price.Socks* temp.Amount;
                break;
        }
        return temp;
    }

        
        static void s_initalize()//בונה מוצר ואז אורדר ואז אורדר אייתם
        {
        DalProduct p = new DalProduct();
        DalOrder pO = new DalOrder();
        DalOrderItem OI = new DalOrderItem();
        Product P1 = DataSource.randP();
        Product P2 = DataSource.randP();
        Product P3 = DataSource.randP();
        Product P4 = DataSource.randP();
        Product P5 = DataSource.randP();
        Product P6 = DataSource.randP();
        Product P7 = DataSource.randP();
        Product P8 = DataSource.randP();
        Product P9 = DataSource.randP();
        Product P10 = DataSource.randP();
        p.ADD(P1);
        p.ADD(P2);
        p.ADD(P3);
        p.ADD(P4);
        p.ADD(P5);
        p.ADD(P6);
        p.ADD(P7);
        p.ADD(P8);
        p.ADD(P9);
        p.ADD(P10);
        Order O1 = DataSource.randOrder();
        Order O2 = DataSource.randOrder();
        Order O3 = DataSource.randOrder();
        Order O4 = DataSource.randOrder();
        Order O5 = DataSource.randOrder();
        Order O6 = DataSource.randOrder();
        Order O7 = DataSource.randOrder();
        Order O8 = DataSource.randOrder();
        Order O9 = DataSource.randOrder();
        Order O10 = DataSource.randOrder();
        Order O11 = DataSource.randOrder();
        Order O12 = DataSource.randOrder();
        Order O13 = DataSource.randOrder();
        Order O14 = DataSource.randOrder();
        Order O15 = DataSource.randOrder();


        pO.ADD(O1);
        pO.ADD(O2);
        pO.ADD(O3);
        pO.ADD(O4);
        pO.ADD(O5);
        pO.ADD(O6);
        pO.ADD(O7);
        pO.ADD(O8);
        pO.ADD(O9);
        pO.ADD(O10);
        pO.ADD(O11);
        pO.ADD(O12);
        pO.ADD(O13);
        pO.ADD(O14);
        pO.ADD(O15);

        OrderItem OI1 = DataSource.randOI();
        OrderItem OI2 = DataSource.randOI();
        OrderItem OI3 = DataSource.randOI();
        OrderItem OI4 = DataSource.randOI();
        OI.ADD(OI1);
        OI.ADD(OI2);
        OI.ADD(OI3);
        OI.ADD(OI4);
    }
}


