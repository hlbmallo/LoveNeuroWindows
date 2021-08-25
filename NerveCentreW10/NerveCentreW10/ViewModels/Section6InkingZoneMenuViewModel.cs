using NerveCentreW10.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerveCentreW10.ViewModels
{
    class Section6InkingZoneMenuViewModel : BaseViewModel
    {
        //public ObservableCollection<SubsectionModel> SubsectionList { get; } = new ObservableCollection<SubsectionModel>();
        public RelayCommand DeleteCommand { get; set; }

        public Section6InkingZoneMenuViewModel()
        {
            DeleteCommand = new RelayCommand(DeleteEvent);
        }

        private void DeleteEvent()
        {
            throw new NotImplementedException();
        }
    }
}
