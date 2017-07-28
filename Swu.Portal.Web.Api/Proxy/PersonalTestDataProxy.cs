using Newtonsoft.Json;

namespace Swu.Portal.Web.Api.Proxy
{
    public class PersonalTestDataProxy
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

    }
}