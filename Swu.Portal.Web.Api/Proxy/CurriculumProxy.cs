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
        public Enum.CurriculumType Type { get; set; }
        [JsonProperty(PropertyName = "numberOfTime")]
        public int NumberOfTime { get; set; }
        [JsonProperty(PropertyName = "time")]
        public string Time {
            get {
                return string.Format("{0} hrs.", NumberOfTime);
            }
        }
        public CurriculumProxy(Curriculum c)
        {
            this.Name = c.Name;
            this.Type = (Enum.CurriculumType)Convert.ToInt16(c.Type);
        }
    }
}
