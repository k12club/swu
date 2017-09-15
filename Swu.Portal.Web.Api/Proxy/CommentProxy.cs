using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class CommentProxy
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "createdUserId")]
        public String CreatedUserId { get; set; }
        [JsonProperty(PropertyName = "creatorName")]
        public string CreatorName { get; set; }
        [JsonProperty(PropertyName = "creatorPosition")]
        public string CreatorPosition { get; set; }
        [JsonProperty(PropertyName = "createImageUrl")]
        public string CreatorImageUrl { get; set; }
        [JsonProperty(PropertyName = "createdDate")]
        public DateTime? CreatedDate { get; set; }
        public CommentProxy()
        {

        }
        public CommentProxy(Comment c)
        {
            this.Id = c.Id;
            this.Description = c.Description;
            this.CreatorName = c.ApplicationUser.FirstName_EN + " " + c.ApplicationUser.LastName_EN;
            this.CreatorImageUrl = c.ApplicationUser.ImageUrl;
            this.CreatedDate = c.CreatedDate;
            this.CreatedUserId = c.ApplicationUser.Id;
        }
    }
}
