using VKRestApiTester.REST.Models;

namespace VKRestApiTester
{
    public class UsersGetModel : VKRestErrorModel
    {        
        public long UID { get; set; }                
        public string FirstName { get; set; }        
        public string LastName { get; set; }
    }
}
