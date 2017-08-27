using Swu.Portal.Data.Context;
using Swu.Portal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
            #if DEBUG
            using (var db = new SwuDBContext())
            {
                var courses = db.Courses
                    .Include(i => i.Category)
                    .Include(i=>i.Curriculums)
                    .Include(i=>i.Students)
                    .Include(i=>i.Teachers)
                    .ToList();
            }
            #endif
            return View();
        }
    }
}