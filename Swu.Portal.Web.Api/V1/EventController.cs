using Swu.Portal.Core.Dependencies;
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
        public EventController(IDateTimeRepository datetimeRepository)
        {
            this._datetimeRepository = datetimeRepository;
        }
        [HttpGet, Route("all")]
        public List<EventProxy> GetAll()
        {
            return new List<EventProxy>
            {
                new EventProxy {
                    Title_EN="War and Medicine- Lunchtime Talks Series",
                    Description_EN="On the last Friday of every month at lunchtime (13.00) there will be a series of talks examining the effect of the First World War on medicine.",
                    Place_EN="Venue: Hall B",
                    Title_TH="ทดสอบทดสอบทดสอบทดสอบ",
                    Description_TH="ทดสอบทดสอบทดสอบทดสอบ",
                    Place_TH="ทดสอบ",
                    ImageUrl="images/event/1.jpg",
                    StartDate=this._datetimeRepository.Now().AddDays(2)
                },
                new EventProxy {
                    Title_EN="War and Medicine- Lunchtime Talks Series",
                    Description_EN="On the last Friday of every month at lunchtime (13.00) there will be a series of talks examining the effect of the First World War on medicine.",
                    Place_EN="Venue: Hall B",
                    Title_TH="ทดสอบทดสอบทดสอบทดสอบ",
                    Description_TH="ทดสอบทดสอบทดสอบทดสอบ",
                    Place_TH="ทดสอบ",
                    ImageUrl="images/event/1.jpg",
                    StartDate=this._datetimeRepository.Now().AddDays(2)
                },
                new EventProxy {
                    Title_EN="War and Medicine- Lunchtime Talks Series",
                    Description_EN="On the last Friday of every month at lunchtime (13.00) there will be a series of talks examining the effect of the First World War on medicine.",
                    Place_EN="Venue: Hall B",
                    Title_TH="ทดสอบทดสอบทดสอบทดสอบ",
                    Description_TH="ทดสอบทดสอบทดสอบทดสอบ",
                    Place_TH="ทดสอบ",
                    ImageUrl="images/event/1.jpg",
                    StartDate=this._datetimeRepository.Now().AddDays(2)
                },
                new EventProxy {
                    Title_EN="War and Medicine- Lunchtime Talks Series",
                    Description_EN="On the last Friday of every month at lunchtime (13.00) there will be a series of talks examining the effect of the First World War on medicine.",
                    Place_EN="Venue: Hall B",
                    Title_TH="ทดสอบทดสอบทดสอบทดสอบ",
                    Description_TH="ทดสอบทดสอบทดสอบทดสอบ",
                    Place_TH="ทดสอบ",
                    ImageUrl="images/event/1.jpg",
                    StartDate=this._datetimeRepository.Now().AddDays(2)
                }
            };
        }
    }
}
