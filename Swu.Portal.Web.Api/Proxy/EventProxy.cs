using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class EventProxy
    {
        [JsonProperty(PropertyName = "title_en")]
        public string Title_EN { get; set; }
        [JsonProperty(PropertyName = "description_en")]
        public string Description_EN { get; set; }
        [JsonProperty(PropertyName = "place_en")]
        public string Place_EN { get; set; }
        [JsonProperty(PropertyName = "title_th")]
        public string Title_TH { get; set; }
        [JsonProperty(PropertyName = "description_th")]
        public string Description_TH { get; set; }
        [JsonProperty(PropertyName = "place_th")]
        public string Place_TH { get; set; }
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty(PropertyName = "endDate")]
        public DateTime EndDate { get; set; }
        public EventProxy()
        {

        }
        public EventProxy(Event e)
        {
            this.Title_EN = e.Title_EN;
            this.Title_TH = e.Title_TH;
            this.Description_EN = e.Description_EN;
            this.Description_TH = e.Description_TH;
            this.Place_EN = e.Place_EN;
            this.Place_TH = e.Place_TH;
            this.ImageUrl = e.ImageUrl;
            this.StartDate = e.StartDate;
            this.EndDate = e.EndDate;
        }
    }
}
