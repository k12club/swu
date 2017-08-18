using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class NewsProxy
    {
        [JsonProperty(PropertyName = "title_th")]
        public string Title_TH { get; set; }
        [JsonProperty(PropertyName = "title_en")]
        public string Title_EN { get; set; }
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }
        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }
    }
}
