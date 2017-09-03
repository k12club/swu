using Swu.Portal.Core.Dependencies;
using Swu.Portal.Data.Models;
using Swu.Portal.Data.Repository;
using Swu.Portal.Service;
using Swu.Portal.Web.Api;
using Swu.Portal.Web.Api.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace Swu.Portal.Web.Api.V1
{
    [RoutePrefix("V1/Role")]
    public class RoleController : ApiController
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }
        [HttpGet, Route("all")]
        public List<RoleProxy> GetAll()
        {
            var roles = this._roleRepository.Roles().Select(r=>new RoleProxy(r)).ToList();
            return roles;
        }
    }
}
