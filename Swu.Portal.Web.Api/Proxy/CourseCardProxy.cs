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
        public CourseCardProxy(Course c)
        {
            this.Course = new CourseProxy
            {
                Id = c.Id,
                ImageUrl = c.ImageUrl,
                Language = c.Language,
                Name_EN = c.Name_EN,
                Name_TH = c.Name_TH,
                Price = c.Price,
            };
            this.Teacher = new TeacherProxy
            {
                Id = c.Teachers.FirstOrDefault().Id,
                Description = c.Teachers.FirstOrDefault().Description,
                ImageUrl = c.Teachers.FirstOrDefault().ImageUrl,
                Name = c.Teachers.FirstOrDefault().Name,
                Position = c.Teachers.FirstOrDefault().Position
            };
            this.CardType = CardType.Recently;
        }
    }
}
