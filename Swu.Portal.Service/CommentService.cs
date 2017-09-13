using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SharpRepository.Repository;
using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Service
{
    public interface ICommentService
    {
        void Post(Comment comment, string userId);
    }
    public class CommentService : ICommentService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public CommentService()
        {
            this._userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SwuDBContext()));
        }
        public void Post(Comment comment, string userId)
        {
            using (var context = new SwuDBContext())
            {
                var creator = this._userManager.FindById(userId);
                context.Users.Attach(creator);
                comment.ApplicationUser = creator;
                context.Comments.Add(comment);
                context.SaveChanges();
            }
        }
    }
}
