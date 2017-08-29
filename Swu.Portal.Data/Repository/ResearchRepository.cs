using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Repository
{
    public class ResearchRepository :IRepository2<Research>
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
                return this.context.Research
                    .AsEnumerable();
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
            var result = this.context.Research
                .Where(i => i.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
