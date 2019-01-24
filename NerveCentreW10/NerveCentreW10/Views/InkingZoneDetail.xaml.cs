using Microsoft.AppCenter.Analytics;
using Microsoft.Graphics.Canvas;
using Microsoft.Toolkit.Uwp.Helpers;
using Microsoft.Toolkit.Uwp.UI.Animations;
using NerveCentreW10.Helpers;
using NerveCentreW10.Models;
using NerveCentreW10.Services.Ink;
using NerveCentreW10.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Input.Inking;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace NerveCentreW10.Views
{
    public sealed partial class InkingZoneDetail : Page
    {
        private PrintHelper printHelper;
        private InkPointerDeviceService pointerDeviceService;
        private InkZoomService zoomService;

        public ObservableCollection<InkingZoneClassDetail> InkingZoneListEdits { get; } = new ObservableCollection<InkingZoneClassDetail>();

        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

        public InkingZoneClassDetail myclickeditem;

        public InkingZoneViewModel inkingZoneViewModel;

        public static string InkingZoneRenameUpdate;

        public InkingZoneDetail()
        {
            InitializeComponent();
            SetCanvasSize();
            MyImage.SizeChanged += Image_SizeChanged;
            zoomService = new InkZoomService(canvasScroll);
            pointerDeviceService = new InkPointerDeviceService(MyInkCanvas);
            touchInkingButton.IsChecked = true;
            mouseInkingButton.IsChecked = true;
            if (Windows.Foundation.Metadata.ApiInformation.IsPropertyPresent("Windows.UI.Xaml.FrameworkElement", "AllowFocususeracOnInteraction"))
                InkRenameBox.AllowFocusOnInteraction = true;
            Analytics.TrackEvent(this.GetType().Name);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            Analytics.TrackEvent(this.GetType().Name);

            //Dictionary<string, string> myDictionary = new Dictionary<string, string>();
            //myDictionary = e.Parameter as Dictionary<string, string>;
            //var json = myDictionary["json"].ToString();
            //var json2 = myDictionary["json2"].ToString();

            //inkingZoneClassDetail = JsonConvert.DeserializeObject<InkingZoneClassDetail>(json);
            //Title.Text = inkingZoneClassDetail.InkingZoneRename;


            if (e.Parameter is InkingZoneClassDetail)
            {
                var xenon = e.Parameter as InkingZoneClassDetail;
                MyImage.Source = new BitmapImage(xenon.InkingZoneImage);
                Title.Text = xenon.InkingZoneRename;
                myclickeditem = xenon;
            }
            //inkingZoneClassDetail = (InkingZoneClassDetail)e.Parameter;

            //MyImage.Source = new BitmapImage(inkingZoneClassDetail.InkingZoneImage);
            //if (inkingZoneClassDetail.InkingZoneBytes == null)
            //{

            //}
            else
            {
                //byte[] bytes = inkingZoneClassDetail.InkingZoneBytes;
                ////MemoryStream stream = new MemoryStream(bytes);
                ////var happy = await ConvertToRandomAccessStream(stream);
                ////var hoping = stream.AsRandomAccessStream();
                ////var crimson = ConvertTo(bytes);
                ////MemoryStream stream = new MemoryStream(bytes);
                ////var hoping = stream.AsRandomAccessStream();
                //var crumbs = ConvertTo(bytes).Result;
                //using (var inputStream = crumbs.GetInputStreamAt(0))
                //{
                //    await MyInkCanvas.InkPresenter.StrokeContainer.LoadAsync(inputStream);
                //}

                //crumbs.Dispose();









                var storageFile = (StorageFile)e.Parameter;
                string zoo = await FileIO.ReadTextAsync(storageFile);
                var yell = JsonConvert.DeserializeObject<InkingZoneClassDetail>(zoo);





                //var localObjectStorageHelper = new Helpers.LocalObjectStorageHelper();
                //localObjectStorageHelper.Folder = ApplicationData.Current.LocalFolder;
                //StorageFolder subFolder = await localObjectStorageHelper.Folder.GetFolderAsync("NerveCentreInk");
                ////IReadOnlyList<IStorageItem> itemsList = await subFolder.GetItemsAsync();

                //var result = await localObjectStorageHelper.ReadFileAsync<InkingZoneClassDetail>("/NerveCentreInk/" + storageFile.Name);

                Title.Text = yell.InkingZoneRename;
                MyImage.Source = new BitmapImage(yell.InkingZoneImage);
                byte[] bytes = yell.InkingZoneBytes;
                var stream = ConvertTo(bytes).Result;
                using (var inputStream = stream.GetInputStreamAt(0))
                {
                    await MyInkCanvas.InkPresenter.StrokeContainer.LoadAsync(inputStream);
                }

                stream.Dispose();

            }


            //inkingZoneViewModel = JsonConvert.DeserializeObject<InkingZoneViewModel>(json2);

        }

        internal static async Task<InMemoryRandomAccessStream> ConvertTo(byte[] arr)
        {
            InMemoryRandomAccessStream randomAccessStream = new InMemoryRandomAccessStream();
            await randomAccessStream.WriteAsync(arr.AsBuffer());
            randomAccessStream.Seek(0); // Just to be sure.
                                        // I don't think you need to flush here, but if it doesn't work, give it a try.
            return randomAccessStream;
        }

        private static async Task<IRandomAccessStreamReference> ConvertToRandomAccessStream(MemoryStream memoryStream)
        {
            var randomAccessStream = new InMemoryRandomAccessStream();
            var outputStream = randomAccessStream.GetOutputStreamAt(0);
            await RandomAccessStream.CopyAndCloseAsync(memoryStream.AsInputStream(), outputStream);
            var result = RandomAccessStreamReference.CreateFromStream(randomAccessStream);
            return result;
        }

        //internal static IRandomAccessStream ConvertTo(byte[] arr)
        //{
        //    return arr.AsBuffer().AsStream().AsRandomAccessStream();
        //}

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Analytics.TrackEvent("SaveInkedDiagramButton_Click");

            // grab output file
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            savePicker.FileTypeChoices.Add("Jpeg (*.jpg)", new List<string>() { ".jpg" });
            savePicker.SuggestedFileName = "Nerve Centre Diagram";
            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();

            if (file == null)
            {
                // The user cancelled the picking operation
                return;
            }

            else
            {
                CanvasDevice device = CanvasDevice.GetSharedDevice();
                CanvasRenderTarget renderTarget = new CanvasRenderTarget(device, (int)MyInkCanvas.ActualWidth, (int)MyInkCanvas.ActualHeight, 200);

                var image = await CanvasBitmap.LoadAsync(device, ((BitmapImage)MyImage.Source).UriSource);
                using (var ds = renderTarget.CreateDrawingSession())
                {
                    var imageBounds = image.GetBounds(device);

                    ds.DrawImage(image, new Rect(0, 0, MyInkCanvas.ActualWidth, MyInkCanvas.ActualHeight), imageBounds);
                    ds.DrawInk(MyInkCanvas.InkPresenter.StrokeContainer.GetStrokes());
                }

                // save results
                using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    await renderTarget.SaveAsync(fileStream, CanvasBitmapFileFormat.Jpeg, 1f);
                }
            }
        }

        private async Task Save_InkedImagetoStream(IRandomAccessStream stream)
        {
            var file = await StorageFile.GetFileFromPathAsync(((BitmapImage)MyImage.Source).UriSource.ToString());
            CanvasDevice device = CanvasDevice.GetSharedDevice();
            CanvasRenderTarget renderTarget = new CanvasRenderTarget(device, (int)MyInkCanvas.ActualWidth, (int)MyInkCanvas.ActualHeight, 200);

            var image = await CanvasBitmap.LoadAsync(device, ((BitmapImage)MyImage.Source).UriSource);
            using (var ds = renderTarget.CreateDrawingSession())
            {
                var imageBounds = image.GetBounds(device);

                ds.DrawImage(image, new Rect(0, 0, MyInkCanvas.ActualWidth, MyInkCanvas.ActualHeight), imageBounds);
                ds.DrawInk(MyInkCanvas.InkPresenter.StrokeContainer.GetStrokes());
            }

            await renderTarget.SaveAsync(stream, CanvasBitmapFileFormat.Jpeg, 1f);
        }



        /// Saves coloring page to specified file.

        private async Task Save_InkedImagetoFile(StorageFile saveFile)
        {
            if (saveFile != null)
            {
                Windows.Storage.CachedFileManager.DeferUpdates(saveFile);
                using (var outStream = await saveFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    await Save_InkedImagetoStream(outStream);
                }

                Windows.Storage.Provider.FileUpdateStatus status =
                await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(saveFile);
            }
        }

        public async void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("PrintImageFolder", CreationCollisionOption.ReplaceExisting);
            StorageFile printFile = await folder.CreateFileAsync("printFile.png", CreationCollisionOption.ReplaceExisting);
            await Save_InkedImagetoFile(printFile);
            var stream = await printFile.OpenReadAsync();
            var bitmapImage = new BitmapImage();
            bitmapImage.SetSource(stream);
            MyImagePreview.Source = bitmapImage;

            if (DirectPrintContainer.Children.Contains(PrintableContent))
            {
                DirectPrintContainer.Children.Remove(PrintableContent);
            }

            printHelper = new PrintHelper(Container);
            printHelper.AddFrameworkElementToPrint(PrintableContent);
            printHelper.OnPrintCanceled += PrintHelper_OnPrintCanceled;
            printHelper.OnPrintSucceeded += PrintHelper_OnPrintSucceeded;
            await printHelper.ShowPrintUIAsync("Nerve Centre Print");
            await folder.DeleteAsync(StorageDeleteOption.PermanentDelete);
        }

        private void ReleasePrintHelper()
        {
            printHelper.Dispose();
        }

        private void PrintHelper_OnPrintCanceled()
        {
            ReleasePrintHelper();
            //var dialog = new MessageDialog("Printing cancelled.");
            //await dialog.ShowAsync();
        }

        private async void PrintHelper_OnPrintSucceeded()
        {
            ReleasePrintHelper();
            var dialog = new MessageDialog("Printing completed.");
            await dialog.ShowAsync();
        }

        private async void LoadInkStrokes_Click(object sender, RoutedEventArgs e)
        {
            // Let users choose their ink file using a file picker.
            // Initialize the picker.
            Windows.Storage.Pickers.FileOpenPicker openPicker =
                new Windows.Storage.Pickers.FileOpenPicker();
            openPicker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            openPicker.FileTypeFilter.Add(".gif");
            // Show the file picker.
            Windows.Storage.StorageFile file = await openPicker.PickSingleFileAsync();
            // User selects a file and picker returns a reference to the selected file.
            if (file != null)
            {
                // Open a file stream for reading.
                IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                // Read from file.
                using (var inputStream = stream.GetInputStreamAt(0))
                {
                    await MyInkCanvas.InkPresenter.StrokeContainer.LoadAsync(inputStream);
                }
                stream.Dispose();
            }
            // User selects Cancel and picker returns null.
            else
            {
                // Operation cancelled.
            }
        }

        private async void SaveInkStrokes_Click(object sender, RoutedEventArgs e)
        {
            Analytics.TrackEvent("SaveInkStrokes_Click");

            // Get all strokes on the InkCanvas.
            IReadOnlyList<InkStroke> currentStrokes = MyInkCanvas.InkPresenter.StrokeContainer.GetStrokes();

            // Strokes present on ink canvas.
            if (currentStrokes.Count > 0)
            {
                // Let users choose their ink file using a file picker.
                // Initialize the picker.
                Windows.Storage.Pickers.FileSavePicker savePicker =
                    new Windows.Storage.Pickers.FileSavePicker();
                savePicker.SuggestedStartLocation =
                    Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
                savePicker.FileTypeChoices.Add(
                    "GIF with embedded ISF",
                    new List<string>() { ".gif" });
                savePicker.DefaultFileExtension = ".gif";
                savePicker.SuggestedFileName = "InkSample";

                // Show the file picker.
                Windows.Storage.StorageFile file =
                    await savePicker.PickSaveFileAsync();
                // When chosen, picker returns a reference to the selected file.
                if (file != null)
                {
                    // Prevent updates to the file until updates are 
                    // finalized with call to CompleteUpdatesAsync.
                    Windows.Storage.CachedFileManager.DeferUpdates(file);
                    // Open a file stream for writing.
                    IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                    // Write the ink strokes to the output stream.
                    using (IOutputStream outputStream = stream.GetOutputStreamAt(0))
                    {
                        await MyInkCanvas.InkPresenter.StrokeContainer.SaveAsync(outputStream);
                        await outputStream.FlushAsync();
                    }
                    stream.Dispose();

                    // Finalize write so other apps can update file.
                    Windows.Storage.Provider.FileUpdateStatus status =
                        await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);

                    if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                    {
                        // File saved.
                    }
                    else
                    {
                        // File couldn't be saved.
                    }
                }
                // User selects Cancel and picker returns null.
                else
                {
                    // Operation cancelled.
                }
            }

        }

        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            zoomService?.ZoomIn();
        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            zoomService?.ZoomOut();
        }

        private void SetCanvasSize()
        {
            MyInkCanvas.Width = Math.Max(canvasScroll.ViewportWidth, 1000);
            MyInkCanvas.Height = Math.Max(canvasScroll.ViewportHeight, 1000);
        }

        private void Image_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height == 0 || e.NewSize.Width == 0)
            {
                SetCanvasSize();
            }
            else
            {
                MyInkCanvas.Width = e.NewSize.Width;
                MyInkCanvas.Height = e.NewSize.Height;
            }
        }

        private void TouchInking_Checked(object sender, RoutedEventArgs e) => pointerDeviceService.EnableTouch = true;

        private void TouchInking_Unchecked(object sender, RoutedEventArgs e) => pointerDeviceService.EnableTouch = false;

        private void MouseInking_Checked(object sender, RoutedEventArgs e) => pointerDeviceService.EnableMouse = true;

        private void MouseInking_Unchecked(object sender, RoutedEventArgs e) => pointerDeviceService.EnableMouse = false;

        private void MyImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            zoomService?.FitToSize(MyImage.ActualWidth, MyImage.ActualHeight);
        }

        //private void AppBarButton_Click(object sender, RoutedEventArgs e)
        //{
        //    //FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        //}

        private async void InkRenameConfirm_Click(object sender, RoutedEventArgs e)
        {
            //if (localSettings.Values["Scramble"] != null)
            //{
            //    var id = localSettings.Values["Scramble"] as string;
            //    inkingZoneViewModel = JsonConvert.DeserializeObject<InkingZoneViewModel>(id);

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("serious.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            IRandomAccessStream stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

            //await MyInkCanvas.InkPresenter.StrokeContainer.SaveAsync(stream);
            //await stream.FlushAsync();

            using (IOutputStream outputStream = stream.GetOutputStreamAt(0))
            {
                await MyInkCanvas.InkPresenter.StrokeContainer.SaveAsync(outputStream);
                await outputStream.FlushAsync();
            }

            byte[] bytes = new byte[stream.Size];


            var buffer = await stream.ReadAsync(bytes.AsBuffer(), (uint)stream.Size, InputStreamOptions.None);
            var bytes2 = buffer.ToArray();

            stream.Dispose();















            //var localObjectStorageHelper = new Microsoft.Toolkit.Uwp.Helpers.LocalObjectStorageHelper();
            //string filePath = localObjectStorageHelper.FileExistsAsync().Path;

            //string keyLargeObject = InkRenameBox.Text;

            //var o = new InkingZoneClassDetail
            //{
            //    InkingZoneRename = InkRenameBox.Text,
            //    InkingZoneImage = ((BitmapImage)MyImage.Source).UriSource,
            //    InkingZoneBytes = bytes2,
            //};

            //await localObjectStorageHelper.SaveFileAsync(filePath + keyLargeObject, o);




            //

            var appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("TestFolder", CreationCollisionOption.OpenIfExists);
            var o = new InkingZoneClassDetail
            {
                InkingZoneRename = InkRenameBox.Text,
                InkingZoneImage = ((BitmapImage)MyImage.Source).UriSource,
                InkingZoneBytes = bytes2,
            };

            string json = JsonConvert.SerializeObject(o);

            StorageFile shred = await appFolder.CreateFileAsync(InkRenameBox.Text);
            await FileIO.WriteTextAsync(shred, json);

            if (StandardPopup.Visibility == Visibility.Visible) { StandardPopup.Visibility = Visibility.Collapsed; }
            ImFinishedPopup.Visibility = Visibility.Visible;
        }

        // Handles the Click event on the Button inside the Popup control and 
        // closes the Popup. 
        //private async void ClosePopupClicked(object sender, RoutedEventArgs e)
        //{
        //    // if the Popup is open, then close it 
        //    if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }

        //    await MajorContentArea.Blur(0, 1500, 0).StartAsync();
        //}

        // Handles the Click event on the Button on the page and opens the Popup. 
        private async void ShowPopupOffsetClicked(object sender, RoutedEventArgs e)
        {
            await MajorContentArea.Blur(7, 500, 0).StartAsync();
            // open the Popup if it isn't open already 
            if (StandardPopup.Visibility == Visibility.Collapsed) { StandardPopup.Visibility = Visibility.Visible; }
        }

        private async void CloseSavedDialog_Click(object sender, RoutedEventArgs e)
        {
            if (ImFinishedPopup.Visibility == Visibility.Visible) { ImFinishedPopup.Visibility = Visibility.Collapsed; }
            await MajorContentArea.Blur(0, 500, 0).StartAsync();
        }

        //private void StandardPopup_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    var transform = Window.Current.Content.TransformToVisual(StandardPopup);
        //    Point point = transform.TransformPoint(new Point(0, 0)); // gets the window's (0,0) coordinate relative to the popup

        //    double hOffset = (Window.Current.Bounds.Width - this.ActualWidth) / 2;
        //    double vOffset = (Window.Current.Bounds.Height - this.ActualHeight) / 2;

        //    StandardPopup.HorizontalOffset = point.X + hOffset;
        //    StandardPopup.VerticalOffset = point.Y + vOffset;
        //}



























        // This is where the byteArray to be stored.
        //byte[] bytes = new byte[stream.Size];

        // This returns IAsyncOperationWithProgess, so you can add additional progress handling

        //byte[] bytes = new byte[stream.Size];

        //var buffer = new byte[stream.Size];
        //await stream.AsStream().ReadAsync(buffer, 0, buffer.Length);
        //string lol = Encoding.ASCII.GetString(buffer);

        //inkingZoneViewModel.ModelList.Add(new InkingZoneClassDetail
        //{
        //    InkingZoneRename = InkRenameBox.Text,
        //    InkingZoneImage = inkingZoneClassDetail.InkingZoneImage,
        //    InkingZoneBytes = bytes2,
        //});

        //string json = JsonConvert.SerializeObject(inkingZoneViewModel.ModelList);
        //var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(InkRenameBox.Text + ".json", CreationCollisionOption.GenerateUniqueName);
        //await FileIO.WriteTextAsync(file, json);


        //string json = JsonConvert.SerializeObject(cramp);

        //var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("myconfig.json", CreationCollisionOption.ReplaceExisting);
        //await FileIO.WriteTextAsync(file, json);
    }
}

            // localSettings.Values["Scramble"] = json;


//StreamReader reader = new StreamReader(stream);
//string text = reader.ReadToEnd();

















//// Strokes present on ink canvas.
//if (currentStrokes.Count > 0)
//{
//    StorageFile file = await localFolder.CreateFileAsync("ink.gif", CreationCollisionOption.ReplaceExisting);

//    if (file != null)
//    {
//        // Prevent updates to the file until updates are 
//        // finalized with call to CompleteUpdatesAsync.
//        Windows.Storage.CachedFileManager.DeferUpdates(file);
//        // Open a file stream for writing.
//        IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
//        // Write the ink strokes to the output stream.
//        using (IOutputStream outputStream = stream.GetOutputStreamAt(0))
//        {
//            await MyInkCanvas.InkPresenter.StrokeContainer.SaveAsync(outputStream);
//            await outputStream.FlushAsync();
//        }
//        stream.Dispose();

//        // Finalize write so other apps can update file.
//        Windows.Storage.Provider.FileUpdateStatus status =
//            await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);

//        if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
//        {
//            // File saved.
//        }
//        else
//        {
//            // File couldn't be saved.
//        }
//    }
//    // User selects Cancel and picker returns null.
//    else
//    {
//        // Operation cancelled.

//inkingZoneViewModel.ModelList.Add(new InkingZoneClassDetail
//{
//    InkingZoneRename = InkRenameBox.Text,
//    InkingZoneImage = inkingZoneClassDetail.InkingZoneImage,
//    InkingZoneStream = stream,
//});

//string json = JsonConvert.SerializeObject(inkingZoneViewModel);

//localSettings.Values["Scramble"] = json;
//}

//else
//{

//// Get all strokes on the InkCanvas.
//Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
//Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("sample.gif", Windows.Storage.CreationCollisionOption.ReplaceExisting);
//IRandomAccessStream stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
//// Write the ink strokes to the output stream.
//using (IOutputStream outputStream = stream.GetOutputStreamAt(0))
//{
//    await MyInkCanvas.InkPresenter.StrokeContainer.SaveAsync(outputStream);
//    await outputStream.FlushAsync();
//}
////stream.Dispose();
















//// Strokes present on ink canvas.
//if (currentStrokes.Count > 0)
//{
//    StorageFile file = await localFolder.CreateFileAsync("ink.gif", CreationCollisionOption.ReplaceExisting);

//    if (file != null)
//    {
//        // Prevent updates to the file until updates are 
//        // finalized with call to CompleteUpdatesAsync.
//        Windows.Storage.CachedFileManager.DeferUpdates(file);
//        // Open a file stream for writing.
//        IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
//        // Write the ink strokes to the output stream.
//        using (IOutputStream outputStream = stream.GetOutputStreamAt(0))
//        {
//            await MyInkCanvas.InkPresenter.StrokeContainer.SaveAsync(outputStream);
//            await outputStream.FlushAsync();
//        }
//        stream.Dispose();

//        // Finalize write so other apps can update file.
//        Windows.Storage.Provider.FileUpdateStatus status =
//            await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);

//        if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
//        {
//            // File saved.
//        }
//        else
//        {
//            // File couldn't be saved.
//        }
//    }
//    // User selects Cancel and picker returns null.
//    else
//    {
//        // Operation cancelled.

//    Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
//    Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("texty.txt", Windows.Storage.CreationCollisionOption.GenerateUniqueName);

//    IRandomAccessStream stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

//    //await MyInkCanvas.InkPresenter.StrokeContainer.SaveAsync(stream);
//    //await stream.FlushAsync();

//    using (IOutputStream outputStream = stream.GetOutputStreamAt(0))
//    {
//        await MyInkCanvas.InkPresenter.StrokeContainer.SaveAsync(outputStream);
//        await outputStream.FlushAsync();
//    }

//    byte[] bytes = new byte[stream.Size];

//    //var buffer = new byte[stream.Size];
//    //await stream.AsStream().ReadAsync(buffer, 0, buffer.Length);
//    //string lol = Encoding.ASCII.GetString(buffer);

//    inkingZoneViewModel.ModelList.Add(new InkingZoneClassDetail
//    {
//        InkingZoneRename = InkRenameBox.Text,
//        InkingZoneImage = inkingZoneClassDetail.InkingZoneImage,
//        //InkingZoneBufferStream = lol,
//        InkingZoneBytes = bytes,
//    });

//    string json = JsonConvert.SerializeObject(inkingZoneViewModel);

//    var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("myconfig.json", CreationCollisionOption.ReplaceExisting);
//    await FileIO.WriteTextAsync(file, json);

//    //    localSettings.Values["Scramble"] = json;
//}
//}

//}
//var localObjectStorageHelper = new LocalObjectStorageHelper();

//string keyLargeObject = "Scramble";
//var result = localObjectStorageHelper.ReadFileAsync<InkingZoneClass>(keyLargeObject);
//IReadOnlyList<InkStroke> currentStrokes = MyInkCanvas.InkPresenter.StrokeContainer.GetStrokes();
//var o = new InkingZoneClass
//{
//    InkingZoneTitle = InkRenameBox.Text,
//    InkingZoneStrokeList = currentStrokes,
//};

//localObjectStorageHelper.SaveFileAsync(keyLargeObject, o);




//else
//{
//    // Access data in composite["intVal"] and composite["strVal"]

//    var id = composite["Scramble"] as string;
//    RememberedViewModel.ModelList = JsonConvert.DeserializeObject<ObservableCollection<InkingZoneClass>>(id);

//    using (var stream = new MemoryStream())
//    {
//        var lol = SelectedItem.TemplateUri;
//        MyIE.SaveEdits().CopyTo(stream);
//        var payload = stream.ToArray();
//        mainModel.ModelList.Add(new PrintableTemplatesModel
//        {
//            TemplateRename = args.Value,
//            TemplateByte = payload,
//            TemplateUri = lol,
//        });

//        string json = JsonConvert.SerializeObject(RememberedViewModel.ModelList);

//        //CrossSettings.Current.AddOrUpdateValue("Scrambled", json, null);
//        composite["Scramble"] = json;
//    }
//}
