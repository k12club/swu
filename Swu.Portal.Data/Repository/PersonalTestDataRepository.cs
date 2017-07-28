using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Repository
{
    public class PersonalTestDataRepository : IRepository<PersonalTestData>
    {
        private SwuDBContext context;
        public PersonalTestDataRepository()
        {
            this.context = DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<PersonalTestData> List
        {
            get
            {
                return this.context.PersonalTestData;
            }
        }
        public void Add(PersonalTestData entity)
        {
            this.context.PersonalTestData.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(PersonalTestData entity)
        {
            this.context.PersonalTestData.Remove(entity);
            this.context.SaveChanges();
        }

        public void Update(PersonalTestData entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }

        public PersonalTestData FindById(int Id)
        {
            var result = this.context.PersonalTestData.Where(i => i.ID == Id).FirstOrDefault();
            return result;
        }
    }
}
