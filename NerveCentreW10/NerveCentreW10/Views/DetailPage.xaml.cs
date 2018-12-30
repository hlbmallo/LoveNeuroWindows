using Microsoft.AppCenter.Analytics;
using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailPage : Page
    {
        public Uri MyClickedImage1;
        public Uri MyClickedImage2;

        public DetailPage()
        {
            this.InitializeComponent();

            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            if (connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
            {
                ShareImageButton.IsEnabled = true;
            }
            else
            {
                ShareImageButton.IsEnabled = false;
            }

            //if (MyImage2.Source == null)
            //{
            //    MyBorderForImage2.Visibility = Visibility.Collapsed;
            //}
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SubsectionModel MyClickedItem = (SubsectionModel)e.Parameter;

            Title.Text = MyClickedItem.Title;
            Subtitle1.Text = MyClickedItem.Subtitle1;
            Description1.Source = MyClickedItem.Description1;
            Subtitle2.Text = MyClickedItem.Subtitle2;
            Description2.Source = MyClickedItem.Description2;
            Subtitle3.Text = MyClickedItem.Subtitle3;
            Description3.Source = MyClickedItem.Description3;
            MyImage.Source = MyClickedItem.ImageUri1;
            MyImage2.Source = MyClickedItem.ImageUri2;

            Analytics.TrackEvent(this.GetType().Name + " " + MyClickedItem.Title);

        }

        private void ShareButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShareImageButton_Click(object sender, RoutedEventArgs e)
        {

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
        }

        private void MyImage2_ImageExFailed(object sender, Microsoft.Toolkit.Uwp.UI.Controls.ImageExFailedEventArgs e)
        {
            MyImage2.Source = "ms-appx:///Assets/Others/ErrorPlaceholder.png";
        }

    }
}
