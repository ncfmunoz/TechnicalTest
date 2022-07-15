using ApiFramework.Controllers;
using NUnit.Framework;
using RestSharp;
using Util;

namespace ApiFramework
{
    public class Client
    {
        private RestClient client;
        internal SystemDto system;
        internal string token;

        public Client(SystemDto system)
        {
            this.system = system;
            client = new RestClient(system.ApiUrl);
            token = system.Token;
        }

        public ApiController ApiController => new ApiController(client, token);
    }
}