using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class WebboardCategoryProxy
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        public WebboardCategoryProxy(CourseCategory c)
        {
            this.Id = c.Id;
            this.Title = c.Title;
        }
        public WebboardCategoryProxy(ForumCategory f)
        {
            this.Id = f.Id;
            this.Title = f.Title;
        }
    }
}
