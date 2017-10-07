using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Swu.Portal.Service
{
    public interface IStudentCourseService
    {
        List<StudentCourse> FindByBothKey(string courseId, string studentId);
        List<StudentCourse> FindByStudentId(string studentId);
    }
    public class StudentCourseService : IStudentCourseService
    {
        public List<StudentCourse> FindByBothKey(string courseId, string studentId)
        {
            List<StudentCourse> data = new List<StudentCourse>();
            using (var context = new SwuDBContext())
            {
                data = context.StudentCourse
                    .Include(i=>i.Student)
                    .Include(i=>i.Course)
                    .Where(i => i.Student.Id == studentId && i.Course.Id == courseId)
                    .ToList();
            }
            return data;
        }

        public List<StudentCourse> FindByStudentId(string studentId)
        {
            List<StudentCourse> data = new List<StudentCourse>();
            using (var context = new SwuDBContext())
            {
                data = context.StudentCourse
                    .Include(i => i.Student)
                    .Include(i => i.Course)
                    .Where(i => i.Student.Id == studentId)
                    .ToList();
            }
            return data;
        }
    }
}
