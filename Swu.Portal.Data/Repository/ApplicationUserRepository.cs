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

        public ApplicationUser GetUser(string username)
        {
            var user = this._userManager.FindByName(username);
            return user;
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
    }
}
