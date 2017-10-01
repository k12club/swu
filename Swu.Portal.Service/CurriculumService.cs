using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Service
{
    public interface ICurriculumService
    {
        void AddNew(Curriculum curriculum);
    }
    public class CurriculumService : ICurriculumService
    {
        public void AddNew(Curriculum curriculum)
        {
            using (var context = new SwuDBContext())
            {
                var course = context.Courses.Where(i => i.Id == curriculum.CourseId).FirstOrDefault();
                context.Courses.Attach(course);
                context.Curriculums.Add(curriculum);
                context.SaveChanges();
            }
        }
    }
}
