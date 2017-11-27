using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class SliderProxy
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title_th")]
        public string Title_TH { get; set; }
        [JsonProperty(PropertyName = "title_en")]
        public string Title_EN { get; set; }


        [JsonProperty(PropertyName = "description_th")]
        public string Description_TH { get; set; }
        [JsonProperty(PropertyName = "description_en")]
        public string Description_EN { get; set; }

        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }
        public SliderProxy()
        {

        }
        public SliderProxy(Banner b)
        {
            this.Id = b.Id;
            this.Title_EN = b.Title_EN;
            this.Title_TH = b.Title_TH;
            this.Description_EN = b.Description_EN;
            this.Description_TH = b.Description_TH;
            this.ImageUrl = b.ImageUrl;
            this.IsActive = b.IsActive;
        }
    }
}
