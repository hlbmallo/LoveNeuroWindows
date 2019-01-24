using HeartCentreW104.Helpers;
using Microsoft.AppCenter.Analytics;
using Microsoft.Toolkit.Uwp.Helpers;
using Microsoft.Toolkit.Uwp.UI.Animations;
using Microsoft.Toolkit.Uwp.UI.Extensions;
using Microsoft.WindowsAzure.Storage.Blob;
using NerveCentreW10.Models;
using NerveCentreW10.Services;
using NerveCentreW10.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.UserActivities;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

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
        UserActivitySession _currentSession;

        public Section6InkingZoneMenu()
        {
            InitializeComponent();
            inkingZoneViewModel = new InkingZoneViewModel();
            InkingZoneData();
            Analytics.TrackEvent(this.GetType().Name);
            GenerateUserActivityOverArching();
        }

        async void GenerateUserActivityOverArching()
        {
            await GenerateActivityAsync();
        }

        private async Task GenerateActivityAsync()
        {

            // Get channel and create activity.
            UserActivityChannel channel = UserActivityChannel.GetDefault();
            UserActivity activity = await channel.GetOrCreateUserActivityAsync("nc" + "section6");

            activity.ActivationUri = new Uri("nervecentre://" + "section6");
            activity.VisualElements.DisplayText = "6.0. Inking Zone";
            activity.VisualElements.Content = Helpers.AdaptiveCardCreation.CreateAdaptiveCardWithoutImage("6.0. Inking Zone");
            Windows.UI.Color color = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.ToColor("#ff7201");
            activity.VisualElements.BackgroundColor = color;

            await activity.SaveAsync();

            _currentSession?.Dispose();

            _currentSession = activity.CreateSession();

        }



        void InkingZoneData()
        {
            CloudClass cloudclass = new CloudClass();

            CloudBlobContainer container = new CloudBlobContainer(new Uri(cloudclass.GetContainerSasUri(cloudclass.MyCloudClass())));

            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Lateral Aspect of the Brain",
                InkingZoneRename = "Lateral Aspect of the Brain",
                InkingZoneImage = container.GetBlockBlobReference("LateralBrain4.png").Uri,
                InkingZoneDescription = "This diagram shows the lateral aspect of the brain. Features of note include:<ul><li>The four lobes of the cerebral cortex (frontal, parietal, occipital, temporal)</li><li>Cerebellum</li><li>Pons</li><li>Medulla oblongata</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Medial Aspect of the Brain",
                InkingZoneRename = "Medial Aspect of the Brain",
                InkingZoneImage = container.GetBlockBlobReference("MedialBrain.png").Uri,
                InkingZoneDescription = "This diagram shows the medial aspect of the brain. Features of note include:<ul><li>The four lobes of the cerebral cortex (frontal, parietal, occipital, temporal)</li><li>Cerebellum</li><li>Brainstem (midbrain, pons, medulla oblongata)</li><li>Thalamus</li><li>Hypothalamus</li><li>Corpus callosum</li><li>Pituitary gland</li>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Basic Neuron",
                InkingZoneRename = "Basic Neuron",
                InkingZoneImage = container.GetBlockBlobReference("Neuron.png").Uri,
                InkingZoneDescription = "This diagram shows a typical multipolar neuron. Features of note include:<ul><li>Cell body</li><li>Axon</li><li>Nucleus</li><li>Dendrites</li><li>K+ and Na+ ion channels</li><li>Na+/K+ ATPase pump</li><li>Presynaptic terminal</li><li>Vesicles containing neurotransmitter</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Brachial Plexus",
                InkingZoneRename = "Brachial Plexus",
                InkingZoneImage = container.GetBlockBlobReference("BrachialPlexus.png").Uri,
                InkingZoneDescription = "This diagram shows the brachial plexus and its main branches, including:<ul><li>Musculocutaneous nerve</li><li>Radial nerve</li><li>Ulnar nerve</li><li>Median nerve</li><li>Axillary nerve</li><li>Long thoracic nerve</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Circle of Willis",
                InkingZoneRename = "Circle of Willis",
                InkingZoneImage = container.GetBlockBlobReference("CircleOfWillis.png").Uri,
                InkingZoneDescription = "This diagram shows the circle of Willis at the base of the brain. Features of note include:<ul><li>1. Anterior cerebral artery</li><li>2. Anterior communicating artery</li><li>3. Internal carotid artery</li><li>4. Middle cerebral artery</li><li>5. Posterior communicating artery</li><li>6. Posterior cerebral artery</li><li>7. Superior cerebellar artery</li><li>8. Basilar artery</li><li>9. Pontine branch</li><li>10. Anterior inferior cerebellar artery</li><li>11. Posterior inferior cerebellar artery</li><li>12. Vertebral artery</li><li>13. Anterior spinal artery</li><li>14. Posterior spinal artery</li></ul><ul><li>A. Frontal lobe</li><li>B. Olfactory bulb</li><li>C. Optic chiasm</li><li>D. Temporal lobe</li><li>E. Midbrain</li><li>F. Mamillary bodies</li><li>G. Pons</li><li>H. Cerebellum</li><li>I. Medulla</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Spinal Cord Divisions",
                InkingZoneRename = "Spinal Cord Divisions",
                InkingZoneImage = container.GetBlockBlobReference("SpinalCordDivisions.png").Uri,
                InkingZoneDescription = "This diagram shows the divisions of the spinal cord. Features of note include:<ul><li>Medulla oblongata</li><li>Cervical division of the spinal cord</li><li>Thoracic division of the spinal cord</li><li>Lumbar division of the spinal cord</li><li>Sacral division of the spinal cord</li><li>Coccygeal division of the spinal cord</li><li>Vertebral column (specifically, vertebral bodies and spinous processes)</li><li>Spinal cord proper</li><li>Conus medullaris</li><li>Cauda equina</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Cerebral Cortex",
                InkingZoneRename = "Cerebral Cortex",
                InkingZoneImage = container.GetBlockBlobReference("CerebralCortex.png").Uri,
                InkingZoneDescription = "This diagram shows the main functional areas of the cerebral cortex. Features of note include:<ul><li>Primary motor cortex (precentral gyrus)</li><li>Central sulcus</li><li>Primary somatosensory cortex (postcentral gyrus)</li><li>Sensory association cortex</li><li>Primary visual cortex</li><li>Visual association cortex</li><li>Wernicke's area</li><li>Primary auditory cortex</li><li>Temporal gyri (superior, middle and inferior)</li><li>Lateral sulcus</li><li>Broca's area</li><li>Prefrontal cortex</li><li>Premotor cortex</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Synapse",
                InkingZoneRename = "Synapse",
                InkingZoneImage = container.GetBlockBlobReference("Synapse.png").Uri,
                InkingZoneDescription = "This diagram shows a typical synapse. Features of note include:<ul><li>Presynaptic neuron</li><li>Postsynaptic neuron</li><li>Presynaptic terminal</li><li>Vesicles (containing neurotransmitter molecules)</li><li>Calcium ion channels and calcium ions</li><li>Synaptic cleft</li><li>Neurotransmitter receptors</li><li>Sodium ion channels and sodium ions</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Ventricles of the Brain",
                InkingZoneRename = "Ventricles of the Brain",
                InkingZoneImage = container.GetBlockBlobReference("Ventricles.png").Uri,
                InkingZoneDescription = "This diagram shows the ventricles of the brain. Features of note include:<ul><li>Lateral ventricles (left and right)</li><li>Interventricular foramen</li><li>Third ventricle</li><li>Cerebral aqueduct</li><li>Fourth ventricle</li><li>Central canal of the spinal cord</li><li>Lateral apertures (left and right)</li><li>Median aperture</li></ul>",
            });
            InkingZoneList.Add(new InkingZoneClassDetail
            {
                InkingZoneTitle = "Spinal Tracts Matching Exercise",
                InkingZoneRename = "Spinal Tracts Matching Exercise",
                InkingZoneImage = container.GetBlockBlobReference("MatchingExercise.png").Uri,
                InkingZoneDescription = "This diagram shows the spinal tracts. Try matching the tract names with their functions.",
            });
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var MyClickedItem = e.ClickedItem as InkingZoneClassDetail;
            //string json = JsonConvert.SerializeObject(MyClickedItem);
            //string json2 = JsonConvert.SerializeObject(inkingZoneViewModel);

            //Dictionary<string, string> newDictionary = new Dictionary<string, string>();
            //newDictionary.Add("json", json);
            //newDictionary.Add("json2", json2);
            //Frame.Navigate(typeof(InkingZoneDetail), newDictionary);

            var MyClickedItem = (InkingZoneClassDetail)e.ClickedItem as InkingZoneClassDetail;

            Frame.Navigate(typeof(InkingZoneDetail), MyClickedItem);

            //var myList = new List<string>()
            //{
            //   json,
            //   json2,
            //};

            //Frame.Navigate(typeof(InkingZoneDetail), myList);
        }

        private void GridViewInkingStrokes_ItemClick(object sender, ItemClickEventArgs e)
        {

            //var MyClickedItem = e.ClickedItem as InkingZoneClassDetail;
            //string json = JsonConvert.SerializeObject(MyClickedItem);
            //string json2 = JsonConvert.SerializeObject(inkingZoneViewModel);

            //Dictionary<string, string> newDictionary = new Dictionary<string, string>();
            //newDictionary.Add("json", json);
            //newDictionary.Add("json2", json2);
            //Frame.Navigate(typeof(InkingZoneDetail), newDictionary);

            var MyClickedItem = (StorageFile)e.ClickedItem;

            Frame.Navigate(typeof(InkingZoneDetail), MyClickedItem);
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

        private async void GridViewInkingStrokes_Loaded(object sender, RoutedEventArgs e)
        {
            //if (await ApplicationData.Current.LocalFolder.FileExistsAsync("myconfig.json") == true)
            //{
            //    var file = await ApplicationData.Current.LocalFolder.GetFileAsync("myconfig.json");
            //    string id = await FileIO.ReadTextAsync(file);
            //    var cramp = JsonConvert.DeserializeObject<ObservableCollection<InkingZoneClassDetail>>(id);
            //    GridViewInkingStrokes.ItemsSource = cramp;
            //}

            //else
            //{
            //    var file2 = await ApplicationData.Current.LocalFolder.CreateFileAsync("myconfig.json", CreationCollisionOption.ReplaceExisting);

            //}


            //var localObjectStorageHelper = new LocalObjectStorageHelper();
            //string keyLargeObject = "large";
            //var result = localObjectStorageHelper.ReadFileAsync<ObservableCollection<InkingZoneClassDetail>>(keyLargeObject);
            //GridViewInkingStrokes.ItemsSource = result;



            //var localObjectStorageHelper = new LocalObjectStorageHelper();
            //localObjectStorageHelper. = ApplicationData.Current.LocalFolder;
            //StorageFolder subFolder = await localObjectStorageHelper.Folder.CreateFolderAsync("NerveCentreInk", CreationCollisionOption.OpenIfExists);
            //IReadOnlyList<IStorageItem> itemsList = await subFolder.GetItemsAsync();



            StorageFolder appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("TestFolder", CreationCollisionOption.OpenIfExists);
            itemsList = await appFolder.GetFilesAsync();

            //itemsList = await appFolder.GetFilesAsync();
            //foreach (StorageFile item in itemsList)
            //{
            //    if (item == null)
            //    {

            //    }

            //    else
            //    {
            //        string zoo = await FileIO.ReadTextAsync(item);
            //        var yell = JsonConvert.DeserializeObject<InkingZoneClassDetail>(zoo);
            //    }



            //}

            GridViewInkingStrokes.ItemsSource = itemsList;


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
            MenuFlyoutItem callItem = new MenuFlyoutItem { Text = "Call" };
            MenuFlyoutItem sendItem = new MenuFlyoutItem { Text = "Send a message" };
            MenuFlyoutItem deleteItem = new MenuFlyoutItem { Text = "Delete" };

            myFlyout.Items.Add(callItem);
            myFlyout.Items.Add(sendItem);
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
    }
}


