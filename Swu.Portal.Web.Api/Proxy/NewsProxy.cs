using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class NewsProxy
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "title_th")]
        public string Title_TH { get; set; }
        [JsonProperty(PropertyName = "title_en")]
        public string Title_EN { get; set; }
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }
        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "description_th")]
        public string Description_TH { get; set; }
        [JsonProperty(PropertyName = "description_en")]
        public string Description_EN { get; set; }
        public NewsProxy()
        {

        }
        public NewsProxy(News news)
        {
            this.Id = news.Id;
            this.Title_EN = news.Title_EN;
            this.Title_TH = news.Title_TH;
            this.ImageUrl = news.ImageUrl;
            this.StartDate = news.StartDate;
            this.Description_EN = news.FullDescription_EN;
            this.Description_TH = news.FullDescription_TH;
            //this.CreatedBy = news.ApplicationUser.FirstName_EN + " " + news.ApplicationUser.LastName_EN;
        }
    }
}
