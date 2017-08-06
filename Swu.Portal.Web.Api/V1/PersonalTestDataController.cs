using System.Collections.Generic;
using System.Web.Http;
using Swu.Portal.Data.Models;
using Swu.Portal.Web.Api.Proxy;
using AutoMapper;
using System;
using Swu.Portal.Web.Api.Extensions;

namespace Swu.Portal.Web.Api.V1
{
    //[Authorize]
    [RoutePrefix("V1/PersonalTestData")]
    public class PersonalTestDataController : ApiController
    {
        //private readonly IPersonalTestDataServices _service;
        //public PersonalTestDataController(IPersonalTestDataServices service)
        //{
        //    this._service = service;
        //}

        //[HttpGet, Route("getAllData")]
        //public IHttpActionResult GetAllData()
        //{
        //    var ret = this._service.GetAllData();
        //    return Json(ret.ToViewModel());
        //}
    }
}