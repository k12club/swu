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
    public interface INewsService
    {
        void CreateNewNews(News e, string creatorId);
        void UpdateNews(News e, string creatorId);
    }
    public class NewsService : INewsService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public NewsService()
        {
            this._userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SwuDBContext()));
        }
        public void CreateNewNews(News n, string creatorId)
        {
            using (var context = new SwuDBContext())
            {
                var creator = this._userManager.FindById(creatorId);
                context.Users.Attach(creator);
                n.ApplicationUser = creator;
                context.News.Add(n);
                context.SaveChanges();
            }
        }
        public void UpdateNews(News n, string creatorId)
        {
            using (var context = new SwuDBContext())
            {
                var creator = this._userManager.FindById(creatorId);
                var existing = context.News
                    .Where(i => i.Id == n.Id)
                    .FirstOrDefault();
                context.Users.Attach(creator);
                existing.ApplicationUser = creator;
                existing.Title_EN = n.Title_EN;
                existing.Title_TH = n.Title_TH;
                if (string.IsNullOrEmpty(n.ImageUrl))
                {
                    existing.ImageUrl = n.ImageUrl;
                }
                existing.StartDate = n.StartDate;
                existing.FullDescription_EN = n.FullDescription_EN;
                existing.FullDescription_TH = n.FullDescription_TH;
                existing.StartDate = n.StartDate;
                existing.IsActive = n.IsActive;
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
