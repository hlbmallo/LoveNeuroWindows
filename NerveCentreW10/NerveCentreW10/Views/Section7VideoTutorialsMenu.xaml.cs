using Microsoft.AppCenter.Analytics;
using NerveCentreW10.Models;
using NerveCentreW10.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Section7VideoTutorialsMenu : Page
    {
        public VideoTutorialsViewModel ViewModel { get; set; }

        public Section7VideoTutorialsMenu()
        {
            this.InitializeComponent();
            Analytics.TrackEvent(this.GetType().Name);
            ViewModel = new VideoTutorialsViewModel();
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyClickedItem = (VideoTutorialsClass)e.ClickedItem;
            Frame.Navigate(typeof(VideoTutorialsDetail), MyClickedItem, new DrillInNavigationTransitionInfo());
        }
    }
}
