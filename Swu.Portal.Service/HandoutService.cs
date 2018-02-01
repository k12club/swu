using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Service
{
    public interface IHandoutService
    {
        void CreateNew(Handout h);
        void Update(Handout h);
        void Delete(Handout h);

    }
    public class HandoutService : IHandoutService
    {
        public void CreateNew(Handout h)
        {
            using (var context = new SwuDBContext())
            {
                var course = context.Courses
                    .Where(i => i.Id == h.CourseId)
                    .FirstOrDefault();
                context.Courses.Attach(course);
                h.Course = course;
                context.Handout.Add(h);
                context.SaveChanges();
            }
        }

        public void Delete(Handout h)
        {
            using (var context = new SwuDBContext())
            {
                var existing = context.Handout
                    .Where(i => i.Id == h.Id)
                    .FirstOrDefault();
                context.Handout.Remove(existing);
                context.SaveChanges();
            }
        }

        public void Update(Handout h)
        {
            using (var context = new SwuDBContext())
            {
                var existing = context.Handout
                    .Where(i => i.Id == h.Id)
                    .FirstOrDefault();
                existing.FilePath = h.FilePath;
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
