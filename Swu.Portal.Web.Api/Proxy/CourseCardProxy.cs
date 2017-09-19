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
    public class CourseCardProxy
    {
        [JsonProperty(PropertyName = "course")]
        public CourseProxy Course { get; set; }
        [JsonProperty(PropertyName = "teacher")]
        public TeacherProxy Teacher { get; set; }
        [JsonProperty(PropertyName = "cardType")]
        public CardType CardType { get; set; }
        public CourseCardProxy()
        {

        }
        public CourseCardProxy(Data.Models.Course c)
        {
            this.Course = new CourseProxy
            {
                Id = c.Id,
                ImageUrl = c.ImageUrl,
                Language = c.Language,
                Name_EN = c.Name_EN,
                Name_TH = c.Name_TH,
                Price = c.Price,
                NumberOfStudents = c.Students.Count(),
                NumberOfTimes  = c.Curriculums.Sum(i=>i.NumberOfTime),
                NumberOfViews = c.NumberOfViews,
                CreatedDate = c.CreatedDate
            };
            this.Teacher = new TeacherProxy(c.Teachers.FirstOrDefault());
        }
    }
}
