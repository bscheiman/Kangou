#region
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kangou.Objects;

#endregion

namespace Kangou {
    public class KangouLib {
        private static readonly Uri BaseAddress = new Uri("https://api.kangou.mx/");
        public string ApiKey { get; set; }
        public string CustomerId { get; set; }

        public KangouLib(string customerId, string apiKey) {
            if (string.IsNullOrEmpty(customerId))
                throw new ArgumentNullException(nameof(customerId));

            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException(nameof(apiKey));

            CustomerId = customerId;
            ApiKey = apiKey;
        }

        public Task<OrderInfo> CancelOrder(Order order) {
            return CancelOrder(order.DeliveryId);
        }

        public Task<OrderInfo> CancelOrder(OrderInfo order) {
            return CancelOrder(order.Id);
        }
        
        public Task<Courier[]> GetCouriers(double latitude, double longitude) {
            return Post<Courier[]>($"v1/customers/{CustomerId}/couriers", new {
                lat = latitude,
                lng = longitude
            });
        }

        public Task<OrderInfo> CancelOrder(string deliveryId) {
            deliveryId = deliveryId?.Replace("test_", "");

            return Post<OrderInfo>($"v1/customers/{CustomerId}/deliveries/{deliveryId}/cancel");
        }

        public Task<Order> CreateOrder(Quote quote, string manifest, string pickupName, string pickupReference, string dropoffName,
                                           string dropoffPhone, string dropoffReference) {
            return Post<Order>($"v1/customers/{CustomerId}/deliveries", new {
                manifest,
                pickup_name = pickupName,
                pickup_references = pickupReference,
                dropoff_name = dropoffName,
                dropoff_phone_number = dropoffPhone,
                dropoff_references = dropoffReference,
                quote_id = quote.Id
            });
        }

        public Task<OrderInfo> GetOrderInfo(Order order) {
            return GetOrderInfo(order.DeliveryId);
        }

        public Task<OrderInfo> GetOrderInfo(string deliveryId) {
            deliveryId = deliveryId?.Replace("test_", "");

            return Get<OrderInfo>($"v1/customers/{CustomerId}/deliveries/{deliveryId}");
        }

        public Task<OrderInfo[]> GetOrders() {
            return Get<OrderInfo[]>($"v1/customers/{CustomerId}/deliveries");
        }

        public Task<Quote> GetQuote(string pickupAddress, string dropoffAddress) {
            return Post<Quote>($"v1/customers/{CustomerId}/delivery_quote", new {
                pickup_address = pickupAddress,
                dropoff_address = dropoffAddress
            });
        }

        #region Helpers
        internal async Task<TReturn> Post<TReturn>(string address, object obj = null) {
            using (var httpClient = new HttpClient()) {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{ApiKey}:")));
                HttpContent content = new StringContent("");

                if (obj != null) {
                    var type = obj.GetType();
                    var properties = type.GetRuntimeProperties();
                    var nvc = properties.Select(p => new KeyValuePair<string, string>(p.Name, p.GetValue(obj).ToString())).ToList();
                    content = new FormUrlEncodedContent(nvc);
                }

                var message = await httpClient.PostAsync(BaseAddress + address, content);

                return (await message.Content.ReadAsStringAsync()).FromJson<TReturn>();
            }
        }

        internal async Task<TReturn> Get<TReturn>(string address) {
            using (var httpClient = new HttpClient()) {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{ApiKey}:")));
                var message = await httpClient.GetAsync(BaseAddress + address);

                return (await message.Content.ReadAsStringAsync()).FromJson<TReturn>();
            }
        }
        #endregion
    }
}
