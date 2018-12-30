using Microsoft.AppCenter.Analytics;
using NerveCentreW10.Models;
using NerveCentreW10.ViewModels;
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
    public sealed partial class Section6InkingZoneMenu : Page
    {
        public InkingZoneViewModel ViewModel { get; set; }

        public Section6InkingZoneMenu()
        {
            InitializeComponent();
            Analytics.TrackEvent(this.GetType().Name);
            ViewModel = new InkingZoneViewModel();
        }
        
        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyClickedItem = (InkingZoneClass)e.ClickedItem;
            Frame.Navigate(typeof(InkingZoneDetail), MyClickedItem);
        }
    }
}
