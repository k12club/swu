using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class TeacherProxy : baseUser
    {
        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        public TeacherProxy()
        {

        }
        public TeacherProxy(Teacher t)
        {
            this.Id = t.Id;
            this.Name = t.Name;
            this.ImageUrl = t.ImageUrl;
            this.Position = t.Position;
            this.Description = t.Description;
        }
    }
}
