using Swu.Portal.Web.Controllers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Swu.Portal.Web.Controllers
{
    public abstract class BaseController : System.Web.Mvc.Controller
    {
        protected override JsonResult Json(object data,
            string contentType,
            System.Text.Encoding contentEncoding,
            JsonRequestBehavior behavior)
        {
            return new JsonDotNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
    }
}