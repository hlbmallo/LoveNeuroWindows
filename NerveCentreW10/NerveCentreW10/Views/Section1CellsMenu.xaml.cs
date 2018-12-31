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
    public sealed partial class Section1CellsMenu : Page
    {
        public Section1ViewModel ViewModel { get; set; }

        public Section1CellsMenu()
        {
            this.InitializeComponent();
            Analytics.TrackEvent(this.GetType().Name);
            ViewModel = new Section1ViewModel();
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyClickedItem = (SubsectionModel)e.ClickedItem;
            Frame.Navigate(typeof(DetailPage), MyClickedItem, new DrillInNavigationTransitionInfo());
        }
    }
}
