using Swu.Portal.Data.Context;
using Swu.Portal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Swu.Portal.Data.Repository;
using Swu.Portal.Data.Models;

namespace Swu.Portal.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IApplicationUserServices applicationUserServices, IRepository2<Course> courseRepository)
        {
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}