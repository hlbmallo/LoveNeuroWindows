using NerveCentreW10.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace NerveCentreW10.Helpers
{
    public class CloudClasssVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
                var cloudClass = new CloudClass();
                return cloudClass.GetBlobSasUri(value.ToString());
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
