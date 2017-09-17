using Newtonsoft.Json;
using Swu.Portal.Core.Dependencies;
using Swu.Portal.Data.Models;
using Swu.Portal.Data.Repository;
using Swu.Portal.Service;
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

namespace Swu.Portal.Web.Api.V1
{
    [RoutePrefix("V1/Research")]
    public class ResearchController : ApiController
    {
        private const string UPLOAD_DIR = "FileUpload/research/";
        private readonly IRepository2<Research> _researchRepository;
        private readonly IRepository<ResearchCategory> _researchCategoryRepository;
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IDateTimeRepository _datetimeRepository;
        private readonly IResearchService _researchService;
        public ResearchController(
            IRepository2<Research> researchRepository,
            IRepository<ResearchCategory> researchCategoryRepository,
            IConfigurationRepository configurationRepository,
            IDateTimeRepository datetimeRepository,
            IResearchService researchService)
        {
            this._researchRepository = researchRepository;
            this._researchCategoryRepository = researchCategoryRepository;
            this._configurationRepository = configurationRepository;
            this._datetimeRepository = datetimeRepository;
            this._researchService = researchService;
        }
        [HttpGet, Route("allItems")]
        public List<WebboardItemProxy> GetAllItems(string keyword)
        {
            var webboardItems = new List<WebboardItemProxy>();
            var research = new List<Research>();
            if (keyword.Equals("*"))
            {
                research = this._researchRepository.List.ToList();
            }
            else
            {
                research = this._researchRepository.List.Where(i => i.Name_EN.ToLower().Contains(keyword.ToLower()) || i.Name_TH.ToLower().Contains(keyword.ToLower())).ToList();
            }
            foreach (var r in research)
            {
                webboardItems.Add(new WebboardItemProxy(r, this._configurationRepository.DefaultUserImage));
            }
            return webboardItems;
        }
        [HttpGet, Route("category")]
        public List<WebboardCategoryProxy> GetCategory()
        {
            var webboardCategories = new List<WebboardCategoryProxy>();
            var catgories = this._researchCategoryRepository.List.ToList();
            foreach (var c in catgories)
            {
                webboardCategories.Add(new WebboardCategoryProxy(c));
            }
            return webboardCategories;
        }
        [HttpGet, Route("getResearchById")]
        public WebboardItemProxy GetResearchById(string id)
        {
            var forum = this._researchRepository.FindById(id);
            return new WebboardItemProxy(forum, this._configurationRepository.DefaultUserImage);
        }
        [HttpPost, Route("SaveAsync")]
        public async Task<HttpResponseMessage> PostFormData()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            var GuID = Guid.NewGuid().ToString();
            var hasFile = false;
            string root = HttpContext.Current.Server.MapPath("~/" + UPLOAD_DIR);
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                WebboardItemProxy research = new WebboardItemProxy();
                foreach (var key in provider.FormData)
                {
                    if (key.Equals("research"))
                    {
                        var json = provider.FormData[key.ToString()];
                        research = JsonConvert.DeserializeObject<WebboardItemProxy>(json);
                    }
                }
                string path = string.Empty;
                foreach (MultipartFileData file in provider.FileData)
                {
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
                    hasFile = true;
                }
                var r = new Research
                {
                    ShortDescription = research.ShortDescription,
                    FullDescription = research.FullDescription,
                    CategoryId = research.CategoryId,
                    CreatorName = research.MoreDetail.CreatorName,
                    Contributor = research.MoreDetail.Contributor,
                    Name_EN = research.Name,
                    Name_TH = research.Name,
                    PublishDate = research.MoreDetail.PublishDate,
                    Publisher = research.MoreDetail.Publisher,
                    CreatedDate = this._datetimeRepository.Now()
                };
                if (string.IsNullOrEmpty(research.Id))
                {
                    r.Id = GuID;
                    r.AttachFiles = new List<AttachFile> {
                            new AttachFile {
                                FilePath = path
                            }
                        };
                    r.UpdatedDate = this._datetimeRepository.Now();
                    this._researchService.CreateNewResearch(r, research.UserId);
                }
                else
                {
                    r.Id = research.Id;
                    if (hasFile)
                    {
                        r.AttachFiles = new List<AttachFile> {
                            new AttachFile {
                                FilePath = path
                            }
                        };
                    }
                    this._researchService.UpdateResearch(r, research.UserId, hasFile);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
