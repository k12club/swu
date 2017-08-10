using Newtonsoft.Json;
using Swu.Portal.Web.Api.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class CourseCardProxy
    {
        [JsonProperty(PropertyName = "course")]
        public CourseProxy Course { get; set; }
        [JsonProperty(PropertyName = "teacher")]
        public TeacherProxy Teacher { get; set; }
        [JsonProperty(PropertyName = "cardType")]
        public CardType CardType { get; set; }
    }
}
