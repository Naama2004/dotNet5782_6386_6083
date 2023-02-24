using BO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using MaterialDesignThemes.Wpf;
using System.Windows.Media;

using System.IO;

using System.Windows.Media.Imaging;
namespace PL
{ 

    public class StateToValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ProgressBar progress = new ProgressBar();
            switch ((BO.Enums.State)value)
            {
                case BO.Enums.State.approved:
                    return 10;
                    //  progress.Background = Brushes.Pink;
                  //  break;
                case BO.Enums.State.send:
                    return  50;
                    //  progress.Background = Brushes.Orange;
                  //  break;
                case BO.Enums.State.provided:
                    return 100;
                    // progress.Background = Brushes.Green;
                    //break;
            }
            return 0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //we will never use this
            return value;
        }
    }

    //public class StateToColorConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
            
    //        switch ((BO.Enums.State)value)
    //        {
    //            case BO.Enums.State.approved:
    //            return Brushes.Pink;
    //            case BO.Enums.State.send:
    //            return Brushes.Orange;
    //            case BO.Enums.State.provided:
    //            return Brushes.Green;
    //        }
    //        return  Brushes.Green; 
    //    }
    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        //we will never use this
    //        return value;
    //    }
    //}

}


