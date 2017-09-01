using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class ForumDetailProxy
    {
        [JsonProperty(PropertyName = "forum")]
        public ForumProxy Forum { get; set; }
        [JsonProperty(PropertyName = "comments")]
        public List<CommentProxy> Comments { get; set; }
    }
}
