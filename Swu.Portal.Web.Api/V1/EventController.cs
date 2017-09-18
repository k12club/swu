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
    [RoutePrefix("V1/event")]
    public class EventController : ApiController
    {
        private readonly IDateTimeRepository _datetimeRepository;
        private readonly IRepository<Event> _eventRepository;
        public EventController(IDateTimeRepository datetimeRepository, IRepository<Event> eventRepository)
        {
            this._datetimeRepository = datetimeRepository;
            this._eventRepository = eventRepository;
        }
        [HttpGet, Route("all")]
        public List<EventProxy> GetAll()
        {
            return this._eventRepository.List.Select(i => new EventProxy(i)).ToList();
        }
    }
}
