using Newtonsoft.Json;
using System;

namespace LoveNeuroWinUI3.Models
{
    public class InkingZoneClassDetail
    {
        [JsonProperty("InkingZoneId")]
        public string InkingZoneId { get; set; }

        [JsonProperty("InkingZoneTitle")]
        public string InkingZoneTitle { get; set; }

        [JsonProperty("InkingZoneImage")]
        public string InkingZoneImage { get; set; }

        [JsonProperty("InkingZoneDescription")]
        public string InkingZoneDescription { get; set; }

        [JsonProperty("InkingZoneRename")]
        public string InkingZoneRename { get; set; }

        [JsonProperty("InkingZoneBytes")]
        public byte[] InkingZoneBytes { get; set; }

        [JsonProperty("InkingZoneDate")]
        public DateTime InkingZoneDate { get; set; }

        [JsonProperty("InkingZoneEdits")]
        public string InkingZoneEdits { get; set; }

        [JsonProperty("InkingZoneImageUrl")]
        public string InkingZoneImageName { get; set; }
    }
}
