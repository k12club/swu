using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Swu.Portal.Data.Repository
{
    public interface ICurriculumRepository : IRepository<Curriculum> {
        void Add(Curriculum entity,StudentScore score);
    }
    public class CurriculumRepository : ICurriculumRepository
    {
        private SwuDBContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CurriculumRepository()
        {
            this.context = DbContextFactory.Instance.GetOrCreateContext();
            this._userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SwuDBContext()));
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
            using (var context = new SwuDBContext()) {
                var existing = context.Curriculums.Where(i => i.Id == entity.Id).FirstOrDefault();
                var student = this._userManager.FindById(score.Student.Id);
                context.Users.Attach(student);
                context.Curriculums.Attach(existing);
                existing.StudentScores.Add(score);
                context.SaveChanges();
            }
        }
    }
}
