using LoveNeuroWinUI3.Helpers;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media.Imaging;
using System;


namespace LoveNeuroWinUI3.Helpers
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
