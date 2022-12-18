using BLApi;
using BlImplementation;
using BO;
using DO;

namespace BLTest;
public enum choice { product = 1, order, cart }
internal class Program
{
    static void Main(string[] args)
    {
        IBl bl = BLApi.Factory.Get();
        BO.Product p=new BO.Product();
        int id;

        Console.WriteLine(@"
enter 
1 for  product 
2 for order
3 for cart
-1 to exit");
        int choice = int.Parse(Console.ReadLine());
        while (choice !=-1)
        {
            switch (choice)
            {

                case 1:
                    #region all of product functions
                    Console.WriteLine(@"
these are the function options :
Enter 1 to get all products 
Enter 2 to get product info(if youre a menager)
Enter 3 to get product info(if youre a client)
Enter 4 to Add product as a menager 
Enter 5 to remove a product as a menager
Enter 6 update product as a mengaer 
Enter 7 to get a product , by its category ");
                    int Functioncoice = 0;
                    switch (Functioncoice)
                    {
                        
                        case 1:
                            #region get all products
                            foreach (BO.ProductForList pfl in bl.Product.GetProducts())
                            {
                                Console.WriteLine(pfl);
                            }
                            break;
                        #endregion
                       
                        case 2:
                            #region get products info maneger
                            try
                            {
                                Console.WriteLine("enter product id");
                                id = int.Parse(Console.ReadLine());
                                p = bl.Product.ProductInfoManeger(id);
                                Console.WriteLine(p);
                                break;
                            }
                            catch(NotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }
                        #endregion
                        
                        case 3:
                            #region get products unfo client
                            try
                            {
                                Console.WriteLine("enter product id");
                                id = int.Parse(Console.ReadLine());
                                BO.cart c = new BO.cart();
                                string temp;
                                Console.WriteLine(@"
enter your name:");
                                temp = Console.ReadLine();
                                c.CustomerName = temp;
                                Console.WriteLine(@"
enter your email addres:");
                                temp = Console.ReadLine();
                                c.CustomerEmail = temp;
                                Console.WriteLine(@"
enter your addres:");
                                temp = Console.ReadLine();
                                c.CustomerAddres = temp;
                                Console.WriteLine(@"
enter the amount of order Items:");
                                int num = int.Parse(Console.ReadLine());
                                for (int i = 0; i < num; i++)
                                {
                                    BO.OrderItem OI = new BO.OrderItem();
                                    Console.WriteLine(@"
enter order id:");
                                    num = int.Parse(Console.ReadLine());
                                    OI.OrderId = num;
                                    Console.WriteLine(@"
enter product id:");
                                    num = int.Parse(Console.ReadLine());
                                    OI.ProductId = num;
                                    Console.WriteLine(@"
enter product name:");
                                    string name = Console.ReadLine();
                                    OI.ProductName = name;
                                    OI.price = 0;//how do i get the price
                                    Console.WriteLine(@"
enter amount of products:");
                                    num = int.Parse(Console.ReadLine());
                                    OI.amount = num;
                                    OI.TotalPrice = OI.amount * OI.price;
                                    c.items.Add(OI);
                                }
                                for (int i = 0; i < c.items.Count(); i++)
                                {
                                    c.price += c.items[i].price;
                                }
                                BO.ProductItem PI = bl.Product.ProductInfoClient(id, c);
                                Console.WriteLine(PI);
                                break;
                            }
                            catch(NotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }
                        #endregion
                        
                        case 4:
                            #region add products as a maneger
                            try
                            {
                                p = new BO.Product();
                                Console.WriteLine(@"
enter product id:");
                                id = int.Parse(Console.ReadLine());
                                p.ID = id;
                                Console.WriteLine(@"
enter product name:");
                                p.Name = Console.ReadLine();
                                Console.WriteLine(@"
enter a for sweatshirt b for sweatpants c for bucket hut d for socks e for T-shirt");
                                string ch= Console.ReadLine();
                                if (ch == "a")
                                {
                                    p.category = BO.Enums.Category.Sweatshirt;
                                    p.Price = 50;
                                }

                                if (ch == "b")
                                {
                                    p.category = BO.Enums.Category.Sweatpant;
                                    p.Price = 40;
                                }
                                if (ch == "c")
                                {
                                    p.category = BO.Enums.Category.BucketHat;
                                    p.Price = 25;
                                }
                                if (ch == "d")
                                {
                                    p.category = BO.Enums.Category.Socks;
                                    p.Price = 15;
                                }
                                if (ch == "e")
                                {
                                    p.category = BO.Enums.Category.Tshirt;
                                    p.Price = 35;
                                }
                                Console.WriteLine(@"
enter products amount in stock");
                                p.instock = int.Parse(Console.ReadLine());
                                bl.Product.AddProductmaneger(p);
                                // עד כאן קליטת הכל ןהכנסה לרשימה
                                Console.WriteLine("enter product id");
                                id = int.Parse(Console.ReadLine());
                                p = bl.Product.ProductInfoManeger(id);
                                Console.WriteLine(p);//הדפסה לבדוק שבאמת נכנס
                                break;
                            }
                            catch(IdExistException ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }
                        #endregion
                        
                        case 5:
                            #region remove a product as a maneger
                            try
                            {
                                Console.WriteLine(@"
enter products id");
                                int id4 = int.Parse(Console.ReadLine());
                                bl.Product.RemoveProductmaneger(id4);
                                p = bl.Product.ProductInfoManeger(id4);
                                Console.WriteLine(p);// if there is a throw it is good
                                break;
                            }
                            catch(NotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }
                        #endregion
                        
                        case 6:
                            #region update product as a mengaer 
                            try
                            {
                                p = new BO.Product();
                                Console.WriteLine(@"
enter product id:");
                                id = int.Parse(Console.ReadLine());
                                p.ID = id;
                                Console.WriteLine(@"
enter product name:");
                                p.Name = Console.ReadLine();
                                Console.WriteLine(@"
enter a for sweatshirt b for sweatpants c for bucket hut d for socks e for T-shirt");
                                string? op1 = Console.ReadLine();
                                if (op1 == "a")
                                {
                                    p.category = BO.Enums.Category.Sweatshirt;
                                    p.Price = 50;
                                }

                                if (op1 == "b")
                                {
                                    p.category = BO.Enums.Category.Sweatpant;
                                    p.Price = 40;
                                }
                                if (op1 == "c")
                                {
                                    p.category = BO.Enums.Category.BucketHat;
                                    p.Price = 25;
                                }
                                if (op1 == "d")
                                {
                                    p.category = BO.Enums.Category.Socks;
                                    p.Price = 15;
                                }
                                if (op1 == "e")
                                {
                                    p.category = BO.Enums.Category.Tshirt;
                                    p.Price = 35;
                                }
                                Console.WriteLine(@"
enter products amount in stock");
                                p.instock = int.Parse(Console.ReadLine());
                                bl.Product.UpdateProductmaneger(p);
                                Console.WriteLine(@"
enter products id");
                                id = int.Parse(Console.ReadLine());
                                p = bl.Product.ProductInfoManeger(id);
                                Console.WriteLine(p);
                                break;
                            }
                            catch(NotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }
                            catch (InValidIdException ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }
                        #endregion
                        
                        case 7:
                            #region get all product by a category
                            Console.WriteLine(@"
enter a for sweatshirt b for sweatpants c for bucket hut d for socks e for T-shirt");
                             string op=Console.ReadLine();
                            BO.Enums.Category ca=new BO.Enums.Category(); 
                            if (op == "a")
                            {
                                ca=BO.Enums.Category.Sweatshirt;
                            }

                            if (op == "b")
                            {
                                ca = BO.Enums.Category.Sweatpant;
                            }
                            if (op == "c")
                            {
                                ca = BO.Enums.Category.BucketHat;
                            }
                            if (op == "d")
                            {
                                ca = BO.Enums.Category.Socks;
                            }
                            if (op == "e")
                            {
                                ca= BO.Enums.Category.Tshirt;
                            }
                            foreach (BO.ProductForList pfl in bl.Product.GetProductsByCategory(ca))
                            {
                                Console.WriteLine(pfl);
                            }
                            break;
                            #endregion
                    }
                    break;
                #endregion

                case 2:
                    #region all of order functions
                    Console.WriteLine(
    @"these are the function options :
Enter 1 to get all orders
Enter 2 to get product info(as a menager AND as a client)
Enter 3 to update ship as a menager
Enter 4 to update delivery as a menager
Enter 5 track an order
");
                    int Functioncoice2 = 0;
                    switch (Functioncoice2)
                    {
                        case 1:
                            #region  get all orders
                            foreach (BO.OrderForList OFL in bl.Order.GETOrders())
                            {
                                Console.WriteLine(OFL);
                            }
                            break;
                        #endregion
                        case 2:
                            #region get order info
                            try
                            {
                                Console.WriteLine("enter orders id");
                                id = int.Parse(Console.ReadLine());
                                BO.Order order = bl.Order.GetOrderInfo(id);
                                Console.WriteLine(order);
                                break;
                            }
                            catch(NotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;  
                            }
                            catch (InValidIdException ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }
                        #endregion
                        case 3:
                            #region update ship as a menager
                            try
                            {
                                Console.WriteLine("enter orders id");
                                id = int.Parse(Console.ReadLine());
                                BO.Order order = bl.Order.UpdateShip(id);
                                Console.WriteLine(order);
                                break;
                            }
                            catch(NotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }
                        #endregion
                        case 4:
                            #region update delivery as a menager
                            try
                            {
                                Console.WriteLine("enter orders id");
                                id = int.Parse(Console.ReadLine());
                                BO.Order order = bl.Order.UpdateDelivery(id);
                                Console.WriteLine(order);
                                break;
                            }
                            catch(NotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                                    break;
                            }
                        #endregion
                        case 5:
                            #region track an order
                            try
                            {
                                Console.WriteLine("enter orders id");
                                id = int.Parse(Console.ReadLine());
                                BO.OrderTracking OB = bl.Order.trackOrder(id);
                                Console.WriteLine(OB);
                                break;
                            }
                            catch(NotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }
                            #endregion
                    }
                    break;
                #endregion
        
                case 3:
                    #region all of cart functions
                    Console.WriteLine(@"
these are the function options :
Enter 1 to add products to a cart 
Enter 2 to update amount in a cart 
Enter 3 to confirm an order 

");
                    int Functioncoice3 = 0;
                    switch (Functioncoice3)
                    {
                        case 1:
                            #region add products to a cart // not finis throw
                            Console.WriteLine("enter product id");
                            id = int.Parse(Console.ReadLine());
                            BO.cart c = new BO.cart();
                            string temp;
                            Console.WriteLine(@"
enter your name:");
                            temp = Console.ReadLine();
                            c.CustomerName = temp;
                            Console.WriteLine(@"
enter your email addres:");
                            temp = Console.ReadLine();
                            c.CustomerEmail = temp;
                            Console.WriteLine(@"
enter your addres:");
                            temp = Console.ReadLine();
                            c.CustomerAddres = temp;
                            Console.WriteLine(@"
enter the amount of order Items:");
                            int num = int.Parse(Console.ReadLine());
                            for (int i = 0; i < num; i++)
                            {
                                BO.OrderItem OI = new BO.OrderItem();
                                Console.WriteLine(@"
enter order id:");
                                num = int.Parse(Console.ReadLine());
                                OI.OrderId = num;
                                Console.WriteLine(@"
enter product id:");
                                num = int.Parse(Console.ReadLine());
                                OI.ProductId = num;
                                Console.WriteLine(@"
enter product name:");
                                string name = Console.ReadLine();
                                OI.ProductName = name;
                                OI.price = 0;//how do i get the price
                                Console.WriteLine(@"
enter amount of products:");
                                num = int.Parse(Console.ReadLine());
                                OI.amount = num;
                                OI.TotalPrice = OI.amount * OI.price;
                                c.items.Add(OI);
                            }
                            for (int i = 0; i < c.items.Count(); i++)
                            {
                                c.price += c.items[i].price;
                            }
                            BO.cart cart = bl.Cart.addProduct(c,id);
                            Console.WriteLine(cart);
                            break;
                        #endregion
                        case 2:
                            #region update amount in a cart 
                            try
                            {
                                Console.WriteLine("enter product id");
                                id = int.Parse(Console.ReadLine());
                                c = new BO.cart();
                                Console.WriteLine(@"
enter your name:");
                                temp = Console.ReadLine();
                                c.CustomerName = temp;
                                Console.WriteLine(@"
enter your email addres:");
                                temp = Console.ReadLine();
                                c.CustomerEmail = temp;
                                Console.WriteLine(@"
enter your addres:");
                                temp = Console.ReadLine();
                                c.CustomerAddres = temp;
                                Console.WriteLine(@"
enter the amount of order Items:");
                                num = int.Parse(Console.ReadLine());
                                for (int i = 0; i < num; i++)
                                {
                                    BO.OrderItem OI = new BO.OrderItem();
                                    Console.WriteLine(@"
enter order id:");
                                    num = int.Parse(Console.ReadLine());
                                    OI.OrderId = num;
                                    Console.WriteLine(@"
enter product id:");
                                    num = int.Parse(Console.ReadLine());
                                    OI.ProductId = num;
                                    Console.WriteLine(@"
enter product name:");
                                    string name = Console.ReadLine();
                                    OI.ProductName = name;
                                    OI.price = 0;//how do i get the price
                                    Console.WriteLine(@"
enter amount of products in cart(not updated):");
                                    num = int.Parse(Console.ReadLine());
                                    OI.amount = num;
                                    OI.TotalPrice = OI.amount * OI.price;
                                    c.items.Add(OI);
                                }
                                for (int i = 0; i < c.items.Count(); i++)
                                {
                                    c.price += c.items[i].price;
                                }
                                Console.WriteLine(@"
enter new amount:");
                                int newAmount = int.Parse(Console.ReadLine());
                                cart = bl.Cart.updateAmountInCart(c, id, newAmount);
                                Console.WriteLine(cart);
                                break;
                            }
                            catch(InValidIdException ex)
                            {
                                Console.WriteLine(ex.Message);
                                    break;
                            }
                        #endregion
                        case 3:
                            #region confirm an order // not finished throw
                            c = new BO.cart();
                            Console.WriteLine(@"
enter your name:");
                            temp = Console.ReadLine();
                            c.CustomerName = temp;
                            Console.WriteLine(@"
enter your email addres:");
                            temp = Console.ReadLine();
                            c.CustomerEmail = temp;
                            Console.WriteLine(@"
enter your addres:");
                            temp = Console.ReadLine();
                            c.CustomerAddres = temp;
                            Console.WriteLine(@"
enter the amount of order Items:");
                            num = int.Parse(Console.ReadLine());
                            for (int i = 0; i < num; i++)
                            {
                                BO.OrderItem OI = new BO.OrderItem();
                                Console.WriteLine(@"
enter order id:");
                                num = int.Parse(Console.ReadLine());
                                OI.OrderId = num;
                                Console.WriteLine(@"
enter product id:");
                                num = int.Parse(Console.ReadLine());
                                OI.ProductId = num;
                                Console.WriteLine(@"
enter product name:");
                                string name = Console.ReadLine();
                                OI.ProductName = name;
                                OI.price = 0;//how do i get the price
                                Console.WriteLine(@"
enter amount of products in cart(not updated):");
                                num = int.Parse(Console.ReadLine());
                                OI.amount = num;
                                OI.TotalPrice = OI.amount * OI.price;
                                c.items.Add(OI);
                            }
                            for (int i = 0; i < c.items.Count(); i++)
                            {
                                c.price += c.items[i].price;
                            }
//לבדוק אם נעשה נכון אין לי מושג איך
                            break;
                            #endregion
                    }
                    break;
                    #endregion
            }
        }
    }
}