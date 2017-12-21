using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using VKRestApiTester.REST.Models;

namespace VKRestApiTester.REST
{
    public abstract class VKRestMethod
    {
        protected abstract string methodName { get; }
        protected virtual IDictionary<string, object> defaultParameters => new Dictionary<string, object>();
        private const string SERVICE_URL = "https://api.vk.com/method";

        public T Execute<T>(IDictionary<string, object> parameters) where T: VKRestErrorModel, new()
        {
            var restClient = new RestClient(SERVICE_URL);
            var request = new RestRequest(methodName, Method.GET);
            foreach (var parameter in parameters)
            {                
                request.AddParameter(parameter.Key, parameter.Value);
            }
            
            foreach (var defaultParameter in defaultParameters)
            {
                if (parameters.Keys.All(x => !string.Equals(x, defaultParameter.Key, StringComparison.CurrentCultureIgnoreCase)))
                {
                    request.AddParameter(defaultParameter.Key, defaultParameter.Value);
                }
            }

            var data = restClient.Execute<ResponseModel<T>>(request).Data;
            return data.Response is null 
                ? new T(){ErrorMSG = data.Error.ErrorMSG, ErrorCode = data.Error.ErrorCode}
                : data.Response.FirstOrDefault();
        }
    }
}