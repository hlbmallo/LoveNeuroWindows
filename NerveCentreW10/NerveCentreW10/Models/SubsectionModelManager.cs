using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerveCentreW10.Models
{
    public class SubsectionModelManager
    {
        private static SubsectionModelManager instance;

        public static SubsectionModelManager Instance
        {
            get
            {
                if (instance == null)
                    return new SubsectionModelManager();
                return instance;
            }
        }

        public ObservableCollection<SubsectionModel> AllSubsectionModels { get; private set; } = new ObservableCollection<SubsectionModel>();

        private SubsectionModelManager()
        {

        }

        public List<SubsectionModel> GetSubsectionModelList()
        {

            var allcarslist = new List<SubsectionModel>();

            //allcarslist.Add(new SubsectionModel(1, "Ford", "black", 1976));

            return allcarslist;
        }

        public void getAllCars()
        {
            List<SubsectionModel> allcars = GetSubsectionModelList();
            this.AllSubsectionModels.Clear();
            allcars.ForEach(item => this.AllSubsectionModels.Add(item));

        }
    }
}
