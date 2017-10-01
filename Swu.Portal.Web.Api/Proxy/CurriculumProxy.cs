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
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }
        [JsonProperty(PropertyName = "numberOfTime")]
        public int NumberOfTime { get; set; }
        [JsonProperty(PropertyName = "courseId")]
        public string CourseId { get; set; }
        [JsonProperty(PropertyName = "studentScores")]
        public List<StudentScoreProxy> StudentScores { get; set; }
        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty(PropertyName = "room")]
        public string RoomDescription { get; set; }
        [JsonProperty(PropertyName = "curriculumDocuments")]
        public List<AttachFilesProxy> CurriculumDocuments { get; set; }
        [JsonProperty(PropertyName = "surveyLink")]
        public string SurveyLink { get; set; }

        public CurriculumProxy()
        {
            StudentScores = new List<StudentScoreProxy>();
        }
        public CurriculumProxy(Curriculum c)
        {
            this.Id = c.Id;
            this.Name = c.Name;
            this.Type = (int)c.Type;
            this.NumberOfTime = c.NumberOfTime;
            this.CourseId = c.CourseId;
            this.StartDate = c.StartDate;
            this.RoomDescription = c.RoomDescription;
            this.SurveyLink = c.SurveyLink;
            this.CurriculumDocuments = new List<AttachFilesProxy>();
            if (c.CurriculumDocuments.Count > 0) {
                foreach (var f in c.CurriculumDocuments) {
                    this.CurriculumDocuments.Add(new AttachFilesProxy(f));
                }
            }
            StudentScores = new List<StudentScoreProxy>();

        }
    }
}
