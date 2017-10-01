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

namespace Swu.Portal.Service
{
    public interface IStudentScoreService
    {
        List<StudentScore> FindByBothKey(int curriculumId, string studentId);
        void AddScore(StudentScore score, int curriculumId, string studentId);
    }
    public class StudentScoreService : IStudentScoreService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentScoreService()
        {
            this._userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SwuDBContext()));

        }
        public void AddScore(StudentScore score, int curriculumId, string studentId)
        {
            using (var context = new SwuDBContext())
            {
                var existing = context.Curriculums.Where(i => i.Id == curriculumId).FirstOrDefault();
                var student = this._userManager.FindById(studentId);
                context.Users.Attach(student);
                context.Curriculums.Attach(existing);
                score.Student = student;
                score.Curriculum = existing;
                context.StudentScore.Add(score);
                context.SaveChanges();
            }
        }

        public List<StudentScore> FindByBothKey(int curriculumId, string studentId)
        {
            List<StudentScore> data = new List<StudentScore>();
            using (var context = new SwuDBContext())
            {
                data = context.StudentScore
                    .Include(i=>i.Student)
                    .Include(i=>i.Curriculum)
                    .Where(i => i.Student.Id == studentId && i.CurriculumId == curriculumId)
                    .ToList();
            }
            return data;
        }
    }
}
