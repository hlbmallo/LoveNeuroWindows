using Microsoft.AppCenter.Analytics;
using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using LoveNeuroWinUI3.Models;
using Microsoft.Toolkit.Uwp.UI;
using Windows.Storage;
using LoveNeuroWinUI3.ViewModels;
using System.Numerics;
using System.Collections.ObjectModel;
using Windows.Storage.FileProperties;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LoveNeuroWinUI3.Views
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

        public Section6InkingZoneMenu()
        {
            InitializeComponent();
            inkingZoneViewModel = new InkingZoneViewModel();
            InkingZoneData();
            Analytics.TrackEvent(this.GetType().Name);
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
        //    UserActivity activity = await channel.GetOrCreateUserActivityAsync("ln" + "section60");

        //    activity.ActivationUri = new Uri("loveneuro://" + "section60");
        //    activity.VisualElements.DisplayText = "6.0. Inking Zone";
        //    activity.VisualElements.Content = Helpers.AdaptiveCardCreation.CreateAdaptiveCardWithoutImage("6.0. Inking Zone");
        //    Windows.UI.Color color = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToColor("#ff7201");
        //    activity.VisualElements.BackgroundColor = color;

        //    await activity.SaveAsync();

        //    _currentSession?.Dispose();

        //    _currentSession = activity.CreateSession();

        //}



        void InkingZoneData()
        {
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Basic Neuron",
                InkingZoneRename = "Basic Neuron",
                InkingZoneImage = "Neuron.png",
                InkingZoneDescription = "This diagram shows a typical multipolar neuron. Features of note include:<ul><li>Cell body</li><li>Axon</li><li>Nucleus</li><li>Dendrites</li><li>K+ and Na+ ion channels</li><li>Na+/K+ ATPase pump</li><li>Presynaptic terminal</li><li>Vesicles containing neurotransmitter</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Resting Membrane Potential",
                InkingZoneRename = " Resting Membrane Potential",
                InkingZoneImage = "rmpforink.png",
                InkingZoneDescription = "Resting Membrane Potential",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Synapse",
                InkingZoneRename = "Synapse",
                InkingZoneImage = "Synapse.png",
                InkingZoneDescription = "This diagram shows a typical synapse. Features of note include:<ul><li>Presynaptic neuron</li><li>Postsynaptic neuron</li><li>Presynaptic terminal</li><li>Vesicles (containing neurotransmitter molecules)</li><li>Calcium ion channels and calcium ions</li><li>Synaptic cleft</li><li>Neurotransmitter receptors</li><li>Sodium ion channels and sodium ions</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Reflex Arc",
                InkingZoneRename = "Reflex Arc",
                InkingZoneImage = "reflexarc.png",
                InkingZoneDescription = "Reflex Arc",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Lateral Aspect of the Brain",
                InkingZoneRename = "Lateral Aspect of the Brain",
                InkingZoneImage = "LateralBrain5.png",
                InkingZoneDescription = "This diagram shows the lateral aspect of the brain. Features of note include:<ul><li>The four lobes of the cerebral cortex (frontal, parietal, occipital, temporal)</li><li>Cerebellum</li><li>Pons</li><li>Medulla oblongata</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Medial Aspect of the Brain",
                InkingZoneRename = "Medial Aspect of the Brain",
                InkingZoneImage = "MedialBrain.png",
                InkingZoneDescription = "This diagram shows the medial aspect of the brain. Features of note include:<ul><li>The four lobes of the cerebral cortex (frontal, parietal, occipital, temporal)</li><li>Cerebellum</li><li>Brainstem (midbrain, pons, medulla oblongata)</li><li>Thalamus</li><li>Hypothalamus</li><li>Corpus callosum</li><li>Pituitary gland</li>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Brachial Plexus",
                InkingZoneRename = "Brachial Plexus",
                InkingZoneImage = "BrachialPlexus.png",
                InkingZoneDescription = "This diagram shows the brachial plexus and its main branches, including:<ul><li>Musculocutaneous nerve</li><li>Radial nerve</li><li>Ulnar nerve</li><li>Median nerve</li><li>Axillary nerve</li><li>Long thoracic nerve</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Circle of Willis",
                InkingZoneRename = "Circle of Willis",
                InkingZoneImage = "CircleOfWillis.png",
                InkingZoneDescription = "This diagram shows the circle of Willis at the base of the brain. Features of note include:<ul><li>1. Anterior cerebral artery</li><li>2. Anterior communicating artery</li><li>3. Internal carotid artery</li><li>4. Middle cerebral artery</li><li>5. Posterior communicating artery</li><li>6. Posterior cerebral artery</li><li>7. Superior cerebellar artery</li><li>8. Basilar artery</li><li>9. Pontine branch</li><li>10. Anterior inferior cerebellar artery</li><li>11. Posterior inferior cerebellar artery</li><li>12. Vertebral artery</li><li>13. Anterior spinal artery</li><li>14. Posterior spinal artery</li></ul><ul><li>A. Frontal lobe</li><li>B. Olfactory bulb</li><li>C. Optic chiasm</li><li>D. Temporal lobe</li><li>E. Midbrain</li><li>F. Mamillary bodies</li><li>G. Pons</li><li>H. Cerebellum</li><li>I. Medulla</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Spinal Cord Divisions",
                InkingZoneRename = "Spinal Cord Divisions",
                InkingZoneImage = "SpinalCordDivisions.png",
                InkingZoneDescription = "This diagram shows the divisions of the spinal cord. Features of note include:<ul><li>Medulla oblongata</li><li>Cervical division of the spinal cord</li><li>Thoracic division of the spinal cord</li><li>Lumbar division of the spinal cord</li><li>Sacral division of the spinal cord</li><li>Coccygeal division of the spinal cord</li><li>Vertebral column (specifically, vertebral bodies and spinous processes)</li><li>Spinal cord proper</li><li>Conus medullaris</li><li>Cauda equina</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Cerebral Cortex",
                InkingZoneRename = "Cerebral Cortex",
                InkingZoneImage = "CerebralCortex.png",
                InkingZoneDescription = "This diagram shows the main functional areas of the cerebral cortex. Features of note include:<ul><li>Primary motor cortex (precentral gyrus)</li><li>Central sulcus</li><li>Primary somatosensory cortex (postcentral gyrus)</li><li>Sensory association cortex</li><li>Primary visual cortex</li><li>Visual association cortex</li><li>Wernicke's area</li><li>Primary auditory cortex</li><li>Temporal gyri (superior, middle and inferior)</li><li>Lateral sulcus</li><li>Broca's area</li><li>Prefrontal cortex</li><li>Premotor cortex</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Ventricles of the Brain",
                InkingZoneRename = "Ventricles of the Brain",
                InkingZoneImage = "Ventricles.png",
                InkingZoneDescription = "This diagram shows the ventricles of the brain. Features of note include:<ul><li>Lateral ventricles (left and right)</li><li>Interventricular foramen</li><li>Third ventricle</li><li>Cerebral aqueduct</li><li>Fourth ventricle</li><li>Central canal of the spinal cord</li><li>Lateral apertures (left and right)</li><li>Median aperture</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Coronal Section with Basal Ganglia and Corpus Callosum",
                InkingZoneRename = " Coronal Section with Basal Ganglia",
                InkingZoneImage = "CoronalSection.png",
                InkingZoneDescription = "This diagram shows a coronal section of the human brain with the basal ganglia, lateral and third ventricles and thalamus shown.",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Brainstem (Anterior)",
                InkingZoneRename = " Brainstem (Anterior)",
                InkingZoneImage = "brainstem.png",
                InkingZoneDescription = "brainstem",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Spinal Cord Cross-Section",
                InkingZoneRename = " Spinal Cord Cross-Section",
                InkingZoneImage = "spinalcrosssection.png",
                InkingZoneDescription = "Spinal Cord Cross-Section",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Spinal Tracts Matching Exercise",
                InkingZoneRename = "Spinal Tracts Matching Exercise",
                InkingZoneImage = "MatchingExercise.png",
                InkingZoneDescription = "This diagram shows the spinal tracts. Try matching the tract names with their functions.",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Ventricles Matching Exercise",
                InkingZoneRename = " Ventricles Matching Exercise",
                InkingZoneImage = "definitionmatch.png",
                InkingZoneDescription = "Ventricles Matching Exercise",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "HPA Axis",
                InkingZoneRename = " HPA Axis",
                InkingZoneImage = "cortisolink.png",
                InkingZoneDescription = "Ventricles Matching Exercise",
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

        private async void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            //GridView gridView = (GridView)sender;
            //MenuFlyout1.ShowAt(gridView, e.GetPosition(gridView));
            //var a = ((FrameworkElement)e.OriginalSource).DataContext as StorageFile;
            //await a.DeleteAsync();

            //var mfi = (MenuFlyoutItem)sender;
            //var item = (StorageFile)mfi.CommandParameter as StorageFile;
            //await item.DeleteAsync();



            //SelectedItem = (sender as MenuFlyoutItem).DataContext as InkingZoneClassDetail;
            //inkingZoneViewModel.ModelList.Remove(SelectedItem);

            //var mfi = (MenuFlyoutItem)sender;
            //var item = (StorageFile)mfi.CommandParameter as StorageFile;
            //if (item != null)
            //{

            //    //foreach (StorageFile del in GridViewInkingStrokes.Items)
            //    //{
            //        GridViewInkingStrokes.Items.Remove(item);

            //    //}
            //}



            //    var mfi = (MenuFlyoutItem)sender;
            //var item = (InkingZoneClassDetail)mfi.CommandParameter as InkingZoneClassDetail;
            //inkingZoneViewModel.ModelList.Remove(item);

            //string json = JsonConvert.SerializeObject(GridViewInkingStrokes.Items);
            //var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("myconfig.json", CreationCollisionOption.ReplaceExisting);
            //await FileIO.WriteTextAsync(file, json);

            //var file2 = await ApplicationData.Current.LocalFolder.GetFileAsync("myconfig.json");
            //string id = await FileIO.ReadTextAsync(file2);
            //var utah = JsonConvert.DeserializeObject<ObservableCollection<InkingZoneClassDetail>>(id);

            //GridViewInkingStrokes.ItemsSource = utah;

            //var folder = ApplicationData.Current.LocalFolder;
            //var file = await folder.CreateFileAsync("myconfig.json", CreationCollisionOption.ReplaceExisting);
            //using (var stream = await file.OpenStreamForWriteAsync())
            //using (var writer = new StreamWriter(stream, Encoding.UTF8))
            //{
            //    string json = JsonConvert.SerializeObject(inkingZoneViewModel.ModelList);
            //    await writer.WriteAsync(json);
            //}

            //var folder2 = ApplicationData.Current.RoamingFolder;
            //var file2 = await folder.GetFileAsync("myconfig.json");
            //using (var stream = await file.OpenStreamForReadAsync())
            //using (var reader = new StreamReader(stream, Encoding.UTF8))
            //{
            //    string json = await reader.ReadToEndAsync();
            //    var collection = JsonConvert.DeserializeObject<ObservableCollection<InkingZoneClassDetail>>(json);
            //    GridViewInkingStrokes.ItemsSource = collection;
            //}

        }

        public StorageItemThumbnail thumbnail;

        private async void GridViewInkingStrokes_Loaded(object sender, RoutedEventArgs e)
        {
            StorageFolder appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("InkingFolder", CreationCollisionOption.OpenIfExists);
            itemsList = await appFolder.GetFilesAsync();
            GridViewInkingStrokes.ItemsSource = itemsList;




            //StorageFolder appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("InkFolder", CreationCollisionOption.OpenIfExists);
            //itemsList = await appFolder.GetFilesAsync();

            //foreach (StorageFile file in itemsList)
            //{
            //    // Get thumbnail
            //    const uint requestedSize = 500;
            //    const ThumbnailMode thumbnailMode = ThumbnailMode.PicturesView;
            //    const ThumbnailOptions thumbnailOptions = ThumbnailOptions.UseCurrentScale;
            //    thumbnail = await file.GetThumbnailAsync(thumbnailMode, requestedSize, thumbnailOptions);
            //}
            //    GridViewInkingStrokes.ItemsSource = itemsList;
        



























        //StorageFolder appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("TestFolder", CreationCollisionOption.OpenIfExists);
        //itemsList = await appFolder.GetFilesAsync();



        //GridViewInkingStrokes.ItemsSource = itemsList;


    }

        private void MyGrid_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            //// Right tapped item's data
            //var singleItem = (sender as FrameworkElement).DataContext as InkingZoneClassDetail;

            //// All selected items in the GridView
            //var selectedItems = GridViewInkingStrokes.SelectedItems.Cast<InkingZoneClassDetail>();

            //// If the right tapped data is not currently selected, select it. 
            //if (!selectedItems.Contains(singleItem))
            //{
            //    GridViewInkingStrokes.SelectedItem = singleItem; // Select the right tapped item.
            //}

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

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            var a = ((FrameworkElement)e.OriginalSource).DataContext as StorageFile;
            await a.DeleteAsync();
            GridViewInkingStrokes_Loaded(sender, e);

        }
    }
}


