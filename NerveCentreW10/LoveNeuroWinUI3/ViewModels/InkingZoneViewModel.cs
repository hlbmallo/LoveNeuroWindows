using LoveNeuroWinUI3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveNeuroWinUI3.ViewModels
{
    public class InkingZoneViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<InkingZoneClassDetail> ModelList { get; set; }

        public InkingZoneViewModel()
        {
            ModelList = new ObservableCollection<InkingZoneClassDetail>
            {

            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
