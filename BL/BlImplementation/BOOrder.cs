
////using System;
////using System.Collections.Generic;
////using System.Dynamic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;
////using BLApi;

//using DAL;
//using DO;

//namespace BlImplementation;

//public class BOOrder : IOrder
//{
//    public IEnumerable<BO.OrderForList> GETOrders()
//    {
//        DalOrder TO = new DalOrder();
//        List<DO.Order> doOrderList = TO.GetAll().ToList();
//        return (from O in doOrderList
//                    let OrderFromBl = TO.GET(O.ID) למה צריך לט 
//                select new BO.OrderForList()
//                {
//                    OrderId = O.ID,
//                    state = BO.Enums.State.approved,
//                    Amount = 0,
//                    TotalPrice = 0,
//                }).ToList();
//         שלושת השדות האחרונים צריך לבדוק איך יודעים אותם
//    }
//}

//public BO.Order GetOrderDetails(int id)
//{
//    if (id > 0)
//    {
//        DalOrder temp = new DalOrder();
//        try
//        {
//            DO.Order wantedOrder = temp.GET(id);
//            BO.Order returnOrder = new BO.Order();
//            returnOrder.Id = wantedOrder.ID;
//            returnOrder.CustomerName = wantedOrder.CustomerName;
//            returnOrder.CustomerEmail = wantedOrder.CustomerEmail;
//            returnOrder.CustomerAddres = wantedOrder.CustomerAddress;
//            returnOrder.OrderDate = wantedOrder.OrderDate;
//            returnOrder.ShipDate = wantedOrder.ShipDate;
//            returnOrder.DeliveryDate = wantedOrder.DeliveryDate;
//             חסר רשימת מוצרים, סטטוס מחיר וכו
//            return returnOrder;
//        }
//        catch
//        {
//            throw new Exception("dfgh");
//             תפיסה וזריקה
//        }

//    }
//    throw new Exception("dfgh");
//    זריקה
//}

//public BO.Order UpdateShip(int id)
//{
//    try
//    {
//        עדכון בשכבת הנתונים 
//        DalOrder help = new DalOrder();
//        DO.Order temp = help.GET(id);
//        temp.OrderDate = DateTime.Today;
//        עדכון בשכבת הלוגיקה 


//        if (temp.State != BO.Enums.State.send)
//        {


//            DO.Order updated = new DO.Order();
//            updated
//            help.UPDATE()
//        }

//    }

//}