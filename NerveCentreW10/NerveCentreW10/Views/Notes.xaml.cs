using NerveCentreW10.Models;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
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
        private ObservableCollection<NotesClass> NotesList = new ObservableCollection<NotesClass>();

        public Notes()
        {
            this.InitializeComponent();
            NotesData();
        }

        private void NotesData()
        {
            NotesList.Add(new NotesClass
            {
                NotesTitle = "Section 1.0. At The Cellular Level",
                NotesImage = new BitmapImage(new Uri("ms-appx:///Assets/Logo.png")),
                NotesLink = typeof(Section1CellsMenu),
            });
            NotesList.Add(new NotesClass
            {
                NotesTitle = "Section 2.0. The Central Nervous System",
                NotesImage = new BitmapImage(new Uri("ms-appx:///Assets/Logo.png")),
                NotesLink = typeof(Section2CentralMenu),
            });
            NotesList.Add(new NotesClass
            {
                NotesTitle = "Section 3.0. The Peripheral Nervous System",
                NotesImage = new BitmapImage(new Uri("ms-appx:///Assets/Logo.png")),
                NotesLink = typeof(Section3PeripheralMenu),
            });
            NotesList.Add(new NotesClass
            {
                NotesTitle = "Section 4.0. Neurological Disorders",
                NotesImage = new BitmapImage(new Uri("ms-appx:///Assets/Logo.png")),
                NotesLink = typeof(Section4DisordersMenu),
            });

            GridView1.ItemsSource = NotesList;
        }

        private void GridView1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var MyClickedItem = ((NotesClass)e.ClickedItem as NotesClass).NotesLink;
            Frame.Navigate(MyClickedItem, null, new DrillInNavigationTransitionInfo());
        }
    }
}
