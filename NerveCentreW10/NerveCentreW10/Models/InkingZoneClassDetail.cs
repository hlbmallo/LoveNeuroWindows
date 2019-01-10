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
        [JsonProperty("InkingZoneTitle")]
        public string InkingZoneTitle { get; set; }

        [JsonProperty("InkingZoneImage")]
        public Uri InkingZoneImage { get; set; }

        [JsonProperty("InkingZoneDescription")]
        public string InkingZoneDescription { get; set; }

        [JsonProperty("InkingZoneRename")]
        public string InkingZoneRename { get; set; }

        [JsonProperty("InkingZoneBytes")]
        public byte[] InkingZoneBytes { get; set; }


    }


    //public class InkingZoneClassCollection
    //{
    //    [JsonProperty("ModelList")]
    //    public ObservableCollection<InkingZoneClassDetail> ModelList { get; set; }
    //}
}
