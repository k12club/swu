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
        [JsonProperty(PropertyName = "scoreId")]
        public int ScoreId { get; set; }
        [JsonProperty(PropertyName = "score")]
        public double Score { get; set; }
        [JsonProperty(PropertyName = "curriculumId")]
        public double CurriculumId { get; set; }
        public StudentScoreProxy()
        {

        }
        public StudentScoreProxy(StudentScore sc)
        {
            this.ScoreId = sc.Id;
            this.Name = sc.Student.FirstName_EN + " " + sc.Student.LastName_EN;
            this.ImageUrl = sc.Student.ImageUrl;
            this.StudentId = sc.Student.StudentId;
            this.Score = sc.Score;
            this.CurriculumId = sc.CurriculumId;
        }
    }
}
