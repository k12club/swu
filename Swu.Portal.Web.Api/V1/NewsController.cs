using Swu.Portal.Core.Dependencies;
using Swu.Portal.Data.Models;
using Swu.Portal.Data.Repository;
using Swu.Portal.Service;
using Swu.Portal.Web.Api;
using Swu.Portal.Web.Api.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Swu.Portal.Web.Api
{
    [RoutePrefix("V1/News")]
    public class NewsController : ApiController
    {
        private readonly IDateTimeRepository _datetimeRepository;
        private readonly IRepository<News> _newsRepository;

        public NewsController(IDateTimeRepository datetimeRepository, IRepository<News> newsRepository)
        {
            this._datetimeRepository = datetimeRepository;
            this._newsRepository = newsRepository;
        }
        [HttpGet, Route("all")]
        public List<NewsProxy> GetAll()
        {
            return this._newsRepository.List.Select(i => new NewsProxy(i)).ToList();
        }
    }
}
