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
    [RoutePrefix("V1/News")]
    public class NewsController : ApiController
    {
        private const string UPLOAD_DIR = "FileUpload/news/";
        private readonly IDateTimeRepository _datetimeRepository;
        private readonly IRepository<News> _newsRepository;
        private readonly INewsService _newsService;
        public NewsController(IDateTimeRepository datetimeRepository, IRepository<News> newsRepository, INewsService newsService)
        {
            this._datetimeRepository = datetimeRepository;
            this._newsRepository = newsRepository;
            this._newsService = newsService;
        }
        [HttpGet, Route("all")]
        public List<NewsProxy> GetAll()
        {
            return this._newsRepository.List.Select(i => new NewsProxy(i)).ToList();
        }
        [HttpGet, Route("allActive")]
        public List<NewsProxy> GetAllActive()
        {
            return this._newsRepository
                .List
                .Where(i => i.IsActive)
                .OrderBy(i=>i.StartDate)
                .Select(i => new NewsProxy(i)).ToList();
        }
        [HttpGet, Route("getById")]
        public NewsProxy GetById(int id)
        {
            return new NewsProxy(this._newsRepository.FindById(id));
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
                NewsProxy news = new NewsProxy();
                foreach (var key in provider.FormData)
                {
                    if (key.Equals("news"))
                    {
                        var json = provider.FormData[key.ToString()];
                        news = JsonConvert.DeserializeObject<NewsProxy>(json);
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
                if (news.Id == 0)
                {
                    //this._newsRepository.Add(n);
                    this._newsService.CreateNewNews(new News
                    {
                        Title_EN = news.Title_EN,
                        Title_TH = news.Title_TH,
                        ImageUrl = path,
                        StartDate = news.StartDate,
                        FullDescription_EN = news.Description_EN,
                        FullDescription_TH = news.Description_TH,
                        IsActive = news.IsActive
                    }, news.CreatedUserId);
                }
                else
                {
                    var n = new News();
                    n.Id = news.Id;
                    n.Title_EN = news.Title_EN;
                    n.Title_TH = news.Title_TH;
                    n.FullDescription_EN = news.Description_EN;
                    n.FullDescription_TH = news.Description_TH;
                    n.IsActive = news.IsActive;
                    if (hasFile)
                    {
                        n.ImageUrl = path;
                    }
                    n.StartDate = news.StartDate;
                    //this._newsRepository.Update(existing);
                    this._newsService.UpdateNews(n, news.CreatedUserId);

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
                var e = this._newsRepository.FindById(id);
                this._newsRepository.Delete(e);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
