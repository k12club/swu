using Swu.Portal.Service;
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
    }
}