using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using Swu.Portal.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Service
{
    public interface IApplicationUserServices
    {
        ApplicationUser GetUser(string username);
        Task<ApplicationUser> VerifyAndGetUser(string username,string password);
        bool AddNewUser(ApplicationUser user ,string password,string selectedRoleName);
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
    public class ApplicationUserServices : IApplicationUserServices
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        public ApplicationUserServices(IApplicationUserRepository applicationUserRepository)
        {
            this._applicationUserRepository = applicationUserRepository;
        }

        public bool AddNewUser(ApplicationUser user, string password, string selectedRoleName)
        {
            return this._applicationUserRepository.AddNew(user, password,selectedRoleName);
        }

        public Task<ApplicationUser> FindByFirstNameAndLastNameEN(string firstName, string lastName)
        {
            return this._applicationUserRepository.FindByFirstNameAndLastNameEN(firstName, lastName);
        }

        public Task<ApplicationUser> FindByFirstNameAndLastNameTH(string firstName, string lastName)
        {
            return this._applicationUserRepository.FindByFirstNameAndLastNameTH(firstName, lastName);
        }

        public ApplicationUser FindById(string id)
        {
            return this._applicationUserRepository.FindById(id);
        }

        public Task<ApplicationUser> FindByNameAsync(string name)
        {
            return this._applicationUserRepository.FindByNameAsync(name);
        }

        public List<ApplicationUser> GetAllUsers()
        {
            return this._applicationUserRepository.GetAllUsers();
        }

        public ApplicationUser getById(string id)
        {
            return this._applicationUserRepository.getById(id);
        }

        public List<string> GetRolesByUserName(string userName)
        {
            return this._applicationUserRepository.GetRolesByUserName(userName);
        }

        public ApplicationUser GetUser(string username)
        {
            return this._applicationUserRepository.GetUser(username);

        }

        public bool Update(ApplicationUser user, string selectedRoleName)
        {
            return this._applicationUserRepository.Update(user, selectedRoleName);
        }

        public Task<ApplicationUser> VerifyAndGetUser(string username, string password)
        {
            return this._applicationUserRepository.VerifyAndGetUser(username, password);
        }

        public Task<ApplicationUser> VerifyWithCurrentUser(ApplicationUser user)
        {
            return this._applicationUserRepository.VerifyWithCurrentUser(user);
        }
    }
}
