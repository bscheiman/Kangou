#region
using Newtonsoft.Json;

#endregion

namespace Kangou.Objects {
    public class Order {
        [JsonProperty("delivery_id")]
        public string DeliveryId { get; set; }

        internal Order() {
        }
    }
}
