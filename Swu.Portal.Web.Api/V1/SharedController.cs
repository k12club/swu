
using Swu.Portal.Data.Models;
using Swu.Portal.Data.Repository;
using Swu.Portal.Service;
using Swu.Portal.Web.Api;
using Swu.Portal.Web.Api.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Swu.Portal.Web.Api
{
    [RoutePrefix("V1/shared")]
    public class SharedController : ApiController
    {
        private readonly IEmailSender _emailSender;
        private readonly IRepository<Photo> _photoRepository;
        private readonly IRepository2<PhotoAlbum> _photoAlbumRepository;

        public SharedController(IEmailSender emailSender, IRepository<Photo> photoRepository, IRepository2<PhotoAlbum> photoAlbumRepository)
        {
            this._emailSender = emailSender;
            this._photoRepository = photoRepository;
            this._photoAlbumRepository = photoAlbumRepository;
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
                return new List<PhotoAlbumProxy> {
                    new PhotoAlbumProxy {
                        Id = "7f9d2da3-d894-460d-a337-7f8b3c069f29",
                        Title = "ประมวณภาพการสอบคัดเลือก1",
                        DisplayImage="7f9d2da3-d894-460d-a337-7f8b3c069f29/26a0536a-4ac2-477f-8dd5-65bd7cdfc144.jpg",
                        UploadBy="Chansak kochasen",
                        PublishedDate= DateTime.UtcNow
                    },
                    new PhotoAlbumProxy {
                        Id = "66d77ba7-a6c6-43c7-b023-fe502ce3ddaa",
                        Title = "Good Bye senior Party",
                        DisplayImage="7f9d2da3-d894-460d-a337-7f8b3c069f29/2b4289fb-a94c-4aa4-a607-f949126aa46e.jpg",
                        UploadBy="Chansak kochasen",
                        PublishedDate= DateTime.UtcNow
                    }
                };
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
    }
}
