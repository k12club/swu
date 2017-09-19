using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Repository
{
    public class ResearchCategoryRepository : IRepository<ResearchCategory>
    {
        private SwuDBContext context;
        public ResearchCategoryRepository()
        {
            this.context = DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<ResearchCategory> List
        {
            get
            {
                List<ResearchCategory> data = new List<ResearchCategory>();
                using (var context = new SwuDBContext())
                {
                    data = context.ResearchCategory
                        .ToList();
                }
                return data;
            }
        }
        public void Add(ResearchCategory entity)
        {
            this.context.ResearchCategory.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(ResearchCategory entity)
        {
            this.context.ResearchCategory.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(ResearchCategory entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }
        public ResearchCategory FindById(int Id)
        {
            ResearchCategory data = new ResearchCategory();
            using (var context = new SwuDBContext())
            {
                data = context.ResearchCategory.Where(i => i.Id == Id)
                    .FirstOrDefault();
            }
            return data;
        }
    }
}
