using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ReviewStatus.Converters
{
   public class CheckBoxToVisibilityConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value is bool)
         {
          bool flag=  System.Convert.ToBoolean(value);
            if (flag)
            {
               return Visibility.Visible;
            }
         }
         return Visibility.Hidden;

      
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         return null;
      }
   }
}
