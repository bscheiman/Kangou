#region
using Newtonsoft.Json;

#endregion

namespace Kangou.Objects {
    public class KangouAddress {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
