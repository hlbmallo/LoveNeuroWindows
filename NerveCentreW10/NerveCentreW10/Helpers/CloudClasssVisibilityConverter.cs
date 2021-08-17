using NerveCentreW10.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace NerveCentreW10.Helpers
{
    public class CloudClasssVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var cloudClass = new CloudClass();
            if (value != null)
            {
                var tempString = cloudClass.GetBlobSasUri(value.ToString());
                var imageSource = new BitmapImage();
                imageSource.UriSource = new Uri(tempString);
                return imageSource;
            }
            else
            {
                var imageSource = new BitmapImage();
                imageSource.UriSource = new Uri("https://thegoofyanatomist.weebly.com/uploads/3/0/9/9/30995885/editor/monochrome-on-transparent.png?1626979715");
                return imageSource;
            }
       
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
