﻿using Newtonsoft.Json;
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
        public NewsController(IDateTimeRepository datetimeRepository, IRepository<News> newsRepository)
        {
            this._datetimeRepository = datetimeRepository;
            this._newsRepository = newsRepository;
        }
        [HttpGet, Route("all")]
        public List<NewsProxy> GetAll()
        {
            return this._newsRepository.List.Select(i => new NewsProxy(i)).ToList();
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
                var v = new News
                {
                    Title_EN = news.Title_EN,
                    Title_TH = news.Title_TH,
                    ImageUrl = path,
                    StartDate = news.StartDate,
                    FullDescription_EN = news.Description_EN,
                    FullDescription_TH = news.Description_TH
                };
                if (news.Id == 0)
                {
                    this._newsRepository.Add(v);
                }
                else
                {
                    var existing = this._newsRepository.FindById(news.Id);
                    existing.Title_EN = news.Title_EN;
                    existing.Title_TH = news.Title_TH;
                    existing.FullDescription_EN = news.Description_EN;
                    existing.FullDescription_TH = news.Description_TH;
                    if (hasFile)
                    {
                        existing.ImageUrl = path;
                    }
                    existing.StartDate = news.StartDate;
                    this._newsRepository.Update(existing);
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
