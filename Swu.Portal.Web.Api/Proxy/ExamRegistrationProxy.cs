using Newtonsoft.Json;
using Swu.Portal.Core.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class ExamRegistrationProxy
    {
        [JsonProperty(PropertyName = "examInfo")]
        public Exam ExamInfo { get; set; }
        [JsonProperty(PropertyName = "remainingTime")]
        public double RemainingTime { get; set; }
    }
}
