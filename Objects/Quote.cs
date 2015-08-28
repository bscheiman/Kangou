#region
using System;
using Newtonsoft.Json;

#endregion

namespace Kangou.Objects {
    public class Quote {
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("distance")]
        public Distance Distance { get; set; }

        [JsonProperty("drop_off")]
        public KangouAddress DropOff { get; set; }

        [JsonProperty("dropoff_eta")]
        public DateTime DropoffEta { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("expires")]
        public DateTime Expires { get; set; }

        [JsonProperty("fee")]
        public int Fee { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_used")]
        public bool IsUsed { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("pick_up")]
        public KangouAddress PickUp { get; set; }

        internal Quote() {
        }
    }
}
