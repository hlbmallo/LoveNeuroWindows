using Microsoft.AppCenter.Analytics;
using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using NerveCentreW10.Models;
using Microsoft.Toolkit.Uwp.UI;
using Windows.Storage;
using NerveCentreW10.ViewModels;
using System.Numerics;
using System.Collections.ObjectModel;
using Windows.Storage.FileProperties;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Section6InkingZoneMenu : Page
    {
        public ObservableCollection<InkingZoneClassDetail> InkingZoneList { get; } = new ObservableCollection<InkingZoneClassDetail>();

        InkingZoneViewModel inkingZoneViewModel;
        IReadOnlyList<StorageFile> itemsList;
        FrameworkElement preElement = null;
        public ContentDialog dialog;

        public Section6InkingZoneMenu()
        {
            InitializeComponent();
            inkingZoneViewModel = new InkingZoneViewModel();
            InkingZoneData();
            Analytics.TrackEvent(this.GetType().Name);
        }

        void InkingZoneData()
        {
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Basic Neuron",
                InkingZoneImageName = "Neuron.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Resting Membrane Potential",
                InkingZoneImageName = "rmpforink.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Synapse",
                InkingZoneImageName = "Synapse.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Reflex Arc",
                InkingZoneImageName = "reflexarc.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Lateral Aspect of the Brain",
                InkingZoneImageName = "LateralBrain5.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Medial Aspect of the Brain",
                InkingZoneImageName = "MedialBrain.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Brachial Plexus",
                InkingZoneImageName = "BrachialPlexus.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Circle of Willis",
                InkingZoneImageName = "CircleOfWillis.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Spinal Cord Divisions",
                InkingZoneImageName = "SpinalCordDivisions.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Cerebral Cortex",
                InkingZoneImageName = "CerebralCortex.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Ventricles of the Brain",
                InkingZoneImageName = "Ventricles.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Coronal Section with Basal Ganglia and Corpus Callosum",
                InkingZoneImageName = "CoronalSection.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Brainstem (Anterior)",
                InkingZoneImageName = "brainstem.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Spinal Cord Cross-Section",
                InkingZoneImageName = "spinalcrosssection.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Spinal Tracts Matching Exercise",
                InkingZoneImageName = "MatchingExercise.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Ventricles Matching Exercise",
                InkingZoneImageName = "definitionmatch.png",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "HPA Axis",
                InkingZoneImageName = "cortisolink.png",
            });
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyClickedItem = (InkingZoneClassDetail)e.ClickedItem;

            Frame.Navigate(typeof(InkingZoneDetail2), MyClickedItem);
        }

        private async void GridViewInkingStrokes_ItemClick(object sender, ItemClickEventArgs e)
        {

            //var MyClickedItem = e.ClickedItem as InkingZoneClassDetail;
            //string json = JsonConvert.SerializeObject(MyClickedItem);
            //string json2 = JsonConvert.SerializeObject(inkingZoneViewModel);

            //Dictionary<string, string> newDictionary = new Dictionary<string, string>();
            //newDictionary.Add("json", json);
            //newDictionary.Add("json2", json2);
            //Frame.Navigate(typeof(InkingZoneDetail), newDictionary);

            var MyClickedItem = (StorageFile)e.ClickedItem;
            var readFromStorageFile = await FileIO.ReadTextAsync(MyClickedItem);
            var deserializedContent = JsonConvert.DeserializeObject<InkingZoneClassDetail>(readFromStorageFile);

            Frame.Navigate(typeof(InkingZoneDetail2EditOnly), deserializedContent);
        }

        public StorageItemThumbnail thumbnail;

        private async void GridViewInkingStrokes_Loaded(object sender, RoutedEventArgs e)
        {
            StorageFolder appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("InkingFolder", CreationCollisionOption.OpenIfExists);
            itemsList = await appFolder.GetFilesAsync();
            GridViewInkingStrokes.ItemsSource = itemsList;
    }

        private void MyGrid_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            // Prepare MenuFlyout
            MenuFlyout myFlyout = new MenuFlyout();
            MenuFlyoutItem deleteItem = new MenuFlyoutItem { Text = "Delete" };

            myFlyout.Items.Add(deleteItem);

            myFlyout.ShowAt(sender as UIElement, e.GetPosition(sender as UIElement));

            // Attach deleteItem click event handler
            deleteItem.Click += async (sender2, args) =>
            {
                GridView gridView = (GridView)sender;
                myFlyout.ShowAt(gridView, e.GetPosition(gridView));
                var a = ((FrameworkElement)e.OriginalSource).DataContext as StorageFile;
                await a.DeleteAsync();
                GridViewInkingStrokes_Loaded(sender, e);
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InkingZoneDetail2));
        }

        private void MyInkingGrid_PointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;

            var control = preElement.FindDescendant("MyGrid2");
            AnimationBuilder.Create().Scale(to: new Vector2(1.00f), duration: TimeSpan.FromMilliseconds(200)).StartAsync(control);

            var control2 = preElement.FindDescendant("MyDropShadow");
            AnimationBuilder.Create().Opacity(to: (0.0f), duration: TimeSpan.FromMilliseconds(500)).StartAsync(control2);

            var control3 = preElement.FindDescendant("DeleteButton");
            AnimationBuilder.Create().Opacity(from: (1f), to: (0f), duration: TimeSpan.FromMilliseconds(500)).StartAsync(control3);

        }

        private void MyInkingGrid_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;

            var control = preElement.FindDescendant("MyGrid2");
            AnimationBuilder.Create().Scale(to: new Vector2(1.00f), duration: TimeSpan.FromMilliseconds(200)).StartAsync(control);

            var control2 = preElement.FindDescendant("MyDropShadow");
            AnimationBuilder.Create().Opacity(to: (0.0f), duration: TimeSpan.FromMilliseconds(500)).StartAsync(control2);

            var control3 = preElement.FindDescendant("DeleteButton");
            AnimationBuilder.Create().Opacity(from: (1f), to: (0f), duration: TimeSpan.FromMilliseconds(500)).StartAsync(control3);

        }

        private void MyInkingGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;

            var control = preElement.FindDescendant("MyGrid2");
            AnimationBuilder.Create().Scale(to: new Vector2(1.04f), duration: TimeSpan.FromMilliseconds(200)).StartAsync(control);

            var control2 = preElement.FindDescendant("MyDropShadow");
            AnimationBuilder.Create().Opacity(to: (0.4f), duration: TimeSpan.FromMilliseconds(500)).StartAsync(control2);

            var control3 = preElement.FindDescendant("DeleteButton");
            AnimationBuilder.Create().Opacity(from: (0f), to: (1f), duration: TimeSpan.FromMilliseconds(500)).StartAsync(control3);
        }

        private void MyInkingGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;

            var control = preElement.FindDescendant("MyGrid2");
            AnimationBuilder.Create().Scale(to: new Vector2(1.00f), duration: TimeSpan.FromMilliseconds(200)).StartAsync(control);

            var control2 = preElement.FindDescendant("MyDropShadow");
            AnimationBuilder.Create().Opacity(to: (0.0f), duration: TimeSpan.FromMilliseconds(500)).StartAsync(control2);

            var control3 = preElement.FindDescendant("DeleteButton");
            AnimationBuilder.Create().Opacity(from: (1f), to: (0f), duration: TimeSpan.FromMilliseconds(500)).StartAsync(control3);
        }

        private void MyInkingGrid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

        }

        private void MyInkingGrid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            preElement = sender as FrameworkElement;

            var control = preElement.FindDescendant("MyGrid2");
            AnimationBuilder.Create().Scale(to: new Vector2(1.00f), duration: TimeSpan.FromMilliseconds(200)).StartAsync(control);

            var control2 = preElement.FindDescendant("MyDropShadow");
            AnimationBuilder.Create().Opacity(to: (0.0f), duration: TimeSpan.FromMilliseconds(500)).StartAsync(control2);

            var control3 = preElement.FindDescendant("DeleteButton");
            AnimationBuilder.Create().Opacity(from: (1f), to: (0f), duration: TimeSpan.FromMilliseconds(500)).StartAsync(control3);
        }

        public StorageFile param;

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            dialog = new ContentDialog();
            dialog.Title = "Delete your saved annotation?";
            dialog.PrimaryButtonText = "Delete";
            dialog.CloseButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Primary;
            dialog.PrimaryButtonClick += Dialog_PrimaryButtonClick;
            param = e.OriginalSource as StorageFile;

            await dialog.ShowAsync();
        }

        private async void Dialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            await param.DeleteAsync();
            GridViewInkingStrokes_Loaded(sender, e);
        }
    }
}


