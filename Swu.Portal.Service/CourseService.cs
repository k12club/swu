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
        void AddStudent(Course course, string studentId);
        void RemoveStudent(Course course, string studentId);
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

        public void AddStudent(Course course, string studentId)
        {
            using (var context = new SwuDBContext())
            {
                var student = this._userManager.FindById(studentId);
                context.Courses.Attach(course);
                context.Users.Attach(student);
                context.StudentCourse.Add(new StudentCourse { Course = course, Student = student });
                context.SaveChanges();
            }
        }
        public void RemoveStudent(Course course, string studentId)
        {
            using (var context = new SwuDBContext())
            {
                var studentCourse = this._studentCourseRepository
                    .List
                    .Where(i => i.Student.Id == studentId && i.Course.Id == course.Id)
                    .FirstOrDefault();
                context.Entry(studentCourse).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

                //var entry = context.Entry<StudentCourse>(studentCourse);
                //if (entry.State == EntityState.Detached)
                //{
                //    var set = context.Set<StudentCourse>();
                //    string keyName = context.StudentCourse.Create().GetType().GetProperties().Single(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Count() > 0).Name;
                //    var pkey = context.StudentCourse.Create().GetType().GetProperty(keyName).GetValue(studentCourse);
                //    StudentCourse attachedEntity = set.Find(pkey);
                //    if (attachedEntity != null)
                //    {
                //        var attachedEntry = context.Entry(attachedEntity);
                //        attachedEntry.CurrentValues.SetValues(studentCourse);
                //        context.Entry(attachedEntry.Entity).State = System.Data.Entity.EntityState.Deleted;
                //    }
                //    else
                //    {
                //        context.Entry(studentCourse).State = System.Data.Entity.EntityState.Deleted;
                //    }
                //}
                //context.SaveChanges();
            }
        }
        public void ApproveTakeCourse(Course course, string studentId)
        {
            using (var context = new SwuDBContext())
            {
                var studentCourse = this._studentCourseRepository
                    .List
                    .Where(i => i.Student.Id == studentId && i.Course.Id == course.Id)
                    .FirstOrDefault();
                studentCourse.Activated = true;
                context.StudentCourse.Attach(studentCourse);
                context.Entry(studentCourse).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
