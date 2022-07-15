using Newtonsoft.Json;

namespace ApiFramework.DataTransferObjects
{
    public class BuyEnergyResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        public string OrderId { get; set; }
        public bool Success { get; set; }
    }
}
