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
    public interface ICurriculumRepository : IRepository<Curriculum> {
        void Add(Curriculum entity,StudentScore score);
    }
    public class CurriculumRepository : ICurriculumRepository
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
                    .Include(i=>i.StudentScores)
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
                .Include(i => i.StudentScores)
                .Where(i => i.Id == Id).FirstOrDefault();
            return result;
        }

        public void Add(Curriculum entity, StudentScore score)
        {
            this.context.Curriculums.Attach(entity);
            entity.StudentScores.Add(score);
            this.context.SaveChanges();
        }
    }
}
