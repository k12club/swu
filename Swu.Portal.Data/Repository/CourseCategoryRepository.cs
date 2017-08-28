using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Repository
{
    public class CourseCategoryRepository : IRepository<CourseCategory>
    {
        private SwuDBContext context;
        public CourseCategoryRepository()
        {
            this.context = DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<CourseCategory> List
        {
            get
            {
                return this.context.CourseCategory
                    .AsEnumerable();
            }
        }
        public void Add(CourseCategory entity)
        {
            this.context.CourseCategory.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(CourseCategory entity)
        {
            this.context.CourseCategory.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(CourseCategory entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }
        public CourseCategory FindById(int Id)
        {
            var result = this.context.CourseCategory
                .Where(i => i.Id == Id).FirstOrDefault();
            return result;
        }
    }
}
