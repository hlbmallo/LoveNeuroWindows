using HeartCentreW104.Helpers;
using Microsoft.AppCenter.Analytics;
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
    public sealed partial class DetailImagePage : Page
    {
        public DetailImagePage()
        {
            InitializeComponent();
            Analytics.TrackEvent(this.GetType().Name);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            CloudClass cloudClass = new CloudClass();

            var parameters = (SubsectionModel)e.Parameter;
            DetailImage.Source = new Uri(parameters.ImageUri1);
        }

        private void DetailImage_ImageExFailed(object sender, Microsoft.Toolkit.Uwp.UI.Controls.ImageExFailedEventArgs e)
        {
            DetailImage.Source = "ms-appx:///Assets/Others/ErrorPlaceholder.png";
        }
    }
}
