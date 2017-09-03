using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class RoleProxy
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        public RoleProxy(IdentityRole r)
        {
            this.Id = r.Id;
            this.Name = r.Name;
        }
    }
}
