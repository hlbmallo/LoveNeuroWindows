using Microsoft.AppCenter.Analytics;
using NerveCentreW10.Models;
using NerveCentreW10.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace NerveCentreW10.Views
{
    public sealed partial class Section2CentralMenu : Page
    {
        public Section2ViewModel ViewModel { get; set; }

        public Section2CentralMenu()
        {
            this.InitializeComponent();
            Analytics.TrackEvent(this.GetType().Name);
            ViewModel = new Section2ViewModel();
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyClickedItem = (SubsectionModel)e.ClickedItem;
            Frame.Navigate(typeof(DetailPage), MyClickedItem, new DrillInNavigationTransitionInfo());
        }
    }
}
