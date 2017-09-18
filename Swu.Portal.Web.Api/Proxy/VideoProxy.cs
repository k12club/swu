using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class VideoProxy : IMultimedia
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "videoUrl")]
        public string VideoUrl { get; set; }
        [JsonProperty(PropertyName = "title_en")]
        public string Title_EN { get; set; }
        [JsonProperty(PropertyName = "title_th")]
        public string Title_TH { get; set; }
        public VideoProxy()
        {

        }
        public VideoProxy(Video video)
        {
            this.Id = video.Id;
            this.ImageUrl = video.ImageUrl;
            this.VideoUrl = video.VideoUrl;
            this.Title_EN = video.Title_EN;
            this.Title_TH = video.Title_TH;
        }
    }
}
