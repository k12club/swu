using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Swu.Portal.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Data.Repository
{
    public interface IRoleRepository {
        List<IdentityRole> Roles();
    }
    public class RoleRepository :IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleRepository()
        {
            this._roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new SwuDBContext()));
        }

        public List<IdentityRole> Roles()
        {
            return this._roleManager.Roles.ToList();
        }
    }
}
