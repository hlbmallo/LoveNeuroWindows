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
using System.Text;
using System.Threading.Tasks;
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

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InkingZoneDetail2EditOnly : Page
    {
        public string inkingZoneImageName { get; set; }
        public ContentDialog dialog;
        public ContentDialog contentDialog2;
        public ContentDialog contentDialog3;
        public byte[] myOverallBytes;

        public InkingZoneDetail2EditOnly()
        {
            this.InitializeComponent();
            MyIE.SetToolbarItemVisibility("save,reset,undo,redo", false);
            Analytics.TrackEvent(this.GetType().Name);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var cloudClass = new CloudClass();
            var param = e.Parameter as InkingZoneClassDetail;
            inkingZoneImageName = param.InkingZoneImageName;

            var imageFromCloud = cloudClass.GetBlobSasUri(param.InkingZoneImageName);
            var stream = GetStreamFromUrl(imageFromCloud);
            IRandomAccessStream randomAccessStream = stream.AsRandomAccessStream();
            MyIE.Image = randomAccessStream;
            byte[] byteArray = Encoding.ASCII.GetBytes(param.InkingZoneEdits);
            MemoryStream secondStream = new MemoryStream(byteArray);
            MyIE.LoadEdits(secondStream);
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

        private async void MyIE_ImageSaving(object sender, Syncfusion.UI.Xaml.ImageEditor.ImageSavingEventArgs args)
        {
            dialog = new ContentDialog();
            dialog.Title = "Save your annotation as an image?";
            dialog.PrimaryButtonText = "Save";
            dialog.SecondaryButtonText = "Don't Save";
            dialog.CloseButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Primary;
            dialog.PrimaryButtonClick += Dialog_PrimaryButtonClick;

            await dialog.ShowAsync();
        }


        private async void Dialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            dialog.Hide();
            contentDialog2 = new ContentDialog();
            contentDialog2.Title = "Saved";
            contentDialog2.PrimaryButtonText = "Ok";
            contentDialog2.DefaultButton = ContentDialogButton.Primary;
            contentDialog2.PrimaryButtonClick += ContentDialog2_PrimaryButtonClick; ;

            contentDialog2.Content = new TextBlock()
            {
                Text = "Your diagram has been saved at: This PC >> Pictures >> Saved Pictures >> LoveNeuro",
                TextWrapping = TextWrapping.Wrap,
            };

            await contentDialog2.ShowAsync();
        }

        private void ContentDialog2_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            contentDialog2.Hide();
        }

        public async Task<bool> IsFilePresent(string fileName)
        {
            var storageFolder = await ApplicationData.Current.LocalFolder.GetFolderAsync("InkingFolder");
            var trying = await storageFolder.TryGetItemAsync(fileName + ".txt");
            return trying != null;
        }

        public ContentDialog myDialog;
        public TextBox textBox;
        public TextBlock textBlock;

        private async void SaveAsInkStrokesButton_Click(object sender, RoutedEventArgs e)
        {
            textBox = new TextBox();
            textBox.PlaceholderText = "Give your annotation a name here";
            textBox.TextChanged += TextBox_TextChanged;
            textBlock = new TextBlock();
            textBlock.Visibility = Visibility.Collapsed;
            textBlock.Text = "Name already exists - please change";
            StackPanel stack = new StackPanel();
            stack.Children.Add(textBox);
            stack.Children.Add(textBlock);

            myDialog = new ContentDialog();
            myDialog.Title = "Saved";
            myDialog.PrimaryButtonText = "Ok";
            myDialog.DefaultButton = ContentDialogButton.Primary;
            myDialog.PrimaryButtonClick += MyDialog_PrimaryButtonClick; ; ;
            myDialog.Content = stack;

            await myDialog.ShowAsync();

            {
                
                var edits = MyIE.SaveEdits();
                StreamReader reader = new StreamReader(edits);
                string text = reader.ReadToEnd();

                var o = new InkingZoneClassDetail()
                {
                    InkingZoneDate = DateTime.Now,
                    InkingZoneEdits = text,
                    InkingZoneTitle = textBox.Text,
                    InkingZoneId = new Guid().ToString(),
                    InkingZoneImageName = inkingZoneImageName,
                };

                var serializedContent = JsonConvert.SerializeObject(o);
                StorageFolder appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("InkingFolder", CreationCollisionOption.OpenIfExists);
                File.WriteAllText(appFolder.Path + "\\" + textBox.Text + ".txt", serializedContent);

            }

            //var myDialog = await UserDialogs.Instance.PromptAsync(new PromptConfig
            //{
            //    InputType = InputType.Default,
            //    CancelText = "Cancel",
            //    IsCancellable = true,
            //    Placeholder = "Give your ink strokes a name",
            //    OkText = "Save",
            //    Title = "Save",
            //});

            //if (myDialog.Ok && !string.IsNullOrWhiteSpace(myDialog.Text))
            //{
            //    var edits = MyIE.SaveEdits();
            //    StreamReader reader = new StreamReader(edits);
            //    string text = reader.ReadToEnd();

            //    var o = new InkingZoneClassDetail()
            //    {
            //        InkingZoneDate = DateTime.Now,
            //        InkingZoneEdits = text,
            //        InkingZoneTitle = myDialog.Text,
            //        InkingZoneId = new Guid().ToString(),
            //        InkingZoneImageName = inkingZoneImageName,
            //    };

            //    var serializedContent = JsonConvert.SerializeObject(o);
            //    StorageFolder appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("InkingFolder", CreationCollisionOption.OpenIfExists);
            //    File.WriteAllText(appFolder.Path + "\\" + myDialog.Text + ".txt", serializedContent);
            //}
        }

        private async void MyDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            myDialog.Hide();
            contentDialog3 = new ContentDialog();
            contentDialog3.Title = "Saved";
            contentDialog3.PrimaryButtonText = "Ok";
            contentDialog3.DefaultButton = ContentDialogButton.Primary;
            contentDialog3.PrimaryButtonClick += ContentDialog3_PrimaryButtonClick; ;

            contentDialog3.Content = new TextBlock()
            {
                Text = "Go back a screen to view your saved ink strokes in the 'My Saved Annotations' gallery.",
                TextWrapping = TextWrapping.Wrap,
            };

            await contentDialog3.ShowAsync();
        }

        private void ContentDialog3_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            contentDialog3.Hide();
        }

        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //File name duplicate check
            if (await IsFilePresent(textBox.Text) == true)
            {
                myDialog.IsPrimaryButtonEnabled = false;
                textBlock.Visibility = Visibility.Visible;
            }
            else
            {
                myDialog.IsPrimaryButtonEnabled = true;
                textBlock.Visibility = Visibility.Collapsed;
            }
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            MyIE.Undo();
        }

        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            MyIE.Redo();
        }
    }
}
