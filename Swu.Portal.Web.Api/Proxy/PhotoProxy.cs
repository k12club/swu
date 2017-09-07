using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class PhotoProxy : IMultimedia
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "publishedDate")]
        public DateTime PublishedDate { get; set; }
        [JsonProperty(PropertyName = "uploadBy")]
        public string UploadBy { get; set; }
        public PhotoProxy(Photo p)
        {
            this.Id = p.Id;
            this.Name = p.Name;
            this.ImageUrl = p.ImageUrl;
            this.PublishedDate = p.PublishedDate;
            this.UploadBy = p.UploadBy;
        }
        
    }
    public class PhotoAlbumProxy {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "photos")]
        public List<PhotoProxy> Photos { get; set; }
        public PhotoAlbumProxy()
        {
            this.Photos = new List<PhotoProxy>();
        }
        public PhotoAlbumProxy(PhotoAlbum album)
        {
            this.Id = album.Id;
            this.Photos = new List<PhotoProxy>();
        }
    }
}
