using AdaptiveCards;
using Microsoft.AppCenter.Analytics;
using Microsoft.Toolkit.Uwp.Helpers;
using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.UserActivities;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Shell;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    public sealed partial class DetailPage : Page
    {
        private UserActivitySession _currentSession;
        public Uri MyClickedImage1;
        public Uri MyClickedImage2;

        public DetailPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            SubsectionModel MyClickedItem = (SubsectionModel)e.Parameter;

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
            var helper = new LocalObjectStorageHelper();
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
            UserActivity activity = await channel.GetOrCreateUserActivityAsync("nc" + o.PageId);

            // Set deep-link and properties.
            activity.ActivationUri = new Uri("nervecentre://" + o.PageId);
            activity.VisualElements.DisplayText = o.Title;

            // Create and set Adaptive Card.
            //StorageFile cardFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Bones.json"));
            //string cardText = await FileIO.ReadTextAsync(cardFile);
            //activity.VisualElements.Content = AdaptiveCardBuilder.CreateAdaptiveCardFromJson(cardText);
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
            parameters.ImageUri1 = ((Uri)MyImage.Source);
            Frame.Navigate(typeof(DetailImagePage), parameters, new DrillInNavigationTransitionInfo());
        }

        private void MyImage2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var parameters = new SubsectionModel();
            parameters.ImageUri2 = ((Uri)MyImage2.Source);
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

                RandomAccessStreamReference imageStreamRef = RandomAccessStreamReference.CreateFromUri(MyClickedImage1);
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

                RandomAccessStreamReference imageStreamRef = RandomAccessStreamReference.CreateFromUri(MyClickedImage2);
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
    }
}
