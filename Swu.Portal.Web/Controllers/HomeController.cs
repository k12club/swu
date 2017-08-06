using Swu.Portal.Service;
using Swu.Portal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Swu.Portal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationUserServices _applicationUserServices;
        public HomeController(IApplicationUserServices applicationUserServices)
        {
            this._applicationUserServices = applicationUserServices;
        }
        public ActionResult Index()
        {
            return View();
        }
        // POST: /Account/JsonLogin
        [AllowAnonymous]
        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public JsonResult JsonLogin(LoginViewModel model)
        {
            //mockup data:
            //username:chansak
            //password:password
            if (ModelState.IsValid)
            {
                var user = this._applicationUserServices.VerifyAndGetUser(model.UserName, model.Password);
            }
            return Json(null);
        }
    }
}