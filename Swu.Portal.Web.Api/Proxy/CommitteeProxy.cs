using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class CommitteeProxy
    {
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "name_th")]
        public string Name_TH { get; set; }
        [JsonProperty(PropertyName = "position_th")]
        public string Position_TH { get; set; }
        [JsonProperty(PropertyName = "description_th")]
        public string Description_TH { get; set; }

        [JsonProperty(PropertyName = "name_en")]
        public string Name_EN { get; set; }
        [JsonProperty(PropertyName = "position_en")]
        public string Position_EN { get; set; }
        [JsonProperty(PropertyName = "description_en")]
        public string Description_EN { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
        [JsonProperty(PropertyName = "room")]
        public string Room { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "facebook")]
        public string Facebook { get; set; }
        [JsonProperty(PropertyName = "twitter")]
        public string Twitter { get; set; }
    }
}
