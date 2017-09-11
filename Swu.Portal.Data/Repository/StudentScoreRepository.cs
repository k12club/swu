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
    public class StudentScoreRepository :IRepository<StudentScore>
    {
        private SwuDBContext context;
        public StudentScoreRepository()
        {
            this.context = DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<StudentScore> List
        {
            get
            {
                return this.context.StudentScore
                    .Include(i => i.Student)
                    .AsEnumerable();
            }
        }
        public void Add(StudentScore entity)
        {
            this.context.StudentScore.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(StudentScore entity)
        {
            this.context.StudentScore.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(StudentScore entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }
        public StudentScore FindById(int Id)
        {
            var result = this.context.StudentScore
                .Include(i => i.Student)
                .Where(i => i.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
