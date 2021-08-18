using LoveNeuroWinUI3.Helpers;
using LoveNeuroWinUI3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveNeuroWinUI3.ViewModels
{
    public class FavouritesViewModel
    {
        public static ObservableCollection<SubsectionModel> FavouritesList { get; set; } = new ObservableCollection<SubsectionModel>();

        public FavouritesViewModel()
        {

        }
    }
}
