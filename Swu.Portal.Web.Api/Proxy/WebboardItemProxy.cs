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
        [JsonProperty(PropertyName = "fullDescription")]
        public string FullDescription { get; set; }
        [JsonProperty(PropertyName = "createBy")]
        public string CreateBy { get; set; }
        [JsonProperty(PropertyName = "createdDate")]
        public DateTime? CreatedDate { get; set; }
        [JsonProperty(PropertyName = "creatorImageUrl")]
        public string CreatorImageUrl { get; set; }
        [JsonProperty(PropertyName = "type")]
        public WebboardType Type { get; set; }
        [JsonProperty(PropertyName = "categoryId")]
        public int CategoryId { get; set; }
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "moreDetail")]
        public MoreDetailProxy MoreDetail { get; set; }

        [JsonProperty(PropertyName = "attachFiles")]
        public List<AttachFilesProxy> AttachFiles { get; set; }
        public WebboardItemProxy()
        {
            AttachFiles = new List<AttachFilesProxy>();
            MoreDetail = new MoreDetailProxy();
        }
        public WebboardItemProxy(Data.Models.Course c, string defaultImageUrl)
        {
            this.Id = c.Id;
            this.ImageUrl = c.ImageUrl;
            this.Name = c.Name_EN;
            this.ShortDescription = c.ShortDescription;
            this.CreateBy = c.ApplicationUser.FirstName_EN + " " + c.ApplicationUser.LastName_EN;
            this.Type = WebboardType.course;
            this.CategoryId = c.CategoryId;
            this.CreatorImageUrl = string.IsNullOrEmpty(c.ApplicationUser.ImageUrl) ? defaultImageUrl : c.ApplicationUser.ImageUrl;
            this.NumberOfView = 0;
            this.CreatedDate = c.CreatedDate;
            AttachFiles = new List<AttachFilesProxy>();
            MoreDetail = new MoreDetailProxy();
        }
        public WebboardItemProxy(Forum f, string defaultImageUrl)
        {
            this.Id = f.Id;
            this.ImageUrl = f.ImageUrl;
            this.Name = f.Name;
            this.ShortDescription = f.ShortDescription;
            this.FullDescription = f.FullDescription;
            this.CreateBy = f.ApplicationUser.FirstName_EN + " " + f.ApplicationUser.LastName_EN;
            this.Type = WebboardType.forum;
            this.CategoryId = f.CategoryId;
            this.CreatorImageUrl = string.IsNullOrEmpty(f.ApplicationUser.ImageUrl) ? defaultImageUrl : f.ApplicationUser.ImageUrl;
            this.NumberOfComments = f.Comments.Count();
            this.UserId = f.ApplicationUser.Id;
            this.CreatedDate = f.CreatedDate;
            AttachFiles = new List<AttachFilesProxy>();
            MoreDetail = new MoreDetailProxy();
        }
        public WebboardItemProxy(Research r, string defaultImageUrl)
        {
            this.Id = r.Id;
            this.ImageUrl = r.ImageUrl;
            this.Name = r.Name_EN;
            this.ShortDescription = r.ShortDescription;
            this.CreateBy = r.ApplicationUser.FirstName_EN + " " + r.ApplicationUser.LastName_EN;
            this.Type = WebboardType.research;
            this.CategoryId = r.CategoryId;
            this.CreatorImageUrl = string.IsNullOrEmpty(r.ApplicationUser.ImageUrl) ? defaultImageUrl : r.ApplicationUser.ImageUrl;
            this.NumberOfView = 0;
            this.UserId = r.ApplicationUser.Id;
            this.CreatedDate = r.CreatedDate;
            AttachFiles = new List<AttachFilesProxy>();
            if (r.AttachFiles.Count() > 0) {
                foreach (var f in r.AttachFiles) {
                    this.AttachFiles.Add(new AttachFilesProxy(f));
                }
            }
            MoreDetail = new MoreDetailProxy(r);
        }
    }
}
