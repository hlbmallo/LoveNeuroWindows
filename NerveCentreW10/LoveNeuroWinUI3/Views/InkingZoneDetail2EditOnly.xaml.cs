using LoveNeuroWinUI3.Helpers;
using LoveNeuroWinUI3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LoveNeuroWinUI3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InkingZoneDetail2EditOnly : Page
    {
        public InkingZoneDetail2EditOnly()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var cloudClass = new CloudClass();
            var param = e.Parameter as InkingZoneClassDetail;
            var imageFromCloud = cloudClass.GetBlobSasUri(param.InkingZoneImageName);
            var stream = GetStreamFromUrl(imageFromCloud);
            IRandomAccessStream randomAccessStream = stream.AsRandomAccessStream();
            MyIE.Image = randomAccessStream;
            byte[] byteArray = Encoding.ASCII.GetBytes(param.InkingZoneEdits);
            MemoryStream secondStream = new MemoryStream(byteArray);
            MyIE.LoadEdits(secondStream);
           // var temp = File.ReadAllText(ApplicationData.Current.LocalFolder.Path + "\\" + param.InkingZoneTitle + ".txt");
        }

        private static Stream GetStreamFromUrl(string url)
        {
            byte[] imageData = null;

            using (var wc = new System.Net.WebClient())
                imageData = wc.DownloadData(url);

            return new MemoryStream(imageData);
        }
    }
}
