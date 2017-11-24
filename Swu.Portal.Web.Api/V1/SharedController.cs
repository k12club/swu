
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
    [RoutePrefix("V1/shared")]
    public class SharedController : ApiController
    {
        private const string UPLOAD_DIR = "FileUpload/photo/";

        private readonly IEmailSender _emailSender;
        private readonly IRepository<Photo> _photoRepository;
        private readonly IRepository2<PhotoAlbum> _photoAlbumRepository;
        private readonly IDateTimeRepository _datetimeRepository;
        private readonly IConfigurationRepository _configRepository;
        private readonly IPhotoAlbumService _photoAlbumService;

        public SharedController(
            IEmailSender emailSender,
            IRepository<Photo> photoRepository,
            IRepository2<PhotoAlbum> photoAlbumRepository,
            IDateTimeRepository datetimeRepository,
            IConfigurationRepository configRepository,
            IPhotoAlbumService photoAlbumService)
        {
            this._emailSender = emailSender;
            this._photoRepository = photoRepository;
            this._photoAlbumRepository = photoAlbumRepository;
            this._datetimeRepository = datetimeRepository;
            this._configRepository = configRepository;
            this._photoAlbumService = photoAlbumService;
        }
        [HttpGet, Route("commitments")]
        public List<CommitmentProxy> GetCommitment()
        {
            if (ModelState.IsValid)
            {
                return new List<CommitmentProxy> {
                    new CommitmentProxy {
                        Title_EN="Objective 1",
                        Description_EN="To enhance the learning opportunity of medical programme from both national and international schools in Thailand",
                        Title_TH="Objective 1",
                        Description_TH="To enhance the learning opportunity of medical programme from both national and international schools in Thailand",
                        IconCss="flaticon-clothes"
                    },
                    new CommitmentProxy {
                        Title_EN="Objective 2",
                        Description_EN="To produce the knowledgeable medical graduates who can use the medical sciences knowledge from the UK and apply it to clinical practice in Thailand",
                        Title_TH="Objective 2",
                        Description_TH="To produce the knowledgeable medical graduates who can use the medical sciences knowledge from the UK and apply it to clinical practice in Thailand",
                        IconCss="flaticon-signs"
                    },
                    new CommitmentProxy {
                        Title_EN="Objective 3",
                        Description_EN="To produce medical graduates who can provide the efficient health care services to the society both in government and private sectors",
                        Title_TH="Objective 3",
                        Description_TH="To produce medical graduates who can provide the efficient health care services to the society both in government and private sectors",
                        IconCss="flaticon-school"
                    }
                };
            }
            return null;
        }
        [HttpPost, Route("sendMail")]
        public HttpResponseMessage SendMail(EmailProxy email)
        {
            try
            {
                this._emailSender.Send(new Service.Model.Email
                {
                    SenderName = email.Sender,
                    SenderEmail = email.Email,
                    Message = email.Message
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [HttpGet, Route("albums")]
        public List<PhotoAlbumProxy> GetAlbums()
        {
            if (ModelState.IsValid)
            {
                var albums = this._photoAlbumRepository.List
                    .Where(i => i.CourseId == this._configRepository.dummyCourse)
                    .Select(i => new PhotoAlbumProxy
                    {
                        Id = i.Id,
                        Title = i.Name,
                        DisplayImage = i.Photos.FirstOrDefault().ImageUrl,
                        UploadBy = i.ApplicationUser.FirstName_EN + " " + i.ApplicationUser.LastName_EN,
                        PublishedDate = i.CreatedDate
                    })
                    .OrderByDescending(o => o.PublishedDate)
                    .Take(3)
                    .ToList();
                return albums;
            }
            return null;
        }
        [HttpGet, Route("photo")]
        public List<PhotoProxy> GetPhotosById(string id)
        {
            if (ModelState.IsValid)
            {
                var album = this._photoAlbumRepository.FindById(id);
                List<PhotoProxy> photos = new List<PhotoProxy>();
                if (album != null)
                {
                    foreach (var p in album.Photos)
                    {
                        photos.Add(new PhotoProxy(p, album.ApplicationUser));
                    }
                }
                return photos;
            }
            return null;
        }
        [HttpPost, Route("createNewAlbum")]
        public async Task<HttpResponseMessage> CreateNewAlbum()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/" + UPLOAD_DIR);
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                string title = "";
                string userId = "";
                string albumId = Guid.NewGuid().ToString();
                foreach (var key in provider.FormData)
                {
                    if (key.Equals("title"))
                    {
                        var json = provider.FormData[key.ToString()];
                        title = JsonConvert.DeserializeObject<string>(json);
                    }
                    if (key.Equals("userId"))
                    {
                        var json = provider.FormData[key.ToString()];
                        userId = JsonConvert.DeserializeObject<string>(json);
                    }
                }
                string _path = string.Empty;
                List<PhotoProxy> photos = new List<PhotoProxy>();
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
                    var folder = Path.Combine(root, albumId);
                    var moveTo = Path.Combine(folder, fileName);
                    if (File.Exists(moveTo))
                    {
                        File.Delete(moveTo);
                    }
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    _path = string.Format("{0}{1}/{2}", UPLOAD_DIR, albumId, fileName);
                    File.Move(file.LocalFileName, moveTo);
                    var imageUrl = string.Format("{0}?{1}", _path, this._datetimeRepository.Now());
                    photos.Add(new PhotoProxy
                    {
                        Name = fileName,
                        ImageUrl = imageUrl,
                        PublishedDate = this._datetimeRepository.Now(),
                    });
                }
                foreach (var p in photos)
                {
                    this._photoAlbumService.AddNewAlbumAndPhoto(this._configRepository.dummyCourse, albumId, title, userId, p.ToEntity());
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
