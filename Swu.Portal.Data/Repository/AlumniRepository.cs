using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Repository
{
    public class AlumniRepository : IRepository<Alumni>
    {
        private SwuDBContext context;
        public AlumniRepository()
        {
            this.context = new SwuDBContext();
        }
        public IEnumerable<Alumni> List
        {
            get
            {
                List<Alumni> data = new List<Alumni>();
                using (var context = new SwuDBContext())
                {
                    data = context.Alumni
                        .ToList();
                }
                return data;
            }
        }
        public void Add(Alumni entity)
        {
            this.context.Alumni.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(Alumni entity)
        {
            this.context.Alumni.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(Alumni entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }
        public Alumni FindById(int Id)
        {
            Alumni data = new Alumni();
            using (var context = new SwuDBContext())
            {
                data = context.Alumni
                    .Where(i => i.Id == Id)
                    .FirstOrDefault();
            }
            return data;
        }
    }
}
