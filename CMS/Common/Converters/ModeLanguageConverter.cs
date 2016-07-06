using CMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CMS.Common.Converters
{
    class ModeLanguageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is ObservableCollection<Mode>)
            {
                return new List<string>()
                {
                    "Odczyt",
                    "Edycja",
                    "Dodawanie",
                    "Usuwanie"
                };
            }

            if (value is Mode)
            {
                Mode mode = (Mode)value;

                switch (mode)
                {
                    case Mode.Read: return "Odczyt";
                    case Mode.Edit: return "Edycja";
                    case Mode.Add: return "Dodawanie";
                    case Mode.Remove: return "Usuwanie";
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = value.ToString();

            if (string.IsNullOrEmpty(str)) return null;

            switch (str)
            {
                case "Odczyt": return Mode.Read;
                case "Edycja": return Mode.Edit;
                case "Dodawanie": return Mode.Add;
                case "Usuwanie": return Mode.Remove;

            }

            return null;
        }
    }
}
