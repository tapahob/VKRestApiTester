using System.Collections.Generic;

namespace VKRestApiTester.REST.Models
{
    public class ResponseModel<T>
    {
        public List<T> Response { get; set; }
        public VKRestErrorModel Error { get; set; }
    }
}
