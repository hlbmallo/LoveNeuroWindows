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
            else if (parameter == "case3")
            {
                viewModel.LoadedCase3();
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
