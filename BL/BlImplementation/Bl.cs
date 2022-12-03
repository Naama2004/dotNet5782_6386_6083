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
    public ICart Cart => new cart();
    public IProduct Product => new Product();
    public IOrder Order => new Order();

}
