using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Swu.Portal.Data.Repository
{
    public class PhotoAlbumRepository : IRepository2<PhotoAlbum>
    {
        private SwuDBContext context;
        public PhotoAlbumRepository()
        {
            this.context = DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<PhotoAlbum> List
        {
            get
            {
                return this.context.PhotoAlbums
                    .Include(i => i.Photos)
                    .AsEnumerable();
            }
        }
        public void Add(PhotoAlbum entity)
        {
            this.context.PhotoAlbums.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(PhotoAlbum entity)
        {
            this.context.PhotoAlbums.Remove(entity);
            this.context.SaveChanges();
        }

        public void Update(PhotoAlbum entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }

        public PhotoAlbum FindById(string Id)
        {
            var result = this.context.PhotoAlbums
                .Include(i => i.Photos)
                .Where(i => i.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
