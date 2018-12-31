using NerveCentreW10.Models;
using NerveCentreW10.Views;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Imaging;

namespace NerveCentreW10.ViewModels
{
    public class NotesViewModel
    {
        public ObservableCollection<NotesClass> NotesList { get; } = new ObservableCollection<NotesClass>();

        public NotesViewModel()
        {
            NotesList.Add(new NotesClass
            {
                NotesTitle = "Section 1.0. At The Cellular Level",
                NotesImage = new BitmapImage(new Uri("ms-appx:///Assets/Icons/IconCells.png")),
                NotesLink = typeof(Section1CellsMenu),
            });
            NotesList.Add(new NotesClass
            {
                NotesTitle = "Section 2.0. The Central Nervous System",
                NotesImage = new BitmapImage(new Uri("ms-appx:///Assets/Icons/IconCNS.png")),
                NotesLink = typeof(Section2CentralMenu),
            });
            NotesList.Add(new NotesClass
            {
                NotesTitle = "Section 3.0. The Peripheral Nervous System",
                NotesImage = new BitmapImage(new Uri("ms-appx:///Assets/Icons/IconPNS.png")),
                NotesLink = typeof(Section3PeripheralMenu),
            });
            NotesList.Add(new NotesClass
            {
                NotesTitle = "Section 4.0. Neurological Disorders",
                NotesImage = new BitmapImage(new Uri("ms-appx:///Assets/Icons/IconDisorders.png")),
                NotesLink = typeof(Section4DisordersMenu),
            });
        }
    }
}
