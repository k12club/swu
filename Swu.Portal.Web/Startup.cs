using Microsoft.Owin;
using Owin;
using Swu.Portal.Web.Api.App_Start;

[assembly: OwinStartupAttribute(typeof(Swu.Portal.Web.Startup))]
namespace Swu.Portal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureApp(app);
            ConfigureAuth(app);
            ApiStartUp.ConfigureApi();
        }
    }
}
