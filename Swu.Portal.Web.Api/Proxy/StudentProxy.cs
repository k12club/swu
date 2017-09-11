using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class StudentProxy :baseUser
    {
        [JsonProperty(PropertyName = "studentId")]
        public string StudentId { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "activated")]
        public bool Activated { get; set; }
        public StudentProxy()
        {

        }
        public StudentProxy(StudentCourse s) {
            this.Id = s.Student.Id;
            this.Name = s.Student.FirstName_EN + " " + s.Student.LastName_EN;
            this.ImageUrl = s.Student.ImageUrl;
            this.StudentId = s.Student.StudentId;
            this.Activated = s.Activated;
        }
        public StudentProxy(ApplicationUser s)
        {
            this.Id = s.Id.ToString();
            this.Name = s.FirstName_EN + " " + s.LastName_EN;
            this.ImageUrl = s.ImageUrl;
            this.StudentId = s.StudentId;
        }
    }
}
