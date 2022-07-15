using ApiFramework.DataTransferObjects;
using RestSharp;
using System.Linq;
using Util;

namespace ApiFramework.Controllers
{
    public class ApiController : BaseController
    {
        public ApiController(RestClient client, string token) : base(client, token) { }

        public EnergyInfo GetEnergy(EnergyType energyType)
        {
            var getEnergy = GetEnergyDetails().Execute().Data;
            switch (energyType)
            {
                case EnergyType.Electric:
                return getEnergy.Electric;
                case EnergyType.Gas:
                return getEnergy.Gas;
                case EnergyType.Nuclear:
                return getEnergy.Nuclear;
                case EnergyType.Oil:
                return getEnergy.Oil;
            }
            return null;
        }

        public GetEnergyResponse GetEnergy() => GetEnergyDetails().Execute().Data;
        private EndpointExecutor<object, GetEnergyResponse> GetEnergyDetails() => NewEndpoint<GetEnergyResponse>(Method.Get, "/energy");

        public Order GetOrder(string id) => GetOrdersDetails().ExecuteEmptyList().Data.FirstOrDefault(a => a.Id.Equals(id));
        public Order[] GetOrders() => GetOrdersDetails().ExecuteEmptyList();
        private EndpointExecutor<object, Order> GetOrdersDetails() => NewEndpoint<Order>(Method.Get, "/orders");

        public BuyEnergyResponse Buy(EnergyType energy, int quantity)
        {
            var data = BuyEnergy(energy, quantity).Execute().Data;
            var index = data.Message.IndexOf("id is");
            if (index > 0)
            {
                data.OrderId = data.Message.Substring(index + 6, 36);
                data.Success = true;
            }
            else data.Success = false;
            
            return data;
        }

        private EndpointExecutor<object, BuyEnergyResponse> BuyEnergy(EnergyType energyType, int quantity) => NewEndpoint<BuyEnergyResponse>(Method.Put, $"/buy/{GetEnergy(energyType).EnergyId}/{quantity}");
    }
}
