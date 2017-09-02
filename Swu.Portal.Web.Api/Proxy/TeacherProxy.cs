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
        public TeacherProxy(ApplicationUser u)
        {
            this.Id = u.Id;
            this.Name = u.FirstName_EN + " " + u.LastName_EN;
            this.ImageUrl = u.ImageUrl;
            this.Description = u.Description;
        } 
    }
}
