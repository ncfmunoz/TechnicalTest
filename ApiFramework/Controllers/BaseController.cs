using RestSharp;

namespace ApiFramework.Controllers
{
    public class BaseController
    {
        protected RestClient client;
        protected string token;
        protected BaseController(RestClient client, string token)
        {
            this.client = client;
            this.token = token;
        }

        protected EndpointExecutor<TBody, TReturn> NewEndpoint<TBody, TReturn>(Method method, TBody body, string url) where TBody : new() where TReturn : new() => new EndpointExecutor<TBody, TReturn>(client, token, method, body, url);
        protected EndpointExecutor<object, TReturn> NewEndpoint<TReturn>(Method method, string url) where TReturn : new() => new EndpointExecutor<object, TReturn>(client, token, method, url);
    }
}
