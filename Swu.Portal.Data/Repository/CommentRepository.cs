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
    public class CommentRepository : IRepository<Comment>
    {
        private SwuDBContext context;
        public CommentRepository()
        {
            this.context = DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<Comment> List
        {
            get
            {
                return this.context.Comments
                    .Include(i=>i.ApplicationUser)
                    .AsEnumerable();
            }
        }
        public void Add(Comment entity)
        {
            this.context.Comments.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(Comment entity)
        {
            this.context.Comments.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(Comment entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }
        public Comment FindById(int Id)
        {
            var result = this.context.Comments
                .Include(i => i.ApplicationUser)
                .Where(i => i.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
