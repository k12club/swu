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
        ApplicationUser VerifyAndGetUser(string username,string password);
        bool AddNewUser(ApplicationUser user ,string password,string selectedRoleName);
        List<ApplicationUser> GetAllUsers();
        List<string> GetRolesByUserName(string userName);
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

        public List<ApplicationUser> GetAllUsers()
        {
            return this._applicationUserRepository.GetAllUsers();
        }

        public List<string> GetRolesByUserName(string userName)
        {
            return this._applicationUserRepository.GetRolesByUserName(userName);
        }

        public ApplicationUser GetUser(string username)
        {
            return this._applicationUserRepository.GetUser(username);

        }
        public ApplicationUser VerifyAndGetUser(string username, string password)
        {
            return this._applicationUserRepository.VerifyAndGetUser(username, password);
        }
    }
}
