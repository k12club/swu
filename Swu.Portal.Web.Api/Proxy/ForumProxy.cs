using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class ForumProxy
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "shortDescription")]
        public string ShortDescription { get; set; }
        [JsonProperty(PropertyName = "fullDescription")]
        public string FullDescription { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }
        [JsonProperty(PropertyName = "numberOfViews")]
        public int NumberOfViews { get; set; }
    }
}
