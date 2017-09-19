using Swu.Portal.Core.Dependencies;
using Swu.Portal.Data.Models;
using Swu.Portal.Data.Repository;
using Swu.Portal.Service;
using Swu.Portal.Web.Api;
using Swu.Portal.Web.Api.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        private readonly IConfigurationRepository _configurationRepository;
        public EventController(IDateTimeRepository datetimeRepository, IRepository<Event> eventRepository, IConfigurationRepository configurationRepository)
        {
            this._datetimeRepository = datetimeRepository;
            this._eventRepository = eventRepository;
            this._configurationRepository = configurationRepository;
        }
        [HttpGet, Route("all")]
        public List<EventProxy> GetAll()
        {
            return this._eventRepository.List.Select(i => new EventProxy(i)).ToList();
        }
        [HttpGet, Route("allEvents")]
        public List<EventProxy> GetAllEvents()
        {
            return this._eventRepository.List.Select(e => new EventProxy(e)).ToList();
        }
        [HttpGet, Route("getEventById")]
        public EventProxy GetEventById(int id)
        {
            return new EventProxy(this._eventRepository.FindById(id));
        }
        [HttpPost, Route("addNewOrUpdate")]
        public HttpResponseMessage AddNewOrUpdate(EventProxy model)
        {
            try
            {
                if (model.Id == 0)
                {
                    this._eventRepository.Add(new Event
                    {
                        Title_EN = model.Title_EN,
                        Title_TH = model.Title_TH,
                        Description_EN = model.Description_EN,
                        Description_TH = model.Description_TH,
                        Place_EN = model.Place_EN,
                        Place_TH = model.Place_TH,
                        StartDate = model.StartDate
                    });
                }
                else
                {
                    var e = this._eventRepository.FindById(model.Id);
                    e.Title_EN = model.Title_EN;
                    e.Title_TH = model.Title_TH;
                    e.Description_EN = model.Description_EN;
                    e.Description_TH = model.Description_TH;
                    e.Place_EN = model.Place_EN;
                    e.Place_TH = model.Place_TH;
                    e.StartDate = model.StartDate;
                    this._eventRepository.Update(e);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [HttpGet, Route("deleteById")]
        public HttpResponseMessage DeleteById(int id)
        {
            try
            {
                var e = this._eventRepository.FindById(id);
                this._eventRepository.Delete(e);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
