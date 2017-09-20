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
            this.context = new SwuDBContext(); //DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<News> List
        {
            get
            {
                List<News> data = new List<News>();
                using (var context = new SwuDBContext())
                {
                    data = context.News
                        .Include(i => i.ApplicationUser)
                        .ToList();
                }
                return data;
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
            News data = new News();
            using (var context = new SwuDBContext())
            {
                data = context.News
                    .Include(i => i.ApplicationUser)
                    .Where(i => i.Id == Id)
                    .FirstOrDefault();
            }
            return data;
        }
    }
}
