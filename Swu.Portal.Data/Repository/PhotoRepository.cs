using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Repository
{
    public class PhotoRepository : IRepository<Photo>
    {
        private SwuDBContext context;
        public PhotoRepository()
        {
            this.context = DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<Photo> List
        {
            get
            {
                return this.context.Photos
                    .AsEnumerable();
            }
        }
        public void Add(Photo entity)
        {
            this.context.Photos.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(Photo entity)
        {
            this.context.Photos.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(Photo entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }
        public Photo FindById(int Id)
        {
            var result = this.context.Photos
                .Where(i => i.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
