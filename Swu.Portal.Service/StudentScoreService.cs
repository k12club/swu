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
        List<StudentScore> FindByCurriculumId(int curriculumId);
        List<StudentScore> FindByBothKey(int curriculumId, string studentId);
        void AddScore(StudentScore score, int curriculumId, string studentId);
        void UpdateScores(List<StudentScore> scores);
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
                    .Include(i => i.Student)
                    .Include(i => i.Curriculum)
                    .Where(i => i.Student.Id == studentId && i.CurriculumId == curriculumId)
                    .ToList();
            }
            return data;
        }

        public List<StudentScore> FindByCurriculumId(int curriculumId)
        {
            List<StudentScore> data = new List<StudentScore>();
            using (var context = new SwuDBContext())
            {
                data = context.StudentScore.Include(i => i.Student).Where(i => i.CurriculumId == curriculumId).ToList();
            }
            return data;
        }

        public void UpdateScores(List<StudentScore> scores)
        {
            using (var context = new SwuDBContext())
            {
                foreach (var score in scores)
                {
                    var existing = context.StudentScore.Where(i => i.Id == score.Id).FirstOrDefault();
                    existing.Score = score.Score;
                    context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
    }
}
