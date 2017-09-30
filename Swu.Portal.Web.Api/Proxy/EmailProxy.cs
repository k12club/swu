using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class EmailProxy
    {
        [JsonProperty(PropertyName = "name")]
        public string Sender { get; set; }
        [JsonProperty(PropertyName = "emailFrom")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
