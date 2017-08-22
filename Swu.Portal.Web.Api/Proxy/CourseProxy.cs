using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class CourseProxy
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name_th")]
        public string Name_TH { get; set; }
        [JsonProperty(PropertyName = "name_en")]
        public string Name_EN { get; set; }
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "numberOfRegistered")]
        public int NumberOfRegistered { get; set; }
        [JsonProperty(PropertyName = "numberOfComments")]
        public int NumberOfComments { get; set; }
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "numberOfLectures")]
        public int NumberOfLecture { get; set; }
        [JsonProperty(PropertyName = "numberOfQuizes")]
        public int NumberOfQuizes { get; set; }
        [JsonProperty(PropertyName = "numberOfTimes")]
        public int NumberOfTimes { get; set; }
        [JsonProperty(PropertyName = "numberOfStudents")]
        public int NumberOfStudents { get; set; }
        [JsonProperty(PropertyName = "numberOfTeachers")]
        public int NumberOfTeachers { get; set; }
        [JsonProperty(PropertyName = "lang")]
        public string Language { get; set; }

    }
    public class CourseDetailProxy :CourseProxy
    {
        [JsonProperty(PropertyName = "bigImageUrl")]
        public string BigImageUrl { get; set; }
        [JsonProperty(PropertyName = "shortDescription")]
        public string ShortDescription { get; set; }
        [JsonProperty(PropertyName = "fullDescription")]
        public string FullDescription { get; set; }
    }
}
