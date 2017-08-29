using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Repository
{
    public class ForumCategoryRepository : IRepository<ForumCategory>
    {
        private SwuDBContext context;
        public ForumCategoryRepository()
        {
            this.context = DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<ForumCategory> List
        {
            get
            {
                return this.context.ForumCategory
                    .AsEnumerable();
            }
        }
        public void Add(ForumCategory entity)
        {
            this.context.ForumCategory.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(ForumCategory entity)
        {
            this.context.ForumCategory.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(ForumCategory entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }
        public ForumCategory FindById(int Id)
        {
            var result = this.context.ForumCategory
                .Where(i => i.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
