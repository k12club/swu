using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Security;
using Owin;
using Swu.Portal.Core;
using Swu.Portal.Core.Dependencies;
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

            builder.RegisterType<ApplicationUserServices>().As<IApplicationUserServices>().InstancePerRequest();
            builder.RegisterType<ApplicationUserRepository>().As<IApplicationUserRepository>().InstancePerRequest();
            builder.RegisterType<DateTimeRepository>().As<IDateTimeRepository>().InstancePerRequest();
            builder.RegisterType<CourseRepository>().As<IRepository2<Course>>().InstancePerRequest();
            builder.RegisterType<PhotoAlbumRepository>().As<IRepository2<PhotoAlbum>>().InstancePerRequest();
            builder.RegisterType<CourseCategoryRepository>().As<IRepository<CourseCategory>>().InstancePerRequest();
            builder.RegisterType<ForumRepository>().As<IRepository2<Forum>>().InstancePerRequest();
            builder.RegisterType<ForumCategoryRepository>().As<IRepository<ForumCategory>>().InstancePerRequest();

            builder.RegisterApiControllers(typeof(ApiStartUp).Assembly);
            builder.RegisterControllers(typeof(Startup).Assembly);

            var container = builder.Build();

            app.UseAutofacMiddleware(container);
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new Autofac.Integration.Mvc.AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Autofac.Integration.WebApi.AutofacWebApiDependencyResolver(container);

        }
    }
}