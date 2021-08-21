﻿using Acr.UserDialogs;
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
                Text = "Your diagram has been saved at: This PC >> Pictures >> Saved Pictures",
                TextWrapping = TextWrapping.Wrap,
            };

            await contentDialog2.ShowAsync();
        }

        private void ContentDialog2_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            contentDialog2.Hide();
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
                StreamReader reader = new StreamReader(edits);
                string text = reader.ReadToEnd();

                var o = new InkingZoneClassDetail()
                {
                    InkingZoneDate = DateTime.Now,
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
