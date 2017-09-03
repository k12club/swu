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

namespace Swu.Portal.Data.Repository
{
    public interface IApplicationUserRepository
    {
        ApplicationUser VerifyAndGetUser(string username, string password);
        ApplicationUser GetUser(string username);
        bool AddNew(ApplicationUser user, string password, string selectedRoleName);
        List<ApplicationUser> GetAllUsers();
        List<string> GetRolesByUserName(string userName);
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
            addUserResult =  this._userManager.Create(user, password).Succeeded;
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
            return this._userManager.Users.ToList();
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

        public List<string> GetRolesByUserName(string userName)
        {
            var u = this._userManager.FindByName(userName);
            return this._userManager.GetRoles(u.Id).ToList();
        }
    }
}
