﻿using Swu.Portal.Data.Context;
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
