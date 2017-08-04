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
        private readonly IPersonalTestDataServices _personalTestServices;
        public HomeController(IPersonalTestDataServices personalTestServices)
        {
            this._personalTestServices = personalTestServices;
        }
        public ActionResult Index()
        {
            var result = this._personalTestServices.GetAllData();
            return View();
        }
        public ActionResult Personal() {
            return View();
        }
    }
}