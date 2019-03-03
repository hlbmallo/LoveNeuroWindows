using Microsoft.Toolkit.Uwp.Helpers;
using NerveCentreW10.Models;
using NerveCentreW10.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class FavouritesPage : Page
    {
        public FavouritesViewModel ViewModel { get; set; }
        //IReadOnlyList<StorageFile> FavouritesList;

        public FavouritesPage()
        {
            this.InitializeComponent();
            LoadAsync();
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyClickedItem = (SubsectionModel)e.ClickedItem;
            Frame.Navigate(typeof(DetailPage), MyClickedItem);
        }

        async void LoadAsync()
        {

            StorageFolder appFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("FavouritesFolder", CreationCollisionOption.OpenIfExists);
            var favouritesList = await appFolder.GetFilesAsync();
            if (favouritesList == null)
            {

            }
            else
            {
                foreach (StorageFile f in favouritesList)
                {
                    string zoo = await FileIO.ReadTextAsync(f);
                    var yell = JsonConvert.DeserializeObject<SubsectionModel>(zoo);

                    GridView1.Items.Add(yell);
                    //GridView1.ItemsSource = favouritesList;
                }
            }
        }
    }
}
