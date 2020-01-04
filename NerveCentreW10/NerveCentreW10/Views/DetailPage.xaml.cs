using Microsoft.AppCenter.Analytics;
using Microsoft.Toolkit.Uwp.Helpers;
using NerveCentreW10.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.UserActivities;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    public sealed partial class DetailPage : Page
    {
        private UserActivitySession _currentSession;
        public SubsectionModel overall;
        public string MyClickedImage1;
        public string MyClickedImage2;

        public DetailPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            SubsectionModel MyClickedItem = (SubsectionModel)e.Parameter;
            overall = MyClickedItem;
            Title.Text = MyClickedItem.Title;
            Subtitle1.Text = MyClickedItem.Subtitle1;
            Description1.Source = MyClickedItem.Description1;
            Subtitle2.Text = MyClickedItem.Subtitle2;
            Description2.Source = MyClickedItem.Description2;
            Subtitle3.Text = MyClickedItem.Subtitle3;
            Description3.Source = MyClickedItem.Description3;

            MyClickedImage1 = MyClickedItem.ImageUri1;
            MyClickedImage2 = MyClickedItem.ImageUri2;

            MyImage.Source = MyClickedImage1;
            if (MyClickedImage2 == null)
            {
                ShareImage2Button.Visibility = Visibility.Collapsed;
            }
            else
            {
                ShareImage2Button.Visibility = Visibility.Visible;
            }

            MyImage2.Source = MyClickedImage2;
            ClinicalExpander.Header = MyClickedItem.Popup1Title;
            ClinicalExpanderContent.Source = MyClickedItem.Popup1Content;
            ResearchExpander.Header = MyClickedItem.Popup2Title;
            ResearchExpanderContent.Source = MyClickedItem.Popup2Content;
            RevisionExpander.Header = MyClickedItem.Popup3Title;
            RevisionExpanderContent.Source = MyClickedItem.Popup3Content;

            Analytics.TrackEvent(this.GetType().Name + " " + MyClickedItem.Title);

            // Save complex/large objects 
            var helper = new RoamingObjectStorageHelper();
            string keyLargeObject = MyClickedItem.PageId;

            var o = new SubsectionModel
            {
                PageId = MyClickedItem.PageId,
                Title = MyClickedItem.Title,
                Subtitle1 = MyClickedItem.Subtitle1,
                Description1 = MyClickedItem.Description1,
                Subtitle2 = MyClickedItem.Subtitle2,
                Description2 = MyClickedItem.Description2,
                Subtitle3 = MyClickedItem.Subtitle3,
                Description3 = MyClickedItem.Description3,
                ImageUri1 = MyClickedItem.ImageUri1,
                ImageUri2 = MyClickedItem.ImageUri2,
                Popup1Title = MyClickedItem.Popup1Title,
                Popup1Content = MyClickedItem.Popup1Content,
                Popup2Title = MyClickedItem.Popup2Title,
                Popup2Content = MyClickedItem.Popup2Content,
                Popup3Title = MyClickedItem.Popup3Title,
                Popup3Content = MyClickedItem.Popup3Content,
            };

            await helper.SaveFileAsync(keyLargeObject, o);

            //this.RegisterElementForConnectedAnimation("key", MyImage);

            // Get channel and create activity.
            UserActivityChannel channel = UserActivityChannel.GetDefault();
            UserActivity activity = await channel.GetOrCreateUserActivityAsync("ln" + o.PageId);

            // Set deep-link and properties.
            activity.ActivationUri = new Uri("loveneuro://" + o.PageId);
            activity.VisualElements.DisplayText = o.Title;

            // Create and set Adaptive Card.
            activity.VisualElements.Content = Helpers.AdaptiveCardCreation.CreateAdaptiveCardWithImage(MyClickedItem.Title, MyClickedItem.Description1, MyClickedItem.ImageUri1.ToString());
            Windows.UI.Color color = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToColor("#ff7201");
            activity.VisualElements.BackgroundColor = color;

            // Save to activity feed.
            await activity.SaveAsync();

            // Create a session, which indicates that the user is engaged
            // in the activity.
            _currentSession?.Dispose();

            _currentSession = activity.CreateSession();

        }

        private void MyImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var parameters = new SubsectionModel();
            parameters.ImageUri1 = MyClickedImage1;
            Frame.Navigate(typeof(DetailImagePage), parameters, new DrillInNavigationTransitionInfo());
        }

        private void MyImage2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var parameters = new SubsectionModel();
            parameters.ImageUri2 = MyClickedImage2;
            Frame.Navigate(typeof(DetailImagePage2), parameters, new DrillInNavigationTransitionInfo());
        }

        private void MyImage_ImageExFailed(object sender, Microsoft.Toolkit.Uwp.UI.Controls.ImageExFailedEventArgs e)
        {
            MyImage.Source = "ms-appx:///Assets/Others/ErrorPlaceholder.png";
            ShareImage1Button.IsEnabled = false;
        }

        private void MyImage2_ImageExFailed(object sender, Microsoft.Toolkit.Uwp.UI.Controls.ImageExFailedEventArgs e)
        {
            MyImage2.Source = "ms-appx:///Assets/Others/ErrorPlaceholder.png";
            ShareImage2Button.IsEnabled = false;
        }

        private void ShareImage1Button_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
            DataTransferManager.GetForCurrentView().DataRequested += DetailPage_DataRequested;
        }

        async void DetailPage_DataRequested(DataTransferManager sender, Windows.ApplicationModel.DataTransfer.DataRequestedEventArgs args)
        {
            DataRequestDeferral deferral = args.Request.GetDeferral();

            try
            {
                var file = await StorageFile.CreateStreamedFileFromUriAsync(Path.GetFileName(MyClickedImage1.ToString()), new Uri(MyClickedImage1.ToString()), null);

                List<IStorageItem> imageItems = new List<IStorageItem>();
                imageItems.Add(file);
                args.Request.Data.SetStorageItems(imageItems);

                RandomAccessStreamReference imageStreamRef = RandomAccessStreamReference.CreateFromUri(new Uri(MyClickedImage1));
                args.Request.Data.Properties.Thumbnail = imageStreamRef;
                args.Request.Data.SetBitmap(imageStreamRef);

                args.Request.Data.Properties.Title = "Diagram 1 from LoveNeuro";
            }

            finally
            {
                deferral.Complete();
            }
        }

        private void ShareImage2Button_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
            DataTransferManager.GetForCurrentView().DataRequested += DetailPage_DataRequested2;
        }

        async void DetailPage_DataRequested2(DataTransferManager sender, Windows.ApplicationModel.DataTransfer.DataRequestedEventArgs args)
        {
            DataRequestDeferral deferral = args.Request.GetDeferral();

            try
            {
                var file = await StorageFile.CreateStreamedFileFromUriAsync(Path.GetFileName(MyClickedImage2.ToString()), new Uri(MyClickedImage2.ToString()), null);

                List<IStorageItem> imageItems = new List<IStorageItem>();
                imageItems.Add(file);
                args.Request.Data.SetStorageItems(imageItems);

                RandomAccessStreamReference imageStreamRef = RandomAccessStreamReference.CreateFromUri(new Uri(MyClickedImage2));
                args.Request.Data.Properties.Thumbnail = imageStreamRef;
                args.Request.Data.SetBitmap(imageStreamRef);

                args.Request.Data.Properties.Title = "Diagram 2 from LoveNeuro";
            }

            finally
            {
                deferral.Complete();
            }
        }

        private void ShareTextButton_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
            DataTransferManager.GetForCurrentView().DataRequested += DetailPage_DataRequested3;
        }

        void DetailPage_DataRequested3(DataTransferManager sender, DataRequestedEventArgs args)
        {
            DataRequestDeferral deferral = args.Request.GetDeferral();

            try
            {
                var htmlExample = Description1.Source + "<br/><br/>" + Description2.Source + "<br/><br/>" + Description3.Source;
                var htmlFormat = HtmlFormatHelper.CreateHtmlFormat(htmlExample);
                args.Request.Data.SetHtmlFormat(htmlFormat);

                args.Request.Data.Properties.Title = "Notes from LoveNeuro";
            }

            finally
            {
                deferral.Complete();
            }
        }

        private async void FavouritesButton_Click(object sender, RoutedEventArgs e)
        {
            var appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("FavouritesFolder", CreationCollisionOption.OpenIfExists);

            if (FavouritesButton.IsChecked == true)
            {
                var o = new SubsectionModel
                {
                    PageId = overall.PageId,
                    Title = overall.Title,
                    Subtitle1 = overall.Subtitle1,
                    Description1 = overall.Description1,
                    Subtitle2 = overall.Subtitle2,
                    Description2 = overall.Description2,
                    Subtitle3 = overall.Subtitle3,
                    Description3 = overall.Description3,
                    ImageUri1 = overall.ImageUri1,
                    ImageUri2 = overall.ImageUri2,
                    Popup1Title = overall.Popup1Title,
                    Popup1Content = overall.Popup1Content,
                    Popup2Title = overall.Popup2Title,
                    Popup2Content = overall.Popup2Content,
                    Popup3Title = overall.Popup3Title,
                    Popup3Content = overall.Popup3Content,
                };

                string json = JsonConvert.SerializeObject(o);

                StorageFile storageFile = await appFolder.CreateFileAsync(overall.PageId, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(storageFile, json);

                FavouritesButton.Content = "Remove Favourite";
            }

            else
            {
                StorageFile storageFile = await appFolder.CreateFileAsync(overall.Title, CreationCollisionOption.OpenIfExists);
                await storageFile.DeleteAsync();
                FavouritesButton.Content = "Add Favourite";

            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StorageFolder appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("FavouritesFolder", CreationCollisionOption.OpenIfExists);

            if (await appFolder.FileExistsAsync(overall.Title))
            {
                StorageFile filed = await appFolder.GetFileAsync(overall.Title);
                if (filed != null)
                {
                    FavouritesButton.IsChecked = true;
                    FavouritesButton.Content = "Remove Favourite";
                }
                else
                {
                    FavouritesButton.IsChecked = false;
                    FavouritesButton.Content = "Add Favourite";
                }
            }
        }
    }
}
