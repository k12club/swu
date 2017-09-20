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
    public class CourseRepository : IRepository2<Course>
    {
        private SwuDBContext context;
        public CourseRepository()
        {
            this.context = new SwuDBContext(); //DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<Course> List
        {
            get
            {
                List<Course> data = new List<Course>();
                using (var context = new SwuDBContext())
                {
                    data = context.Courses
                        .Include(i => i.Category)
                            .Include(i => i.Curriculums)
                            .Include(i => i.Students)
                            .Include(i => i.Teachers)
                            .Include(i => i.PhotoAlbums)
                            .Include(i => i.ApplicationUser)
                        .ToList();
                }
                return data;
            }
        }
        public void Add(Course entity)
        {
            this.context.Courses.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(Course entity)
        {
            this.context.Courses.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(Course entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();
        }
        public Course FindById(string Id)
        {
            Course data = new Course();
            using (var context = new SwuDBContext())
            {
                data = context.Courses
                    .Include(i => i.Category)
                        .Include(i => i.Curriculums)
                        .Include(i => i.Students)
                        .Include(i => i.Teachers)
                        .Include(i => i.PhotoAlbums)
                        .Include(i => i.ApplicationUser)
                    .Where(i => i.Id == Id)
                    .FirstOrDefault();
            }
            return data;
        }
    }
}
