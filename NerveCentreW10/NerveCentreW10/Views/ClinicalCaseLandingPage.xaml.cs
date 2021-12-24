using System;
using System.Net.NetworkInformation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClinicalCaseLandingPage : Page
    {
        public ClinicalCaseLandingPage()
        {
            this.InitializeComponent();
            HtmlLabel.Source = "In this section you will find fictional patients with neurological symptoms. The goal is to answer the 8 questions correctly about the neuroscience underlying their conditions. The questions are not timed.<br/>< br/>When you select an answer, tap 'Submit' and this will reveal if you are correct. Then, tap 'Next' to proceed. Tap a clinical case below to get started.";
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isNetworkConnected = NetworkInterface.GetIsNetworkAvailable();
            if (isNetworkConnected == true)
            {
                Frame.Navigate(typeof(ClinicalCaseScenarioPage), "case1", new DrillInNavigationTransitionInfo());
            }
            else
            {
                var dialog = new ContentDialog();
                dialog.Title = "Error: No Internet Connection";
                dialog.Content = "Looks like you're not connected to the Internet at the moment. Once you've reconnected, try clicking this Clinical Case again.";
                dialog.CloseButtonText = "Close";
                dialog.CloseButtonClick += Dialog_CloseButtonClick;
                await dialog.ShowAsync();
            }
        }

        private void Dialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Frame.GoBack();
        }

        private async void Case2_Click(object sender, RoutedEventArgs e)
        {
            bool isNetworkConnected = NetworkInterface.GetIsNetworkAvailable();
            if (isNetworkConnected == true)
            {
                Frame.Navigate(typeof(ClinicalCaseScenarioPage), "case2", new DrillInNavigationTransitionInfo());
            }
            else
            {
                var dialog = new ContentDialog();
                dialog.Title = "Error: No Internet Connection";
                dialog.Content = "Looks like you're not connected to the Internet at the moment. Once you've reconnected, try clicking this Clinical Case again.";
                dialog.CloseButtonText = "Close";
                dialog.CloseButtonClick += Dialog_CloseButtonClick;
                await dialog.ShowAsync();
            }
        }
        private async void Case3_Click(object sender, RoutedEventArgs e)
        {
            bool isNetworkConnected = NetworkInterface.GetIsNetworkAvailable();
            if (isNetworkConnected == true)
            {
                Frame.Navigate(typeof(ClinicalCaseScenarioPage), "case3", new DrillInNavigationTransitionInfo());
            }
            else
            {
                var dialog = new ContentDialog();
                dialog.Title = "Error: No Internet Connection";
                dialog.Content = "Looks like you're not connected to the Internet at the moment. Once you've reconnected, try clicking this Clinical Case again.";
                dialog.CloseButtonText = "Close";
                dialog.CloseButtonClick += Dialog_CloseButtonClick;
                await dialog.ShowAsync();
            }
        }
    }
}
