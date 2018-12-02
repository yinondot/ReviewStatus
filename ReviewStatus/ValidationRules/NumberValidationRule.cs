using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ReviewStatus.ValidationRules
{
   public class NumberValidationRule : ValidationRule
   {
      public override ValidationResult Validate(object value, CultureInfo cultureInfo)
      {
         int result;
         int.TryParse(value.ToString(), out result);
         if (result!=0)
         {
            return new ValidationResult(true, null);
         }
         return new ValidationResult(false, "The value must be a number");
      }
   }
}
