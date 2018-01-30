
using ExcelDataReader;
using Newtonsoft.Json;
using Swu.Portal.Core.Dependencies;
using Swu.Portal.Data.Models;
using Swu.Portal.Data.Repository;
using Swu.Portal.Service;
using Swu.Portal.Web.Api;
using Swu.Portal.Web.Api.Enum;
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
        private const string UPLOAD_BANNER_DIR = "FileUpload/banner/";
        private const string UPLOAD_ALUMNI_DIR = "FileUpload/alumni/";

        private readonly IEmailSender _emailSender;
        private readonly IRepository<Photo> _photoRepository;
        private readonly IRepository2<PhotoAlbum> _photoAlbumRepository;
        private readonly IDateTimeRepository _datetimeRepository;
        private readonly IConfigurationRepository _configRepository;
        private readonly IPhotoAlbumService _photoAlbumService;
        private readonly IRepository<Banner> _bannerRepository;
        private readonly IBannerService _bannerService;
        private readonly IAlumniService _alumniService;
        private readonly IRepository<Alumni> _alumniRepository;
        public SharedController(
            IEmailSender emailSender,
            IRepository<Photo> photoRepository,
            IRepository2<PhotoAlbum> photoAlbumRepository,
            IDateTimeRepository datetimeRepository,
            IConfigurationRepository configRepository,
            IPhotoAlbumService photoAlbumService,
            IRepository<Banner> bannerRepository,
            IBannerService bannerService,
            IAlumniService alumniService,
            IRepository<Alumni> alumniRepository)
        {
            this._emailSender = emailSender;
            this._photoRepository = photoRepository;
            this._photoAlbumRepository = photoAlbumRepository;
            this._datetimeRepository = datetimeRepository;
            this._configRepository = configRepository;
            this._photoAlbumService = photoAlbumService;
            this._bannerRepository = bannerRepository;
            this._bannerService = bannerService;
            this._alumniService = alumniService;
            this._alumniRepository = alumniRepository;
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
                        IconCss="fa fa-university"
                    },
                    new CommitmentProxy {
                        Title_EN="Objective 2",
                        Description_EN="To produce the knowledgeable medical graduates who can use the medical sciences knowledge from the UK and apply it to clinical practice in Thailand",
                        Title_TH="Objective 2",
                        Description_TH="To produce the knowledgeable medical graduates who can use the medical sciences knowledge from the UK and apply it to clinical practice in Thailand",
                        IconCss="fa fa-user-md"
                    },
                    new CommitmentProxy {
                        Title_EN="Objective 3",
                        Description_EN="To produce medical graduates who can provide the efficient health care services to the society both in government and private sectors",
                        Title_TH="Objective 3",
                        Description_TH="To produce medical graduates who can provide the efficient health care services to the society both in government and private sectors",
                        IconCss="fa fa-hospital-o"
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
                    .Take(4)
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

        [HttpGet, Route("getActiveSlider")]
        public List<SliderProxy> GetActiveSlider()
        {
            var sliders = this._bannerRepository.List
                .Where(i => i.IsActive)
                .Select(i => new SliderProxy
                {
                    Id = i.Id,
                    Title_EN = i.Title_EN,
                    Title_TH = i.Title_TH,
                    Description_EN = i.Description_EN,
                    Description_TH = i.Description_TH,
                    ImageUrl = i.ImageUrl,
                    IsActive = i.IsActive
                })
                .ToList();
            return sliders;
        }
        [HttpGet, Route("getSlider")]
        public List<SliderProxy> GetSlider()
        {
            var sliders = this._bannerRepository.List
                .Select(i => new SliderProxy
                {
                    Id = i.Id,
                    Title_EN = i.Title_EN,
                    Title_TH = i.Title_TH,
                    Description_EN = i.Description_EN,
                    Description_TH = i.Description_TH,
                    ImageUrl = i.ImageUrl,
                    IsActive = i.IsActive
                })
                .ToList();
            return sliders;
        }
        [HttpGet, Route("getById")]
        public SliderProxy GetById(int id)
        {
            return new SliderProxy(this._bannerRepository.FindById(id));
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
            string root = HttpContext.Current.Server.MapPath("~/" + UPLOAD_BANNER_DIR);
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                SliderProxy slider = new SliderProxy();
                foreach (var key in provider.FormData)
                {
                    if (key.Equals("slider"))
                    {
                        var json = provider.FormData[key.ToString()];
                        slider = JsonConvert.DeserializeObject<SliderProxy>(json);
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
                    path = string.Format("{0}{1}", UPLOAD_BANNER_DIR, fileName);
                    var moveTo = Path.Combine(root, fileName);
                    if (File.Exists(moveTo))
                    {
                        File.Delete(moveTo);
                    }
                    File.Move(file.LocalFileName, moveTo);
                }
                var v = new Banner
                {
                    Title_EN = slider.Title_EN,
                    Title_TH = slider.Title_TH,
                    ImageUrl = path,
                    Description_EN = slider.Description_EN,
                    Description_TH = slider.Description_TH,
                    IsActive = slider.IsActive
                };
                if (slider.Id == 0)
                {
                    this._bannerRepository.Add(v);
                }
                else
                {
                    var existing = this._bannerRepository.FindById(slider.Id);
                    existing.Title_EN = slider.Title_EN;
                    existing.Title_TH = slider.Title_TH;
                    existing.Description_EN = slider.Description_EN;
                    existing.Description_TH = slider.Description_TH;
                    existing.IsActive = slider.IsActive;
                    if (hasFile)
                    {
                        existing.ImageUrl = path;
                    }
                    this._bannerRepository.Update(existing);
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
                var b = this._bannerRepository.FindById(id);
                this._bannerService.Delete(b);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet, Route("allAlbums")]
        public List<PhotoAlbumProxy> GetAllAlbums()
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
                    .ToList();
                return albums;
            }
            return null;
        }
        [HttpGet, Route("getAlbumById")]
        public PhotoAlbumProxy GetAlbumById(string id)
        {
            var albums = this._photoAlbumRepository.List
                   .Where(i => i.Id == id)
                   .FirstOrDefault();
            return new PhotoAlbumProxy
            {
                Id = albums.Id,
                Title = albums.Name,
                DisplayImage = albums.Photos.FirstOrDefault().ImageUrl,
                UploadBy = albums.ApplicationUser.FirstName_EN + " " + albums.ApplicationUser.LastName_EN,
                PublishedDate = albums.CreatedDate
            };
        }
        [HttpGet, Route("deleteAlbumById")]
        public HttpResponseMessage DeleteAlbumById(string id)
        {
            try
            {
                var a = this._photoAlbumRepository.FindById(id);
                this._photoAlbumRepository.Delete(a);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [HttpPost, Route("updatePhotoAlbum")]
        public HttpResponseMessage UpdatePhotoAlbum(PhotoAlbumProxy album)
        {
            try
            {
                var a = this._photoAlbumRepository.FindById(album.Id);
                a.Name = album.Title;
                this._photoAlbumRepository.Update(a);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet, Route("alumniYear")]
        public List<string> GetYears()
        {
            return this._alumniRepository.List
                .Select(i => int.Parse(i.GraduatedYear))
                .Distinct()
                .OrderBy(i => i)
                .Select(i => i.ToString())
                .ToList();
        }
        [HttpGet, Route("getStudentByYear")]
        public List<AlumniProxy> GetStudentByYear(string year)
        {
            return this._alumniRepository.List
                .Where(i => i.GraduatedYear == year)
                .Select(i => i.ToViewModel())
                .ToList();
        }

        [HttpPost, Route("importAlumni")]
        public async Task<HttpResponseMessage> ImportAlumni()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string root = HttpContext.Current.Server.MapPath("~/" + UPLOAD_ALUMNI_DIR);
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                SliderProxy slider = new SliderProxy();
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
                    path = string.Format("{0}{1}", UPLOAD_ALUMNI_DIR, fileName);
                    var moveTo = Path.Combine(root, fileName);
                    if (File.Exists(moveTo))
                    {
                        File.Delete(moveTo);
                    }
                    File.Move(file.LocalFileName, moveTo);

                    using (FileStream stream = System.IO.File.Open(moveTo, FileMode.Open, FileAccess.Read))
                    {
                        var importData = new List<AlumniProxy>();
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet();
                            var data = result.Tables[0];
                            for (var row = 0; row < data.Rows.Count; row++)
                            {
                                if (row == 0) continue;
                                importData.Add(new AlumniProxy
                                {
                                    StudentId = data.Rows[row].ItemArray[AlumniColumn.StudentID].ToString(),
                                    FullName = data.Rows[row].ItemArray[AlumniColumn.FullName].ToString(),
                                    GraduatedYear = data.Rows[row].ItemArray[AlumniColumn.GraduatedYear].ToString(),
                                });
                            }
                        }
                        if (importData.Count() > 0)
                        {
                            this._alumniService.ClearAll(importData.FirstOrDefault().GraduatedYear);
                            foreach (var alumni in importData)
                            {
                                this._alumniService.CreateNew(new Alumni
                                {
                                    StudentId = alumni.StudentId,
                                    FullName = alumni.FullName,
                                    GraduatedYear = alumni.GraduatedYear
                                });
                            }
                        }
                    }
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
