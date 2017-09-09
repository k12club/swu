using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using Swu.Portal.Web.Api.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class CurriculumProxy
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }
        [JsonProperty(PropertyName = "numberOfTime")]
        public int NumberOfTime { get; set; }
        [JsonProperty(PropertyName = "courseId")]
        public string CourseId { get; set; }
    }
}
