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
    public interface IMyUserStore : IUserStore<ApplicationUser>
    {
        Task<ApplicationUser> FindByFirstNameAndLastNameEN(string firstName, string lastName);
        Task<ApplicationUser> FindByFirstNameAndLastNameTH(string firstName, string lastName);

    }
    public class ApplicationUserStore<T> : UserStore<ApplicationUser>, IMyUserStore
    {
        public ApplicationUserStore(SwuDBContext context) : base(context)
        {

        }
        public override Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return Users
                .Include(i => i.Department)
                .Include(i => i.University)
                .Include(i => i.ReferenceUser)
                .Include(i => i.Roles)
                .FirstOrDefaultAsync(i => i.UserName == userName);
        }
        public virtual Task<ApplicationUser> FindByFirstNameAndLastNameEN(string firstName, string lastName)
        {
            return Users.FirstOrDefaultAsync(i => i.FirstName_EN.ToLower().Contains(firstName) && i.LastName_EN.ToLower().Contains(lastName));
        }
        public virtual Task<ApplicationUser> FindByFirstNameAndLastNameTH(string firstName, string lastName)
        {
            return Users.FirstOrDefaultAsync(i => i.FirstName_TH.ToLower().Contains(firstName) && i.LastName_TH.ToLower().Contains(lastName));
        }
    }
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> VerifyAndGetUser(string username, string password);
        ApplicationUser GetUser(string username);
        bool AddNew(ApplicationUser user, string password, string selectedRoleName);
        bool Update(ApplicationUser user, string selectedRoleName);
        List<ApplicationUser> GetAllUsers();
        List<string> GetRolesByUserName(string userName);
        ApplicationUser getById(string id);
        Task<ApplicationUser> VerifyWithCurrentUser(ApplicationUser user);
        Task<ApplicationUser> FindByNameAsync(string name);
        Task<ApplicationUser> FindByFirstNameAndLastNameEN(string firstName, string lastName);
        Task<ApplicationUser> FindByFirstNameAndLastNameTH(string firstName, string lastName);
        ApplicationUser FindById(string id);
    }
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMyUserStore _store;
        public ApplicationUserRepository()
        {
            //this._userManager = new UserManager<ApplicationUser>(
            //new UserStore<ApplicationUser>(
            //    new SwuDBContext()));
            this._store = new ApplicationUserStore<ApplicationUser>(new SwuDBContext());
            this._userManager = new UserManager<ApplicationUser>(this._store);
        }
        public bool AddNew(ApplicationUser user, string password, string selectedRoleName)
        {
            var addUserResult = false;
            var addToRoleResult = false;
            addUserResult = this._userManager.Create(user, password).Succeeded;
            if (addUserResult)
            {
                if (!string.IsNullOrWhiteSpace(selectedRoleName))
                {
                    var u = this._userManager.FindByName(user.UserName);
                    addToRoleResult = this._userManager.AddToRole(u.Id, selectedRoleName).Succeeded;
                }
                else {
                    addToRoleResult = true;
                }
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
                .Include(i => i.Roles).ToList();
        }
        public async Task<ApplicationUser> VerifyAndGetUser(string username, string password)
        {
            //var user = this._userManager.FindByName(username);
            var user = await this._userManager.FindByNameAsync(username);
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
        public async Task<ApplicationUser> VerifyWithCurrentUser(ApplicationUser user)
        {
            var u = await this._userManager.FindByNameAsync(user.UserName);
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
            u.Description_EN = user.Description_EN;

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
        public Task<ApplicationUser> FindByNameAsync(string name)
        {
            return this._userManager.FindByNameAsync(name);
        }
        public Task<ApplicationUser> FindByFirstNameAndLastNameEN(string firstName, string lastName)
        {
            return this._store.FindByFirstNameAndLastNameEN(firstName, lastName);
        }
        public Task<ApplicationUser> FindByFirstNameAndLastNameTH(string firstName, string lastName)
        {
            return this._store.FindByFirstNameAndLastNameTH(firstName, lastName);
        }

        public ApplicationUser FindById(string id)
        {
            return this._userManager.FindById(id);
        }
    }
}
