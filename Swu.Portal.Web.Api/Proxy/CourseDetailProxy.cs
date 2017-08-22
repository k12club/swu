using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class CourseAllDetailProxy
    {
        [JsonProperty(PropertyName = "course")]
        public CourseDetailProxy CourseInfo { get; set; }
        [JsonProperty(PropertyName = "curriculums")]
        public List<CurriculumProxy> Curriculums { get; set; }
        [JsonProperty(PropertyName = "teachers")]
        public List<TeacherProxy> Teacher { get; set; }
        [JsonProperty(PropertyName = "students")]
        public List<StudentProxy> Students { get; set; }
        [JsonProperty(PropertyName = "photosAlbum")]
        public PhotoAlbumProxy PhotosAlbum { get; set; }
    }
    public class CourseBriefDetailProxy
    {
        [JsonProperty(PropertyName = "course")]
        public CourseDetailProxy CourseInfo { get; set; }
        [JsonProperty(PropertyName = "teachers")]
        public List<TeacherProxy> Teacher { get; set; }
    }
}
