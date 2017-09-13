using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using Swu.Portal.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Swu.Portal.Service
{
    public interface IPhotoAlbumService
    {
        void AddNewPhoto(string courseId, string albumId, string userId, Photo photo);
    }
    public class PhotoAlbumService : IPhotoAlbumService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IRepository2<PhotoAlbum> _photoAlbumRepository;
        public PhotoAlbumService(IRepository2<PhotoAlbum> photoAlbumRepository)
        {
            this._userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SwuDBContext()));
            this._photoAlbumRepository = photoAlbumRepository;
        }
        public void AddNewPhoto(string courseId, string albumId, string userId, Photo photo)
        {

            var creator = this._userManager.FindById(userId);
            using (var context = new SwuDBContext())
            {
                var existing = context.PhotoAlbums.Where(i => i.Id == albumId).Include(i=>i.Photos).FirstOrDefault();
                if (existing == null)
                {
                    context.Users.Attach(creator);
                    var album = new PhotoAlbum
                    {
                        Id = albumId,
                        CourseId = courseId,
                        Photos = new List<Photo> {
                            new Photo {
                                Name = photo.Name,
                                ImageUrl = photo.ImageUrl,
                                PublishedDate = photo.PublishedDate}
                        },
                        ApplicationUser = creator
                    };
                    context.PhotoAlbums.Add(album);
                    context.SaveChanges();
                }
                else {
                    context.Users.Attach(creator);
                    existing.Photos.Add(
                        new Photo
                        {
                            Name = photo.Name,
                            ImageUrl = photo.ImageUrl,
                            PublishedDate = photo.PublishedDate
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
