using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class MoreDetailProxy
    {
        [JsonProperty(PropertyName = "creatorName")]
        public string CreatorName { get; set; }
        [JsonProperty(PropertyName = "publisher")]
        public string Publisher { get; set; }
        [JsonProperty(PropertyName = "contributor")]
        public string Contributor { get; set; }
        [JsonProperty(PropertyName = "publishDate")]
        public DateTime PublishDate { get; set; }
        public MoreDetailProxy()
        {

        }
        public MoreDetailProxy(Research r)
        {
            this.CreatorName = r.CreatorName;
            this.Publisher = r.Publisher;
            this.Contributor = r.Contributor;
            this.PublishDate = r.PublishDate;
        }
    }
}
