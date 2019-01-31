using Microsoft.AppCenter.Analytics;
using Microsoft.Toolkit.Uwp.Helpers;
using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.UserActivities;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class VideoTutorialsDetail : Page
    {
        private UserActivitySession _currentSession;

        public VideoTutorialsDetail()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var MyClickedItem = (VideoTutorialsClass)e.Parameter;
            MyWebView.Source = MyClickedItem.VideoTutorialsUrl;
            Analytics.TrackEvent(this.GetType().Name + " " + MyClickedItem.VideoTutorialsName);

            // Save complex/large objects 
            var helper = new LocalObjectStorageHelper();
            string keyLargeObject = MyClickedItem.VideoTutorialsPageId;

            var o = new VideoTutorialsClass
            {
                VideoTutorialsPageId = MyClickedItem.VideoTutorialsPageId,
                VideoTutorialsName = MyClickedItem.VideoTutorialsName,
                VideoTutorialsDescription = MyClickedItem.VideoTutorialsDescription,
                VideoTutorialsThumbnail = MyClickedItem.VideoTutorialsThumbnail,
                VideoTutorialsUrl = MyClickedItem.VideoTutorialsUrl,
            };

            await helper.SaveFileAsync(keyLargeObject, o);

            //this.RegisterElementForConnectedAnimation("key", MyImage);

            // Get channel and create activity.
            UserActivityChannel channel = UserActivityChannel.GetDefault();
            UserActivity activity = await channel.GetOrCreateUserActivityAsync("ln" + o.VideoTutorialsPageId);

            // Set deep-link and properties.
            activity.ActivationUri = new Uri("loveneuro://" + o.VideoTutorialsPageId);
            activity.VisualElements.DisplayText = o.VideoTutorialsName;

            // Create and set Adaptive Card.
            //StorageFile cardFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Bones.json"));
            //string cardText = await FileIO.ReadTextAsync(cardFile);
            //activity.VisualElements.Content = AdaptiveCardBuilder.CreateAdaptiveCardFromJson(cardText);
            activity.VisualElements.Content = Helpers.AdaptiveCardCreation.CreateAdaptiveCardWithImage(MyClickedItem.VideoTutorialsName, MyClickedItem.VideoTutorialsDescription, MyClickedItem.VideoTutorialsThumbnail.ToString());
            Windows.UI.Color color = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToColor("#ff7201");
            activity.VisualElements.BackgroundColor = color;

            // Save to activity feed.
            await activity.SaveAsync();

            // Create a session, which indicates that the user is engaged
            // in the activity.
            _currentSession?.Dispose();

            _currentSession = activity.CreateSession();
        }

        private void MyWebView_ContentLoading(WebView sender, WebViewContentLoadingEventArgs args)
        {
            MyProgressRing.IsActive = true;
        }

        private void MyWebView_LoadCompleted(object sender, NavigationEventArgs e)
        {
            MyProgressRing.IsActive = false;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            MyWebView.Source = new Uri("about:blank");
        }
    }
}
