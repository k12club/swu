using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Service
{
    public interface IEventService
    {
        void CreateNewEvent(Event e);
        void UpdateEvent(Event e);
    }
    public class EventService : IEventService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public EventService()
        {
            this._userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SwuDBContext()));
        }
        public void CreateNewEvent(Event e)
        {
            using (var context = new SwuDBContext())
            {
                context.Events.Add(e);
                context.SaveChanges();
            }
        }
        public void UpdateEvent(Event e)
        {
            using (var context = new SwuDBContext())
            {
                var existing = context.Events
                    .Where(i => i.Id == e.Id)
                    .FirstOrDefault();
                existing.Title_EN = e.Title_EN;
                existing.Title_TH = e.Title_TH;
                existing.Description_EN = e.Description_EN;
                existing.Description_TH = e.Description_TH;
                existing.Place_EN = e.Place_EN;
                existing.Place_TH = e.Place_TH;
                existing.StartDate = e.StartDate;
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
