// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

using LoveNeuroWinUI3.Helpers;
using Microsoft.AppCenter.Analytics;
using Microsoft.UI.Xaml.Controls;

namespace LoveNeuroWinUI3.Views
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

        private void DetailImage_ImageExFailed(object sender, CommunityToolkit.WinUI.UI.Controls.ImageExFailedEventArgs e)
        {
            DetailImage.Source = "ms-appx:///Assets/Others/ErrorPlaceholder.png";
        }
    }
}
