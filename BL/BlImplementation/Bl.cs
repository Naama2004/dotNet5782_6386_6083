using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BO;
namespace BlImplementation;

sealed public class Bl : IBl
{
    public ICart Cart => new BOcart();
    public IProduct Product => new BOProduct();
    public IOrder Order => new BOOrder();

}
