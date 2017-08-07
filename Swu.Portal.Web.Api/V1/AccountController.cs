using Swu.Portal.Service;
using Swu.Portal.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Swu.Portal.Web.Api
{
    [RoutePrefix("V1/Account")]
    public class AccountController : ApiController
    {
        private readonly IApplicationUserServices _applicationUserServices;
        public AccountController(IApplicationUserServices applicationUserServices)
        {
            this._applicationUserServices = applicationUserServices;
        }
        [HttpPost, Route("login")]
        public UserProfile Login(UserLoginProxy model)
        {

            //mockup data:
            //username:chansak
            //password:password
            if (ModelState.IsValid)
            {
                var user = this._applicationUserServices.VerifyAndGetUser(model.UserName, model.Password);
                return user.ToUserProfileViewModel();
            }
            return null;
        }
    }
}
