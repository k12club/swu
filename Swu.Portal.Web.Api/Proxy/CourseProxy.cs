using Newtonsoft.Json;
using Swu.Portal.Data.Models;
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
        public string Id { get; set; }
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
        [JsonProperty(PropertyName = "categoryId")]
        public int CategoryId { get; set; }
        [JsonProperty(PropertyName = "categoryName")]
        public string CategoryName { get; set; }

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

        [JsonProperty(PropertyName = "createdUserId")]
        public string CreatedUserId { get; set; }
        [JsonProperty(PropertyName = "createdDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty(PropertyName = "updateDate")]
        public DateTime UpdateDate { get; set; }
    }
    public class CourseDetailProxy : CourseProxy
    {
        [JsonProperty(PropertyName = "bigImageUrl")]
        public string BigImageUrl { get; set; }
        [JsonProperty(PropertyName = "shortDescription")]
        public string ShortDescription { get; set; }
        [JsonProperty(PropertyName = "fullDescription")]
        public string FullDescription { get; set; }
        public CourseDetailProxy()
        {

        }
        public CourseDetailProxy(Data.Models.Course c)
        {
            Id = c.Id;
            ImageUrl = c.ImageUrl;
            Language = c.Language;
            Name_EN = c.Name_EN;
            Name_TH = c.Name_TH;
            Price = c.Price;
            FullDescription = c.FullDescription;
            BigImageUrl = c.BigImageUrl;
            CategoryId = c.CategoryId;
            CategoryName = c.Category.Title;
        }
    }
}
