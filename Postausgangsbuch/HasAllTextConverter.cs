using PabDbLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Postausgangsbuch
{
    public class HasAllTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool res = true;

            foreach (object val in values)
            {
                if (val == null)
                { res = false; }
                else if (val.GetType() == typeof(string))
                {
                    if (string.IsNullOrEmpty(val as string))
                    {
                        res = false;
                    }
                }
                else
                {
                    var p = val as Person;
                    if (p == null)
                    {
                        res = false;
                    }
                }

            }

            return res;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
