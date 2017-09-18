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
    public class NewsRepository:IRepository<News>
    {
        private SwuDBContext context;
        public NewsRepository()
        {
            this.context = DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<News> List
        {
            get
            {
                return this.context.News
                    .Include(i => i.ApplicationUser)
                    .AsEnumerable();
            }
        }
        public void Add(News entity)
        {
            this.context.News.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(News entity)
        {
            this.context.News.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(News entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }
        public News FindById(int Id)
        {
            var result = this.context.News
                .Include(i => i.ApplicationUser)
                .Where(i => i.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
