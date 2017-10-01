using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using Swu.Portal.Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Service
{
    public interface ICourseService
    {
        void Add(Course course, string creatorId);
        void Update(Course course);
        void AddStudent(string courseId, string studentId);
        void RemoveStudent(string courseId, string studentId);
        void ApproveTakeCourse(Course course, string studentId);
    }
    public class CourseService : ICourseService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository2<Course> _courseRepository;
        private readonly IStudentCourseRepository _studentCourseRepository;
        public CourseService(IRepository2<Course> courseRepository, IStudentCourseRepository studentCourseRepository)
        {
            this._userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SwuDBContext()));
            this._courseRepository = courseRepository;
            this._studentCourseRepository = studentCourseRepository;
        }
        public void Add(Course course, string creatorId)
        {
            using (var context = new SwuDBContext())
            {
                var creator = this._userManager.FindById(creatorId);
                context.Users.Attach(creator);
                course.Teachers.Add(creator);
                context.Courses.Add(course);
                context.SaveChanges();
            }
        }
        public void Update(Course course)
        {
            this._courseRepository.Update(course);
        }

        public void AddStudent(string courseId, string studentId)
        {
            using (var context = new SwuDBContext())
            {
                var c = context.Courses.AsNoTracking().Where(i => i.Id == courseId).FirstOrDefault();
                context.Courses.Attach(c);
                var s = context.Users.AsNoTracking().Where(i => i.Id == studentId).FirstOrDefault();
                context.Users.Attach(s);
                context.StudentCourse.Add(new StudentCourse { Course = c, Student = s });
                context.SaveChanges();
            }
        }
        public void RemoveStudent(string courseId, string studentId)
        {
            using (var context = new SwuDBContext())
            {
                var studentCourse = context.StudentCourse.AsNoTracking().Where(i => i.Student.Id == studentId && i.Course.Id == courseId).FirstOrDefault();
                context.Entry(studentCourse).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void ApproveTakeCourse(Course course, string studentId)
        {
            using (var context = new SwuDBContext())
            {
                var studentCourse = context.StudentCourse.Where(i => i.Student.Id == studentId && i.Course.Id == course.Id).FirstOrDefault();
                studentCourse.Activated = true;
                context.StudentCourse.Attach(studentCourse);
                context.Entry(studentCourse).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
