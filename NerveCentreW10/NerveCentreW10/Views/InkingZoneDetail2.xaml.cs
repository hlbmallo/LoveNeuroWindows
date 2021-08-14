using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using NerveCentreW10.Helpers;
using NerveCentreW10.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Xamarin.Essentials;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InkingZoneDetail2 : Page
    {
        public string inkingZoneImageName { get; set; }

        public InkingZoneDetail2()
        {
            this.InitializeComponent();
            MyIE.SetToolbarItemVisibility("save,reset,undo,redo", false);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Analytics
            Analytics.TrackEvent(this.GetType().Name);

            //Navigation Parameter Assigning
            var param = e.Parameter as InkingZoneClassDetail;
            var cloudClass = new CloudClass();
            inkingZoneImageName = param.InkingZoneImage;
            var imageFromCloud = cloudClass.GetBlobSasUri(inkingZoneImageName);
            var stream = GetStreamFromUrl(imageFromCloud);
            IRandomAccessStream randomAccessStream = stream.AsRandomAccessStream();
            MyIE.Image = randomAccessStream;
        }

        private static Stream GetStreamFromUrl(string url)
        {
            byte[] imageData = null;

            using (var wc = new System.Net.WebClient())
                imageData = wc.DownloadData(url);

            return new MemoryStream(imageData);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MyIE.Save();
        }
        public byte[] myOverallBytes;

        private async void MyIE_ImageSaving(object sender, Syncfusion.UI.Xaml.ImageEditor.ImageSavingEventArgs args)
        {
            args.Cancel = true;

            var myDialog = await UserDialogs.Instance.PromptAsync(new PromptConfig
            {
                InputType = InputType.Default,
                CancelText = "Cancel",
                IsCancellable = true,
                Placeholder = "Give your annotation a name",
                OkText = "Save",
                Title = "Save",
            });

            if (myDialog.Ok && !string.IsNullOrWhiteSpace(myDialog.Text))
            {



                var lol = args.Stream;

                var memoryStream2 = new MemoryStream();
                lol.CopyTo(memoryStream2);
                myOverallBytes = memoryStream2.ToArray();




                var tempFlashCardTallStructure = new InkingZoneClassDetail
                {
                    InkingZoneId = new Guid().ToString(),
                    InkingZoneTitle = myDialog.Text,
                    InkingZoneBytes = myOverallBytes,
                    InkingZoneDate = DateTime.Now,
                };

                var serializedContent = JsonConvert.SerializeObject(tempFlashCardTallStructure);

                StorageFolder appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("InkFolder", CreationCollisionOption.OpenIfExists);
                StorageFile storageFile = await appFolder.CreateFileAsync(myDialog.Text + ".txt");
                await FileIO.WriteTextAsync(storageFile, serializedContent);


            }
        }

        private async void MyIE_ImageSaved(object sender, Syncfusion.UI.Xaml.ImageEditor.ImageSavedEventArgs args)
        {
            var contentDialog = new ContentDialog();
            contentDialog.Content = new TextBlock()
            {
                Text = "Your diagram has been saved at: " + args.Location,
                TextWrapping = TextWrapping.Wrap,
            };

            await contentDialog.ShowAsync();
            
        }

        private async void SaveAsInkStrokesButton_Click(object sender, RoutedEventArgs e)
        {

            var myDialog = await UserDialogs.Instance.PromptAsync(new PromptConfig
            {
                InputType = InputType.Default,
                CancelText = "Cancel",
                IsCancellable = true,
                Placeholder = "Give your ink strokes a name",
                OkText = "Save",
                Title = "Save",                
            });

            if (myDialog.Ok && !string.IsNullOrWhiteSpace(myDialog.Text))
            {






                var edits = MyIE.SaveEdits();
                //// File name  
                //string filePath = ApplicationData.Current.LocalFolder.Path + "/tempStream.txt";
                //StreamWriter writer = new StreamWriter(filePath);
                //writer.Write(edits);

                // convert stream to string
                StreamReader reader = new StreamReader(edits);
                string text = reader.ReadToEnd();

                var o = new InkingZoneClassDetail()
                {
                    InkingZoneEdits = text,
                    InkingZoneTitle = myDialog.Text,
                    InkingZoneId = new Guid().ToString(),
                    InkingZoneImageName = inkingZoneImageName,
                };

                var serializedContent = JsonConvert.SerializeObject(o);
                StorageFolder appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("InkingFolder", CreationCollisionOption.OpenIfExists);
                File.WriteAllText(appFolder.Path + "\\" + myDialog.Text + ".txt", serializedContent);

            }
        }
    }
}
