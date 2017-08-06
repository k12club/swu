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
    }
    public class ApplicationUserServices : IApplicationUserServices
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        public ApplicationUserServices(IApplicationUserRepository applicationUserRepository)
        {
            this._applicationUserRepository = applicationUserRepository;
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
