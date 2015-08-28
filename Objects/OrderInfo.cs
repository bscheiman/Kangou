#region
using Newtonsoft.Json;

#endregion

namespace Kangou.Objects {
    public class OrderInfo {
        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("items")]
        public string Items { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
