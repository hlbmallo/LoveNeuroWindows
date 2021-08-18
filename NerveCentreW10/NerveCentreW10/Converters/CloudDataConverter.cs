using Azure.Storage.Blobs;
using NerveCentreW10.Helpers;
using NerveCentreW10.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Xamarin.Essentials;

namespace NerveCentreW10.Converters
{
    public class CloudDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            CloudClass cloudClass = new CloudClass();
            BlobClient cloudBlockBlob = new BlobClient(new Uri(cloudClass.GetBlobSasUri(value.ToString())));

            var filename = "lnw.json";
            var path = Path.Combine(FileSystem.CacheDirectory, filename);

            var tempStream = new MemoryStream();
            cloudBlockBlob.DownloadTo(tempStream);

            using (var fileStream = File.Create(path))
            {
                tempStream.Seek(0, SeekOrigin.Begin);
                tempStream.CopyTo(fileStream);
            }

            var contentToBeRead = File.ReadAllText(path);

            ObservableCollection<QuizClass> myObsColl = JsonConvert.DeserializeObject<ObservableCollection<QuizClass>>(contentToBeRead);
            return myObsColl;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
