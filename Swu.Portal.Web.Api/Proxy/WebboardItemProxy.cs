using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class WebboardItemProxy
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "numberOfView")]
        public int NumberOfView { get; set; }
        [JsonProperty(PropertyName = "numberOfComments")]
        public int NumberOfComments { get; set; }
        [JsonProperty(PropertyName = "shortDescription")]
        public string ShortDescription { get; set; }
        [JsonProperty(PropertyName = "createBy")]
        public string CreateBy { get; set; }
        [JsonProperty(PropertyName = "creatorImageUrl")]
        public string CreatorImageUrl { get; set; }
        [JsonProperty(PropertyName = "type")]
        public WebboardType Type { get; set; }
        [JsonProperty(PropertyName = "categoryId")]
        public int CategoryId { get; set; }
        public WebboardItemProxy(Course c)
        {
            this.Id = c.Id;
            this.ImageUrl = c.ImageUrl;
            this.Name = c.Name_EN;
            this.ShortDescription = c.ShortDescription;
            this.CreateBy = c.CreatedUser;
            this.Type = WebboardType.course;
            this.CategoryId = c.CategoryId;
            this.CreatorImageUrl = "Content/images/resource/student1.png";
        }
        public WebboardItemProxy(Forum f)
        {
            this.Id = f.Id;
            this.ImageUrl = f.ImageUrl;
            this.Name = f.Name_EN;
            this.ShortDescription = f.ShortDescription;
            this.CreateBy = f.CreatedUser;
            this.Type = WebboardType.forum;
            this.CategoryId = f.CategoryId;
            this.CreatorImageUrl = "Content/images/resource/student1.png";
        }
    }
}
