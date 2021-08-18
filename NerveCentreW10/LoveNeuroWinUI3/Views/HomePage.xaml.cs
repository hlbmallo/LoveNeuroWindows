using CommunityToolkit.Mvvm.DependencyInjection;

using LoveNeuroWinUI3.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace LoveNeuroWinUI3.Views
{
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; }

        public HomePage()
        {
            ViewModel = Ioc.Default.GetService<HomeViewModel>();
            InitializeComponent();
        }
    }
}
