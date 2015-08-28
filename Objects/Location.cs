#region
using Newtonsoft.Json;

#endregion

namespace Kangou.Objects {
    public class Location {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lng")]
        public double Longitude { get; set; }

        internal Location() {
        }
    }
}
