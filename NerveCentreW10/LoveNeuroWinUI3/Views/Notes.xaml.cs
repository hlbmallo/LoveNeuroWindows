using Microsoft.AppCenter.Analytics;
using LoveNeuroWinUI3.Models;
using LoveNeuroWinUI3.ViewModels;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LoveNeuroWinUI3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Notes : Page
    {
        public NotesViewModel ViewModel { get; set; }

        public Notes()
        {
            this.InitializeComponent();
            Analytics.TrackEvent(this.GetType().Name);
            ViewModel = new NotesViewModel();
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyClickedItem = ((NotesClass)e.ClickedItem as NotesClass).NotesLink;
            Frame.Navigate(MyClickedItem, null, new DrillInNavigationTransitionInfo());
        }
    }
}
