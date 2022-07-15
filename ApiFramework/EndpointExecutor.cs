using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace ApiFramework
{
    public class EndpointExecutor<TBody, TReturn> where TBody : new() where TReturn : new()
    {
        protected RestClient _client;
        protected RestRequest _request;
        public string Url { private set; get; }
        public RestResponse Response { private set; get; }
        public TBody RequestBody { private set; get; }

        /// <summary>
        /// With body
        /// </summary>
        public EndpointExecutor(RestClient client, string token, Method method, TBody body, string url)
        {
            _client = client;
            Url = url;
            RequestBody = body;
            _request = new RestRequest(Url, method);
            _request.AddHeader("Authorization", string.Format("bearer {0}", token));
            string jsonString = JsonConvert.SerializeObject(body, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            _request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
        }

        /// <summary>
        /// No body
        /// </summary>
        public EndpointExecutor(RestClient client, string token, Method method, string url)
        {
            _client = client;
            Url = url;
            _request = new RestRequest(Url, method);
            _request.AddHeader("Authorization", string.Format("bearer {0}", token));
        }

        public EndpointExecutor<TBody, TReturn> AddHeader(string name, string value)
        {
            _request.AddHeader(name, value);
            return this;
        }
        public EndpointExecutor<TBody, TReturn> AddQueryParameter(string name, string value)
        {
            _request.AddQueryParameter(name, value);
            return this;
        }

        public EndpointResponse<TReturn> Execute()
        {
            Response = _client.Execute(_request);
            TReturn data = new TReturn();
            try
            {
                data = JsonConvert.DeserializeObject<TReturn>(Response.Content);
            }
            catch (Exception e)
            {
            }
            return new EndpointResponse<TReturn>()
            {
                Data = data,
                Content = Response.Content,
                StatusCode = Response.StatusCode
            };
        }
        public EndpointListResponse<TReturn> ExecuteEmptyList()
        {
            Response = _client.Execute(_request);
            TReturn[] data = new TReturn[9999999];
            try
            {
                data = JsonConvert.DeserializeObject<TReturn[]>(Response.Content);
            }
            catch (Exception e)
            {
            }
            return new EndpointListResponse<TReturn>()
            {
                Data = data,
                Content = Response.Content,
                StatusCode = Response.StatusCode
            };
        }
    }

    public class EndpointResponse<TData> where TData : new()
    {
        public TData Data { get; internal set; }
        public string Content { get; internal set; }
        public HttpStatusCode StatusCode { get; internal set; }

        public static implicit operator TData(EndpointResponse<TData> value) => value.Data;
    }

    public class EndpointListResponse<TData> where TData : new()
    {
        public TData[] Data { get; internal set; }
        public string Content { get; internal set; }
        public HttpStatusCode StatusCode { get; internal set; }

        public static implicit operator TData[](EndpointListResponse<TData> value) => value.Data;
    }
}