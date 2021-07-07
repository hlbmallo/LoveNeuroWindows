using Microsoft.AppCenter.Analytics;
using Microsoft.Toolkit.Uwp.Helpers;
using NerveCentreW10.Helpers;
using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.UserActivities;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
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
        public VideoTutorialsDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var cloudClass = new CloudClass();
            var MyClickedItem = (VideoTutorialsClass)e.Parameter;
            //MyWebView.Source = MyClickedItem.VideoTutorialsUrl;
            MyMPE.Source = MediaSource.CreateFromUri(new Uri(cloudClass.GetBlobSasUri(MyClickedItem.VideoTutorialsFileName)));
            Analytics.TrackEvent(this.GetType().Name + " " + MyClickedItem.VideoTutorialsName);
        }

        //private void MyWebView_ContentLoading(WebView sender, WebViewContentLoadingEventArgs args)
        //{
        //    MyProgressRing.IsActive = true;
        //    MyProgressRing.IsEnabled = true;
        //    MyProgressRing.Visibility = Visibility.Visible;
        //}

        //private void MyWebView_LoadCompleted(object sender, NavigationEventArgs e)
        //{
        //    MyProgressRing.IsActive = false;
        //    MyProgressRing.IsEnabled = false;
        //    MyProgressRing.Visibility = Visibility.Collapsed;
        //}

        //private void Page_Unloaded(object sender, RoutedEventArgs e)
        //{
        //    MyWebView.Source = new Uri("about:blank");
        //}
    }
}
