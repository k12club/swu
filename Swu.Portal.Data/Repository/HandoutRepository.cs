using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Repository
{
    public class HandoutRepository : IRepository<Handout>
    {
        private SwuDBContext context;
        public HandoutRepository()
        {
            this.context = new SwuDBContext();
        }
        public IEnumerable<Handout> List
        {
            get
            {
                List<Handout> data = new List<Handout>();
                using (var context = new SwuDBContext())
                {
                    data = context.Handout
                        .ToList();
                }
                return data;
            }
        }
        public void Add(Handout entity)
        {
            this.context.Handout.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(Handout entity)
        {
            this.context.Handout.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(Handout entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }
        public Handout FindById(int Id)
        {
            Handout data = new Handout();
            using (var context = new SwuDBContext())
            {
                data = context.Handout
                    .Where(i => i.Id == Id)
                    .FirstOrDefault();
            }
            return data;
        }
    }
}
