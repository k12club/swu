using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class AlumniProxy
    {
        [JsonProperty(PropertyName = "studentId")]
        public string StudentId { get; set; }
        [JsonProperty(PropertyName = "fullName_th")]
        public string FullName_TH { get; set; }
        [JsonProperty(PropertyName = "fullName_en")]
        public string FullName_EN { get; set; }
        [JsonProperty(PropertyName = "graduatedYear")]
        public string GraduatedYear { get; set; }
        public AlumniProxy()
        {

        }
    }
}
