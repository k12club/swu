using Newtonsoft.Json;
using Swu.Portal.Core.Dependencies;
using Swu.Portal.Data.Models;
using Swu.Portal.Data.Repository;
using Swu.Portal.Service;
using Swu.Portal.Web.Api;
using Swu.Portal.Web.Api.Proxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Swu.Portal.Web.Api
{
    [RoutePrefix("V1/video")]
    public class VideoController : ApiController
    {
        private const string UPLOAD_DIR = "FileUpload/video/";
        private readonly IDateTimeRepository _datetimeRepository;
        private readonly IRepository<Video> _videoRepository;
        public VideoController(IDateTimeRepository datetimeRepository, IRepository<Video> videoRepository)
        {
            this._datetimeRepository = datetimeRepository;
            this._videoRepository = videoRepository;
        }
        [HttpGet, Route("all")]
        public List<VideoProxy> GetAll()
        {
            return this._videoRepository.List.Select(i => new VideoProxy(i)).ToList();
        }
        [HttpGet, Route("getById")]
        public VideoProxy GetById(int id)
        {
            return new VideoProxy(this._videoRepository.FindById(id));
        }
        [HttpPost, Route("addNewOrUpdate")]
        public async Task<HttpResponseMessage> PostFormData()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            var hasFile = false;
            var GuID = Guid.NewGuid().ToString();
            string root = HttpContext.Current.Server.MapPath("~/" + UPLOAD_DIR);
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                VideoProxy video = new VideoProxy();
                foreach (var key in provider.FormData)
                {
                    if (key.Equals("video"))
                    {
                        var json = provider.FormData[key.ToString()];
                        video = JsonConvert.DeserializeObject<VideoProxy>(json);
                    }
                }
                string path = string.Empty;
                foreach (MultipartFileData file in provider.FileData)
                {
                    hasFile = true;
                    string fileName = file.Headers.ContentDisposition.FileName;
                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Trim('"');
                    }
                    if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                    {
                        fileName = Path.GetFileName(fileName);
                    }
                    path = string.Format("{0}{1}", UPLOAD_DIR, fileName);
                    var moveTo = Path.Combine(root, fileName);
                    if (File.Exists(moveTo))
                    {
                        File.Delete(moveTo);
                    }
                    File.Move(file.LocalFileName, moveTo);
                }
                var v = new Video
                {
                    Title_EN = video.Title_EN,
                    Title_TH = video.Title_TH,
                    ImageUrl = path,
                    VideoUrl = video.VideoUrl
                };
                if (video.Id == 0)
                {
                    this._videoRepository.Add(v);
                }
                else
                {
                    var existing = this._videoRepository.FindById(video.Id);
                    existing.Title_EN = video.Title_EN;
                    existing.Title_TH = video.Title_TH;
                    if (hasFile)
                    {
                        existing.ImageUrl = path;
                    }
                    existing.VideoUrl = video.VideoUrl;
                    this._videoRepository.Update(existing);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [HttpGet, Route("deleteById")]
        public HttpResponseMessage DeleteById(int id)
        {
            try
            {
                var video = this._videoRepository.FindById(id);
                this._videoRepository.Delete(video);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
