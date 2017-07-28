using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Security;
using Owin;
using Swu.Portal.Data.Models;
using Swu.Portal.Data.Repository;
using Swu.Portal.Service;
using Swu.Portal.Web.Api.App_Start;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace Swu.Portal.Web
{
    public partial class Startup
    {
        public static void ConfigureApp(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>().InstancePerRequest();

            builder.RegisterType<PersonalTestDataServices>().As<IPersonalTestDataServices>().InstancePerRequest();
            builder.RegisterType<PersonalTestDataRepository>().As<IRepository<PersonalTestData>>().InstancePerRequest();

            // Register your Web API controllers.
            builder.RegisterApiControllers(typeof(ApiStartUp).Assembly);
            // Register mvc controllers
            builder.RegisterControllers(typeof(Startup).Assembly);

            var container = builder.Build();

            app.UseAutofacMiddleware(container);
            // set resolver for web api
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // set resolver for mvc
            DependencyResolver.SetResolver(new Autofac.Integration.Mvc.AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Autofac.Integration.WebApi.AutofacWebApiDependencyResolver(container);

        }
    }
}