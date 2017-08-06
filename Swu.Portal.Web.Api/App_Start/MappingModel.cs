using AutoMapper;
using Swu.Portal.Data.Models;
using Swu.Portal.Web.Api.Proxy;

namespace Swu.Portal.Web.Api.App_Start
{
    public partial class ApiStartUp
    {
        static void ConfigureModelMapping() {
            Mapper.Initialize(cfg => {
                //cfg.CreateMap<PersonalTestData, PersonalTestDataProxy>();
                //cfg.CreateMap<PersonalTestDataProxy, PersonalTestData>();
            });
        }

    }
}
