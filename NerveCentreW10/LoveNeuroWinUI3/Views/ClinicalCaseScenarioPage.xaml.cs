

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

namespace LoveNeuroWinUI3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClinicalCaseScenarioPage : Page
    {
        //public ViewModels.ClinicalCasesScenarioPageViewModel ViewModel;

        public ClinicalCaseScenarioPage()
        {
            this.InitializeComponent();
            //ViewModel = new ViewModels.ClinicalCasesScenarioPageViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var parameter = (string)e.Parameter;
            if (parameter == "case1")
            {
                viewModel.LoadedCase1();
            }
            else if(parameter == "case2")
            {
                viewModel.LoadedCase2();
            }
        }

        private void GalleryFlipView_Loaded(object sender, RoutedEventArgs e)
        {
            Grid grid = (Grid)VisualTreeHelper.GetChild(flipView, 0);
            for (int i = grid.Children.Count - 1; i >= 0; i--)
                if (grid.Children[i] is Button)
                    grid.Children.RemoveAt(i);
        }
    }
}
