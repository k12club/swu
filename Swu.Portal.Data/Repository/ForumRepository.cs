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
    public class ForumRepository :IRepository2<Forum>
    {
        private SwuDBContext context;
        public ForumRepository()
        {
            this.context = DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<Forum> List
        {
            get
            {
                return this.context.Forums
                    .Include(i=>i.Comments)
                    .AsEnumerable();
            }
        }
        public void Add(Forum entity)
        {
            this.context.Forums.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(Forum entity)
        {
            this.context.Forums.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(Forum entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }
        public Forum FindById(string Id)
        {
            var result = this.context.Forums
                .Include(i => i.Comments)
                .Where(i => i.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
