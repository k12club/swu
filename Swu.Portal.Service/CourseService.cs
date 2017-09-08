using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using Swu.Portal.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Service
{
    public interface ICourseService
    {
        void Add(Course course, string creatorId);
        void Update(Course course);
    }
    public class CourseService : ICourseService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository2<Course> _courseRepository;
        public CourseService(IRepository2<Course> courseRepository)
        {
            this._userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SwuDBContext()));
            this._courseRepository = courseRepository;
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
    }
}
