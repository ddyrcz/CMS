using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace CMS.Common.Converters
{
    class BoolToBrushConverter :IValueConverter
    {        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color color = Colors.Black;

            if (parameter != null)
            {
                color = (Color)ColorConverter.ConvertFromString(parameter.ToString());
            }

            if (value is bool)
            {
                if ((bool)value)
                {
                    return new SolidColorBrush(color);
                }                
            }

            return null;       
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
