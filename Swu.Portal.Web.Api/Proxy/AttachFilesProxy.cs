using Newtonsoft.Json;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Web.Api.Proxy
{
    public class AttachFilesProxy
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "filePath")]
        public string FilePath { get; set; }
        public AttachFilesProxy()
        {

        }
        public AttachFilesProxy(AttachFile f)
        {
            this.Id = f.Id;
            this.FilePath = f.FilePath;
        }
    }
}
