using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiFramework.DataTransferObjects
{
    public class Order
    {
        [JsonProperty("fuel")]
        public string EnergyId { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("time")]
        public DateTime Time { get; set; }
    }
}
