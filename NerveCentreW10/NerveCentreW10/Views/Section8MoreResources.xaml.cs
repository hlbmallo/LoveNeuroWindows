using Microsoft.AppCenter.Analytics;
using NerveCentreW10.Models;
using NerveCentreW10.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
    public sealed partial class Section8MoreResources : Page
    {
        public MoreResourcesViewModel ViewModel { get; set; }

        public Section8MoreResources()
        {
            this.InitializeComponent();
            Analytics.TrackEvent(this.GetType().Name);
            ViewModel = new MoreResourcesViewModel();
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private async void GridView2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var MyClickedItem = ((MoreResourcesClass)e.ClickedItem as MoreResourcesClass).MoreResourcesLinkOut1;
                await Launcher.LaunchUriAsync(MyClickedItem);
            }
            catch
            {
                var MyClickedItem = ((MoreResourcesClass)e.ClickedItem as MoreResourcesClass).MoreResourcesLinkOut2;
                await Launcher.LaunchUriAsync(MyClickedItem);
            }

        }
    }
}
