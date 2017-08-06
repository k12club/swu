using System.Data.Entity.Migrations;
using Swu.Portal.Data.Context;
using Swu.Portal.Data.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Security;

namespace Swu.Portal.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Swu.Portal.Data.Context.SwuDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(SwuDBContext context)
        {
            //var manager = new UserManager<ApplicationUser>(
            //    new UserStore<ApplicationUser>(
            //        new SwuDBContext()));

            //// Create 4 test users:
            //for (int i = 0; i < 4; i++)
            //{
            //    var user = new ApplicationUser()
            //    {
            //        UserName = string.Format("User{0}", i.ToString())
            //    };
            //    manager.Create(user, string.Format("Password{0}", i.ToString()));
            //}
        }
    }
}
