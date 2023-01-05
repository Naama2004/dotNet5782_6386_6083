﻿using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Dal;
using DalApi;
using DO;
sealed internal class DalXml:IDal
{
    public IOrder Order { get; } = new Dal.Order();
    public IProduct Product{ get; } = new Dal.Product();

    public IOrderItem OrderItem{ get; } = new Dal.OrderItem();

}