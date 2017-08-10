using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class CourseProxy
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "ImageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "NumberOfRegistered")]
        public int NumberOfRegistered { get; set; }
        [JsonProperty(PropertyName = "NumberOfComments")]
        public int NumberOfComments { get; set; }
        [JsonProperty(PropertyName = "Price")]
        public decimal Price { get; set; }
    }
}
