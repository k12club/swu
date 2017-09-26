using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Data.Entity;

namespace Swu.Portal.Data.Repository
{
    public interface IApplicationUserRepository
    {
        ApplicationUser VerifyAndGetUser(string username, string password);
        ApplicationUser GetUser(string username);
        bool AddNew(ApplicationUser user, string password, string selectedRoleName);
        bool Update(ApplicationUser user, string selectedRoleName);
        List<ApplicationUser> GetAllUsers();
        List<string> GetRolesByUserName(string userName);
        ApplicationUser getById(string id);
        ApplicationUser VerifyWithCurrentUser(ApplicationUser user);
    }
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserRepository()
        {
            this._userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(
                new SwuDBContext()));
        }

        public bool AddNew(ApplicationUser user, string password, string selectedRoleName)
        {
            var addUserResult = false;
            var addToRoleResult = false;
            addUserResult = this._userManager.Create(user, password).Succeeded;
            if (addUserResult)
            {
                var u = this._userManager.FindByName(user.UserName);
                addToRoleResult = this._userManager.AddToRole(u.Id, selectedRoleName).Succeeded;
            }
            return addUserResult && addToRoleResult;
        }

        public ApplicationUser GetUser(string username)
        {
            var user = this._userManager.FindByName(username);
            return user;
        }

        public List<ApplicationUser> GetAllUsers()
        {
            return this._userManager.Users
                .Include(i=>i.Roles).ToList();
        }

        public ApplicationUser VerifyAndGetUser(string username, string password)
        {
            var user = this._userManager.FindByName(username);
            var passwordHasher = new PasswordHasher();
            if (passwordHasher.VerifyHashedPassword(user.PasswordHash, password) != PasswordVerificationResult.Failed)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public ApplicationUser VerifyWithCurrentUser(ApplicationUser user) {
            var u =  this._userManager.FindByName(user.UserName);
            return u;
        }

        public List<string> GetRolesByUserName(string userName)
        {
            var u = this._userManager.FindByName(userName);
            return this._userManager.GetRoles(u.Id).ToList();
        }

        public ApplicationUser getById(string id)
        {
            return this._userManager.FindById(id);
        }

        public bool Update(ApplicationUser user, string selectedRoleName)
        {
            var updateUserResult = false;
            var updateRoleResult = false;
            var u = this._userManager.FindByName(user.UserName);
            u.Email = user.Email;
            u.UpdatedDate = user.UpdatedDate;
            u.ImageUrl = user.ImageUrl;

            u.FirstName_EN = user.FirstName_EN;
            u.LastName_EN = user.LastName_EN;
            u.Position_EN = user.Position_EN;
            u.Tag_EN = user.Tag_EN;
            u.Description_EN = u.Description_EN;

            u.FirstName_TH = user.FirstName_TH;
            u.LastName_TH = user.LastName_TH;
            u.Position_TH = user.Position_TH;
            u.Tag_TH = user.Tag_TH;
            u.Description_TH = user.Description_TH;


            updateUserResult = this._userManager.Update(u).Succeeded;
            if (updateUserResult)
            {
                var roles = this._userManager.GetRoles(u.Id);
                foreach (var role in roles)
                {
                    this._userManager.RemoveFromRole(u.Id, role);
                }
                updateRoleResult = this._userManager.AddToRole(u.Id, selectedRoleName).Succeeded;
            }
            return updateUserResult && updateRoleResult;
        }
    }
}
