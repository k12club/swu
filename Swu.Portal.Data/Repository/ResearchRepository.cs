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
    public class ResearchRepository : IRepository2<Research>
    {
        private SwuDBContext context;
        public ResearchRepository()
        {
            this.context = DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<Research> List
        {
            get
            {
                List<Research> data = new List<Research>();
                using (var context = new SwuDBContext())
                {
                    data = context.Research
                        .Include(i => i.ApplicationUser)
                        .Include(i => i.AttachFiles)
                        .ToList();
                }
                return data;
            }
        }
        public void Add(Research entity)
        {
            this.context.Research.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(Research entity)
        {
            this.context.Research.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(Research entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }
        public Research FindById(string Id)
        {
            Research research = new Research();
            using (var context = new SwuDBContext())
            {
                research = context.Research.Where(i => i.Id == Id)
                        .Include(i => i.ApplicationUser)
                        .Include(i => i.AttachFiles)
                    .FirstOrDefault();
            }
            return research;
        }
    }
}
