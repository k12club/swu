using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public interface IResearchService
    {
        void CreateNewResearch(Research research, string userId);
        void UpdateResearch(Research research, string userId, bool hasFile);
    }
    public class ResearchService : IResearchService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ResearchService()
        {
            this._userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SwuDBContext()));
        }
        public void CreateNewResearch(Research research, string userId)
        {
            using (var context = new SwuDBContext())
            {
                var category = context.ResearchCategory.Find(research.CategoryId);
                var creator = context.Users.Find(userId);
                context.Users.Attach(creator);
                research.ApplicationUser = creator;
                context.ResearchCategory.Attach(category);
                research.Category = category;
                context.Research.Add(research);
                context.SaveChanges();
            }
        }
        public void UpdateResearch(Research research, string userId, bool hasFile)
        {
            using (var context = new SwuDBContext())
            {
                var existing = context.Research
                    .Where(i => i.Id == research.Id).Include(i => i.AttachFiles)
                    .FirstOrDefault();
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
