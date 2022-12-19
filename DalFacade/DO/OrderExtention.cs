using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

public static class OrderExtention
{
    public static List<Tuple<DateTime, string>?>? TrackO(this DO.Order order)
    {
        List<Tuple<DateTime, string>?> list = new List<Tuple<DateTime, string>?>();

        //if (or.DateOrder != null)
        list.Add(new Tuple<DateTime, string>((DateTime)order.OrderDate, "order ordered"));
        if (order.ShipDate != null)
            list.Add(new Tuple<DateTime, string>((DateTime)order.ShipDate, "order shipped"));
        if (order.DeliveryDate != null)
            list.Add(new Tuple<DateTime, string>((DateTime)order.DeliveryDate, "order delivered"));

        return list;
    }
}
