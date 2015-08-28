#region
using Newtonsoft.Json;

#endregion

namespace Kangou.Objects {
    public class Distance {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
