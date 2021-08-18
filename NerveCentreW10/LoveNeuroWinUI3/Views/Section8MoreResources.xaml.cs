using Microsoft.AppCenter.Analytics;
using LoveNeuroWinUI3.Models;
using LoveNeuroWinUI3.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.UserActivities;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LoveNeuroWinUI3.Views
{
    public sealed partial class Section8MoreResources : Page
    {
        public ObservableCollection<NotesClass> NotesList { get; } = new ObservableCollection<NotesClass>();
        public MoreResourcesViewModel ViewModel { get; set; }
        UserActivitySession _currentSession;

        public Section8MoreResources()
        {
            this.InitializeComponent();
            Analytics.TrackEvent(this.GetType().Name);
            ViewModel = new MoreResourcesViewModel();
            NotesData();
            //GenerateUserActivityOverArching();
        }

        //async void GenerateUserActivityOverArching()
        //{
        //    await GenerateActivityAsync();
        //}

        //private async Task GenerateActivityAsync()
        //{

        //    // Get channel and create activity.
        //    UserActivityChannel channel = UserActivityChannel.GetDefault();
        //    UserActivity activity = await channel.GetOrCreateUserActivityAsync("ln" + "section80");

        //    activity.ActivationUri = new Uri("loveneuro://" + "section80");
        //    activity.VisualElements.DisplayText = "8.0. More Resources";
        //    activity.VisualElements.Content = Helpers.AdaptiveCardCreation.CreateAdaptiveCardWithoutImage("8.0. More Resources");
        //    Windows.UI.Color color = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToColor("#ff7201");
        //    activity.VisualElements.BackgroundColor = color;

        //    await activity.SaveAsync();

        //    _currentSession?.Dispose();

        //    _currentSession = activity.CreateSession();

        //}

        void NotesData()
        {
            NotesList.Add(new NotesClass
            {
                NotesTitle = "The Neuroscience Dictionary",
                NotesImage = new BitmapImage(new Uri("ms-appx:///Assets/Icons/IconNeuroDictionary.png")),
                NotesLink = typeof(NeuroDictionary),
            });
            NotesList.Add(new NotesClass
            {
                NotesTitle = "Recommended Reading",
                NotesImage = new BitmapImage(new Uri("ms-appx:///Assets/Icons/IconRecommendedReading.png")),
                NotesLink = typeof(RecommendedReading),
            });

            GridView1.ItemsSource = NotesList;
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyClickedItem = ((NotesClass)e.ClickedItem as NotesClass).NotesLink;
            Frame.Navigate(MyClickedItem, null, new DrillInNavigationTransitionInfo());
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
