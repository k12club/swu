using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Service
{
    public interface IReferenceUserService {
        void AddOrUpdateUserReference(ApplicationUser child, string parentId);
        ReferenceUser GetReferenceUserByChildId(string childId);
        ReferenceUser GetReferenceUserByParentId(string parentId);
        void ApproveRequest(string childId, string parentId);
        void RejectRequest(string childId, string parentId);
    }
    public class ReferenceUserService : IReferenceUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ReferenceUserService()
        {
            this._userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SwuDBContext()));
        }
        public void AddOrUpdateUserReference(ApplicationUser child, string parentId)
        {
            using (var context = new SwuDBContext())
            {
                var parent = this._userManager.FindById(parentId);
                var existing = context.ReferenceUser.Where(i => i.ParentId == parentId && i.ChildId == child.Id).FirstOrDefault();
                if (existing == null)
                {
                    context.Users.Attach(parent);
                    context.Users.Attach(child);
                    context.ReferenceUser.Add(new ReferenceUser
                    {
                        Parent = parent,
                        Child = child,
                        Approved = false
                    });
                    context.SaveChanges();
                }
                else {
                    context.Users.Attach(parent);
                    context.Users.Attach(child);
                    existing.Child = child;
                    context.Entry(existing).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public ReferenceUser GetReferenceUserByChildId(string childId)
        {
            using (var context = new SwuDBContext()) {
                return context.ReferenceUser.Where(i => i.ChildId == childId).FirstOrDefault();
            }
        }

        public ReferenceUser GetReferenceUserByParentId(string parentId)
        {
            using (var context = new SwuDBContext())
            {
                return context.ReferenceUser.Where(i => i.ParentId == parentId).FirstOrDefault();
            }
        }

        public void ApproveRequest(string childId, string parentId)
        {
            using (var context = new SwuDBContext())
            {
                var existing = context.ReferenceUser.Where(i => i.ParentId == parentId && i.ChildId == childId).FirstOrDefault();
                existing.Approved = true;
                context.Entry(existing).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void RejectRequest(string childId, string parentId)
        {
            using (var context = new SwuDBContext())
            {
                var existing = context.ReferenceUser.Where(i => i.ParentId == parentId && i.ChildId == childId).FirstOrDefault();
                context.ReferenceUser.Remove(existing);
                context.SaveChanges();
            }
        }
    }
}
