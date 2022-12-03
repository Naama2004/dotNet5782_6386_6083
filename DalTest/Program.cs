using DAL;
using DalList;
using DO;
using System.Collections.Specialized;
using System.Security.Cryptography;

public class Test
{

    public static void Main(string[] args)
    {
        DalProduct temp = new DalProduct();
        DalOrder order = new DalOrder();
        DalOrderItem Oitem = new DalOrderItem();
        
        Console.WriteLine(@"
press 1 to add 
press 2 to get  
press 3 delete
press 4 to update
enter -1 to exit ");
        int ch1 = Convert.ToInt32(Console.ReadLine());
        while (ch1 != -1)
        {
            switch (ch1)
            {
                case 1:
                    Console.WriteLine(@"
press 1 for product
press 2 for order 
press 3 for orderitem");
                    int ch2 = Convert.ToInt32(Console.ReadLine());
                    switch (ch2)//add what?
                    {
                        case 1://add proct
                            Console.WriteLine(@"enter id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Product p = new Product();
                            p.ID = id;
                            Console.WriteLine(@"enter a for sweatshirt b for sweatpants c for bucket hut d for socks e for T-shirt");
                            string? op = Console.ReadLine();
                            if (op == "a")
                            {
                                p.Category = Enums.Category.Sweatshirt;
                                p.Price = 50;
                            }

                            if (op == "b")
                            {
                                p.Category = Enums.Category.Sweatpant;
                                p.Price = 40;
                            }
                            if (op == "c")
                            {
                                p.Category = Enums.Category.BucketHat;
                                p.Price = 25;
                            }
                            if (op == "d")
                            {
                                p.Category = Enums.Category.Socks;
                                p.Price = 15;
                            }
                            if (op == "e")
                            {
                                p.Category = Enums.Category.Tshirt;
                                p.Price = 35;
                            }
                            Console.WriteLine("Enter name of pruduct");
                            string? name = Console.ReadLine();
                            p.Name = name;
                            temp.ADD(p);
                            break;

                        case 2:
                            Order order1 = new Order();
                            Console.WriteLine("enter order id");
                            int num4 = Convert.ToInt32(Console.ReadLine());
                            order1.ID = num4;
                            Console.WriteLine("enter your name");
                            string? temp1 = Console.ReadLine();
                            order1.CustomerName = temp1;
                            Console.WriteLine("enter your email address");
                            temp1 = Console.ReadLine();
                            order1.CustomerEmail = temp1;
                            Console.WriteLine("enter your address");
                            temp1 = Console.ReadLine();
                            order1.CustomerAddress = temp1;
                            DateTime dates = new DateTime();
                            Console.WriteLine("enter orders date");
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddYears(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddMonths(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddDays(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddHours(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddMinutes(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddSeconds(num4);
                            order1.OrderDate = dates;

                            Console.WriteLine("enter ship date");
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddYears(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddMonths(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddDays(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddHours(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddMinutes(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddSeconds(num4);
                            order1.ShipDate = dates;

                            Console.WriteLine("enter delivery date");
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddYears(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddMonths(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddDays(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddHours(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddMinutes(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddSeconds(num4);
                            order1.DeliveryDate = dates;
                            order.ADD(order1);
                            break;

                        case 3:
                            int num1;
                            OrderItem oi = DataSource.randOI();
                            Console.WriteLine("enter orderItem id:");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            oi.ID = num1;
                            Console.WriteLine("enter order id:");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            oi.OrderID = num1;
                            Console.WriteLine("enter product id:");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            oi.ProductID = num1;
                            //Console.WriteLine("enter anoumt:");
                            //num1 = Convert.ToInt32(Console.ReadLine());
                            Product price = new Product();
                            price = temp.GET(num1);
                            Console.WriteLine("enter anoumt:");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            oi.Amount = num1;
                            Enums.Category category = new Enums.Category();
                            category = (Enums.Category)price.Category;
                            if (category == Enums.Category.Sweatshirt)
                                oi.Price = num1 * 50;
                            if (category == Enums.Category.Sweatpant)
                                oi.Price = num1 * 40;
                            if (category == Enums.Category.BucketHat)
                                oi.Price = num1 * 25;
                            if (category == Enums.Category.Socks)
                                oi.Price = num1 * 15;
                            if (category == Enums.Category.Tshirt)
                                oi.Price = num1 * 35;
                            Oitem.ADD(oi);
                            break;
                    }
                    break;
                case 2://get
                    Console.WriteLine(@"
press 1 for product
press 2 for order
press 3 for order item");
                    int num = new int();
                    int numhelp = new int();
                    num = Convert.ToInt32(Console.ReadLine());
                    switch (num)
                    {
                        
                        case 1:
                            Product p = new Product();
                            Console.WriteLine("enter product id");
                            
                            numhelp = int.Parse(Console.ReadLine());
                            p = temp.GET(numhelp);
                            Console.WriteLine(p);
                            //p.ToString();
                            break;
                        case 2:
                            Order? O = new Order();
                            Console.WriteLine("enter order id");
                            numhelp = int.Parse(Console.ReadLine());
                            O = order.GET(numhelp);
                            Console.WriteLine(O);
                            //O.ToString();
                            break;
                        case 3:
                            OrderItem? OI = new OrderItem();
                            Console.WriteLine("enter orderittem id");
                            numhelp = int.Parse(Console.ReadLine());
                            OI = Oitem.GET(numhelp);
                            Console.WriteLine(OI);
                            //OI.ToString();
                            break;
                    }
                    break;
                case 4:
                    Console.WriteLine(@"press 1 for product
                                    press 2 for order
                                    press 3 for order item");
                    int num2 = new int();
                    num2 = Convert.ToInt32(Console.ReadLine());
                    switch (num2)
                    {
                        case 1:
                            Console.WriteLine(@"enter id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Product p = new Product();
                            p.ID = id;
                            Console.WriteLine(@"enter a for sweatshirt b for sweatpants c for bucket hut d for socks e for T-shirt");
                            string? op = Console.ReadLine();
                            if (op == "a")
                            {
                                p.Category = Enums.Category.Sweatshirt;
                                p.Price = 50;
                            }

                            if (op == "b")
                            {
                                p.Category = Enums.Category.Sweatpant;
                                p.Price = 40;
                            }
                            if (op == "c")
                            {
                                p.Category = Enums.Category.BucketHat;
                                p.Price = 25;
                            }
                            if (op == "d")
                            {
                                p.Category = Enums.Category.Socks;
                                p.Price = 15;
                            }
                            if (op == "e")
                            {
                                p.Category = Enums.Category.Tshirt;
                                p.Price = 35;
                            }
                            string? name = Console.ReadLine();
                            p.Name = name;
                            temp.UPDATE(p);
                            break;
                        case 2:
                            Order order1 = new Order();
                            Console.WriteLine("enter order id");
                            int num4 = Convert.ToInt32(Console.ReadLine());
                            order1.ID = num4;
                            Console.WriteLine("enter your name");
                            string? temp1 = Console.ReadLine();
                            order1.CustomerName = temp1;
                            Console.WriteLine("enter your email address");
                            temp1 = Console.ReadLine();
                            order1.CustomerEmail = temp1;
                            Console.WriteLine("enter your address");
                            temp1 = Console.ReadLine();
                            order1.CustomerAddress = temp1;
                            DateTime dates = new DateTime();
                            Console.WriteLine("enter orders date");
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddYears(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddMonths(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddDays(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddHours(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddMinutes(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddSeconds(num4);
                            order1.OrderDate = dates;

                            Console.WriteLine("enter ship date");
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddYears(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddMonths(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddDays(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddHours(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddMinutes(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddSeconds(num4);
                            order1.ShipDate = dates;

                            Console.WriteLine("enter delivery date");
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddYears(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddMonths(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddDays(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddHours(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddMinutes(num4);
                            num4 = Convert.ToInt32(Console.ReadLine());
                            dates.AddSeconds(num4);
                            order1.DeliveryDate = dates;
                            order.UPDATE(order1);
                            break;

                        case 3:
                            int num1;
                            OrderItem oi = DataSource.randOI();
                            Console.WriteLine("enter orderItem id:");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            oi.ID = num1;
                            Console.WriteLine("enter order id:");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            oi.OrderID = num1;
                            Console.WriteLine("enter product id:");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            oi.ProductID = num1;
                            //Console.WriteLine("enter anoumt:");
                            //num1 = Convert.ToInt32(Console.ReadLine());
                            Product price = new Product();
                            price = temp.GET(num1);
                            Console.WriteLine("enter anoumt:");
                            num1 = Convert.ToInt32(Console.ReadLine());
                            oi.Amount = num1;
                            Enums.Category? category = new Enums.Category();
                            category = (Enums.Category)price.Category;
                            if (category == Enums.Category.Sweatshirt)
                                oi.Price = num1 * 50;
                            if (category == Enums.Category.Sweatpant)
                                oi.Price = num1 * 40;
                            if (category == Enums.Category.BucketHat)
                                oi.Price = num1 * 25;
                            if (category == Enums.Category.Socks)
                                oi.Price = num1 * 15;
                            if (category == Enums.Category.Tshirt)
                                oi.Price = num1 * 35;
                            Oitem.UPDATE(oi);
                            break;

                    }
                    break;

                case 3:
                    Console.WriteLine(@"press 1 for product
                                    press 2 for order
                                    press 3 for order item");
                    int tempid = new int();
                    int number = Convert.ToInt32(Console.ReadLine());
                    switch (number)
                    {
                        case 1:
                            Console.WriteLine("enter id");
                            tempid = Convert.ToInt32(Console.ReadLine());
                            temp.DELETE(tempid);
                            break;
                        case 2:
                            Console.WriteLine("enter id");
                            tempid = Convert.ToInt32(Console.ReadLine());
                            order.DELETE(tempid);
                            break;
                        case 3:
                            Console.WriteLine("enter id");
                            tempid = Convert.ToInt32(Console.ReadLine());
                            //int.Parse(Console.ReadLine());

                            Oitem.DELETE(tempid);
                            break;
                        default: break;
                    }
                    break;
            
            }

    
        Console.WriteLine(@"
press 1 to add 
press 2 to get  
press 3 delete
press 4 to update
enter -1 to exit ");
        ch1 = Convert.ToInt32(Console.ReadLine());
        }
    }
}


    

