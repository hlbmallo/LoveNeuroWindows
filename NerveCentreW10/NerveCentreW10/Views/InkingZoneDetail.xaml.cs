using Microsoft.AppCenter.Analytics;
using Microsoft.Graphics.Canvas;
using Microsoft.Toolkit.Uwp.Helpers;
using NerveCentreW10.Models;
using NerveCentreW10.Services.Ink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Input.Inking;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NerveCentreW10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InkingZoneDetail : Page
    {
        private PrintHelper printHelper;
        private InkPointerDeviceService pointerDeviceService;
        private InkZoomService zoomService;

        public InkingZoneDetail()
        {
            InitializeComponent();
            SetCanvasSize();
            MyImage.SizeChanged += Image_SizeChanged;
            zoomService = new InkZoomService(canvasScroll);
            pointerDeviceService = new InkPointerDeviceService(MyInkCanvas);
            touchInkingButton.IsChecked = true;
            mouseInkingButton.IsChecked = true;
            Analytics.TrackEvent(this.GetType().Name);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Analytics.TrackEvent(this.GetType().Name);
            var MyClickedItem = (InkingZoneClass)e.Parameter;
            Title.Text = MyClickedItem.InkingZoneTitle;
            MyImage.Source = new BitmapImage(MyClickedItem.InkingZoneImage);
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Analytics.TrackEvent("SaveInkedDiagramButton_Click");

            // grab output file
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            savePicker.FileTypeChoices.Add("Jpeg (*.jpg)", new List<string>() { ".jpg" });
            savePicker.SuggestedFileName = "Heart Centre Diagram";
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
            var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(((BitmapImage)MyImage.Source).UriSource);
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
            await printHelper.ShowPrintUIAsync("Heart Centre Print");
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

        private void image_Loaded(object sender, RoutedEventArgs e)
        {
            zoomService?.FitToSize(MyImage.ActualWidth, MyImage.ActualHeight);
        }

        private void TouchInking_Checked(object sender, RoutedEventArgs e) => pointerDeviceService.EnableTouch = true;

        private void TouchInking_Unchecked(object sender, RoutedEventArgs e) => pointerDeviceService.EnableTouch = false;

        private void MouseInking_Checked(object sender, RoutedEventArgs e) => pointerDeviceService.EnableMouse = true;

        private void MouseInking_Unchecked(object sender, RoutedEventArgs e) => pointerDeviceService.EnableMouse = false;
    }
}
