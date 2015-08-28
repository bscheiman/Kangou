#region
using System;
using Newtonsoft.Json;

#endregion

namespace Kangou.Objects {
    public class Courier {
        [JsonProperty("distance")]
        public int Distance { get; set; }

        [JsonProperty("last_time_active")]
        public DateTime LastTimeActive { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
