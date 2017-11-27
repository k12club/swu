using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Repository
{
    public class BannerRepository : IRepository<Banner>
    {
        private SwuDBContext context;
        public BannerRepository()
        {
            this.context = new SwuDBContext(); //DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<Banner> List
        {
            get
            {
                List<Banner> data = new List<Banner>();
                using (var context = new SwuDBContext())
                {
                    data = context.Banners
                        .ToList();
                }
                return data;
            }
        }
        public void Add(Banner entity)
        {
            this.context.Banners.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(Banner entity)
        {
            this.context.Banners.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(Banner entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }
        public Banner FindById(int Id)
        {
            Banner data = new Banner();
            using (var context = new SwuDBContext())
            {
                data = context.Banners
                    .Where(i => i.Id == Id)
                    .FirstOrDefault();
            }
            return data;
        }
    }
}
