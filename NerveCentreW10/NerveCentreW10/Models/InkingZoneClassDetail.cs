using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Input.Inking;

namespace NerveCentreW10.Models
{
    public class InkingZoneClassDetail
    {
        [JsonProperty("InkingZoneId")]
        public string InkingZoneId { get; set; }

        [JsonProperty("InkingZoneTitle")]
        public string InkingZoneTitle { get; set; }

        [JsonProperty("InkingZoneDate")]
        public DateTime InkingZoneDate { get; set; }

        [JsonProperty("InkingZoneEdits")]
        public string InkingZoneEdits { get; set; }

        [JsonProperty("InkingZoneImageName")]
        public string InkingZoneImageName { get; set; }
    }


    //public class InkingZoneClassCollection
    //{
    //    [JsonProperty("ModelList")]
    //    public ObservableCollection<InkingZoneClassDetail> ModelList { get; set; }
    //}
}
