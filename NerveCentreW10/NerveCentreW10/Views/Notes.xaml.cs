using Microsoft.AppCenter.Analytics;
using NerveCentreW10.Helpers;
using NerveCentreW10.Models;
using NerveCentreW10.ViewModels;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
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
            //var cloudClass = new CloudClass();
            //this.Background = new ImageBrush
            //{
            //    ImageSource = new BitmapImage(new Uri(cloudClass.GetBlobSasUri("LN3.png")))
            //};

        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyClickedItem = ((NotesClass)e.ClickedItem as NotesClass).NotesLink;
            Frame.Navigate(MyClickedItem, null, new DrillInNavigationTransitionInfo());
        }
    }
}
