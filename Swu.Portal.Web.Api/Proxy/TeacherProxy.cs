using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class TeacherProxy
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "ImageUrl")]
        public string ImageUrl { get; set; }
    }
}
