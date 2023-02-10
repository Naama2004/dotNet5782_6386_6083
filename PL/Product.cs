using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PL;

public class Product
{
    public int ProductId { get; set; }
    public string? Print { get; set; }
    public double? price { get; set; }
    public BO.Enums.Category Category { get; set; }

   // public ImageBrush ImageSource { get; set; }
   public BitmapImage? ImageSource { get; set; }
   //public string? ImageSource { get; set; }
}
