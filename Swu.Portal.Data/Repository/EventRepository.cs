using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Swu.Portal.Data.Repository
{
    public class EventRepository :IRepository<Event>
    {
        private SwuDBContext context;
        public EventRepository()
        {
            this.context = DbContextFactory.Instance.GetOrCreateContext();
        }
        public IEnumerable<Event> List
        {
            get
            {
                List<Event> data = new List<Event>();
                using (var context = new SwuDBContext())
                {
                    data = context.Events
                        .Include(i => i.ApplicationUser)
                        .ToList();
                }
                return data;
            }
        }
        public void Add(Event entity)
        {
            this.context.Events.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(Event entity)
        {
            this.context.Events.Remove(entity);
            this.context.SaveChanges();
        }
        public void Update(Event entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.context.SaveChanges();

        }
        public Event FindById(int Id)
        {
            Event data = new Event();
            using (var context = new SwuDBContext())
            {
                data = context.Events
                    .Include(i => i.ApplicationUser)
                    .Where(i => i.Id == Id)
                    .FirstOrDefault();
            }
            return data;
        }
    }
}
