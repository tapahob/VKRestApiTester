using System.Collections.Generic;
using System.Configuration;

namespace VKRestApiTester.REST.Methods
{
    public class AuthSignup : VKRestMethod
    {
        protected override string methodName => "auth.signup";
        protected override IDictionary<string, object> defaultParameters => new Dictionary<string, object>()
        {
            {"client_id", ConfigurationManager.AppSettings["app_id"]},
            {"client_secret", ConfigurationManager.AppSettings["secret_key"]},
        };
    }
}
