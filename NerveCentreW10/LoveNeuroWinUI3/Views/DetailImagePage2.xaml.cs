using LoveNeuroWinUI3.Helpers;
using Microsoft.AppCenter.Analytics;
using LoveNeuroWinUI3.Models;
using System;
using Microsoft.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LoveNeuroWinUI3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailImagePage2 : Page
    {
        public DetailImagePage2()
        {
            InitializeComponent();
            Analytics.TrackEvent(this.GetType().Name);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            CloudClass cloudClass = new CloudClass();

            var parameters = (SubsectionModel)e.Parameter;
            DetailImage.Source = new Uri(parameters.ImageUri2);
        }

        private void DetailImage_ImageExFailed(object sender, Microsoft.Toolkit.Uwp.UI.Controls.ImageExFailedEventArgs e)
        {
            DetailImage.Source = "ms-appx:///Assets/Others/ErrorPlaceholder.png";
        }
    }
}
