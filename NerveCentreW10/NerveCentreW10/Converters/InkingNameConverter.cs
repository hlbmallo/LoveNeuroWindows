using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace NerveCentreW10.Converters
{
    class InkingNameConverter : IValueConverter
    {
        public string temp2;

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }
            var temp = value.ToString();
            if (temp.Contains(".txt"))
            {
                temp2 = temp;
            }
            return temp2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
