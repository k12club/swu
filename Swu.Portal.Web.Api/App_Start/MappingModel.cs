using AutoMapper;
using Swu.Portal.Data.Models;

namespace Swu.Portal.Web.Api.App_Start
{
    public partial class ApiStartUp
    {
        static void ConfigureModelMapping() {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ApplicationUser, UserLoginProxy>();
                cfg.CreateMap<UserLoginProxy, ApplicationUser>();
                cfg.CreateMap<ApplicationUser, UserProfile>();
                cfg.CreateMap<UserProfile, ApplicationUser>();
            });
        }

    }
}
