using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Service
{
    public interface IAlumniService
    {
        void CreateNew(Alumni b);
        void ClearAll(string year);
        void Update(Alumni b);
        void Delete(Alumni b);

    }
    public class AlumniService : IAlumniService
    {
        public void ClearAll(string year)
        {
            using (var context = new SwuDBContext())
            {
                var clearList = context.Alumni
                    .Where(i => i.GraduatedYear == year).ToList();
                context.Alumni.RemoveRange(clearList);
                context.SaveChanges();
            }
        }

        public void CreateNew(Alumni a)
        {
            using (var context = new SwuDBContext())
            {
                context.Alumni.Add(a);
                context.SaveChanges();
            }
        }

        public void Delete(Alumni a)
        {
            using (var context = new SwuDBContext())
            {
                var existing = context.Alumni
                    .Where(i => i.Id == a.Id)
                    .FirstOrDefault();
                context.Alumni.Remove(existing);
                context.SaveChanges();
            }
        }

        public void Update(Alumni a)
        {
            using (var context = new SwuDBContext())
            {
                var existing = context.Alumni
                    .Where(i => i.Id == a.Id)
                    .FirstOrDefault();
                existing.StudentId = a.StudentId;
                existing.FullName = a.FullName;
                existing.GraduatedYear = a.GraduatedYear;
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
