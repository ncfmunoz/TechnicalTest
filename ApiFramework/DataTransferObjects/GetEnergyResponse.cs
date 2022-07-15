using Newtonsoft.Json;

namespace ApiFramework.DataTransferObjects
{
    public class GetEnergyResponse
    {
        [JsonProperty("electric")]
        public EnergyInfo Electric { get; set; }
        [JsonProperty("gas")]
        public EnergyInfo Gas { get; set; }
        [JsonProperty("nuclear")]
        public EnergyInfo Nuclear { get; set; }
        [JsonProperty("oil")]
        public EnergyInfo Oil { get; set; }
    }

    public class EnergyInfo
    {
        [JsonProperty("energy_id")]
        public int EnergyId { get; set; }
        [JsonProperty("price_per_unit")]
        public double PricePerUnit { get; set; }
        [JsonProperty("quantity_of_units")]
        public int Quantity { get; set; }
        [JsonProperty("unit_type")]
        public string UnitType { get; set; }
    }
}
