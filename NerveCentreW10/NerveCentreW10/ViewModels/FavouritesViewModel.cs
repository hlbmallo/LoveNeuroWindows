using HeartCentreW104.Helpers;
using Microsoft.Azure.Storage.Blob;
using NerveCentreW10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerveCentreW10.ViewModels
{
    public class FavouritesViewModel
    {
        public static ObservableCollection<SubsectionModel> FavouritesList { get; set; } = new ObservableCollection<SubsectionModel>();

        public FavouritesViewModel()
        {

        }
    }
}
