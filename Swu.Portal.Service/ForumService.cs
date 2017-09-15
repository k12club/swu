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
    public interface IForumService
    {
        void CreateNewPost(Forum forum, string userId);
        void UpdatePost(Forum forum, string userId);
    }
    public class ForumService : IForumService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ForumService()
        {
            this._userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SwuDBContext()));
        }
        public void CreateNewPost(Forum forum, string userId)
        {
            using (var context = new SwuDBContext()) {
                var category = context.ForumCategory.Find(forum.CategoryId);
                var creator = context.Users.Find(userId);
                context.Users.Attach(creator);
                forum.ApplicationUser = creator;
                context.ForumCategory.Attach(category);
                forum.Category = category;
                context.Forums.Add(forum);
                context.SaveChanges();
            }
        }

        public void UpdatePost(Forum forum, string userId)
        {
            using (var context = new SwuDBContext())
            {
                var existing = context.Forums.Find(forum.Id);
                var category = context.ForumCategory.Find(forum.CategoryId);
                existing.Name = forum.Name;
                existing.ShortDescription = forum.ShortDescription;
                existing.FullDescription = forum.FullDescription;
                existing.UpdatedDate = forum.UpdatedDate;
                context.ForumCategory.Attach(category);
                existing.Category = category;
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
