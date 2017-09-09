using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Repository
{
    public class CurriculumRepository : IRepository<Curriculum>
    {
        private SwuDBContext context;
        public CurriculumRepository()
        {
            this.context = DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<Curriculum> List
        {
            get
            {
                return this.context.Curriculums
                    .AsEnumerable();
            }
        }
        public void Add(Curriculum entity)
        {
            this.context.Curriculums.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(Curriculum entity)
        {
            this.context.Curriculums.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(Curriculum entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }
        public Curriculum FindById(int Id)
        {
            var result = this.context.Curriculums
                .Where(i => i.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
