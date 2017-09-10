using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class StudentScoreProxy : StudentProxy
    {
        [JsonProperty(PropertyName = "activated")]
        public bool Activated { get; set; }
        [JsonProperty(PropertyName = "score")]
        public double Score { get; set; }
        public StudentScoreProxy()
        {

        }
        public StudentScoreProxy(StudentScore sc)
        {
            this.Id = sc.Id.ToString();
            this.Name = sc.Student.FirstName_EN + " " + sc.Student.LastName_EN;
            this.ImageUrl = sc.Student.ImageUrl;
            this.StudentId = sc.Student.StudentId;
            this.Activated = sc.Activated;
            this.Score = sc.Score;
        }
    }
}
