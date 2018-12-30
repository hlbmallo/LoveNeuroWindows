﻿using Microsoft.AppCenter.Analytics;
using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        public VideoTutorialsDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var MyClickedItem = (VideoTutorialsClass)e.Parameter;
            MyWebView.Source = MyClickedItem.VideoTutorialsUrl;
            Analytics.TrackEvent(this.GetType().Name + " " + MyClickedItem.VideoTutorialsName);
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