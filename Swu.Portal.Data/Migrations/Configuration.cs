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
            var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(
                    new SwuDBContext()));
            manager.Create(new ApplicationUser
            {
                UserName = "chansak",
                FirstName = "chansak",
                LastName = "kochasen"
            }, "password");
        }
    }
}
