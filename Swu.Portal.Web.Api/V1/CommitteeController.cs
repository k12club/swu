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
    [RoutePrefix("V1/committee")]
    public class CommitteeController : ApiController
    {
        private readonly IDateTimeRepository _datetimeRepository;
        public CommitteeController(IDateTimeRepository datetimeRepository)
        {
            this._datetimeRepository = datetimeRepository;
        }
        [HttpGet, Route("all")]
        public List<CommitteeProxy> GetAll()
        {
            return new List<CommitteeProxy> {
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/tmd1.png",
                    Name = "Prof.Chairat Neruntarat",
                    Position = "Advisory Board",
                    Description = "Dean, Faculty of Medicine",
                    Phone = "(012) 345 - 6789",
                    Room="Room 129",
                    Email="edward.wallen@edu-hub.com"
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/tsm2.png",
                    Name = "Prof.Chairat Neruntarat",
                    Position = "Advisory Board",
                    Description = "Dean, Faculty of Medicine",
                    Phone = "(012) 345 - 6789",
                    Room="Room 129",
                    Email="edward.wallen@edu-hub.com"
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/tsm3.png",
                    Name = "Prof.Chairat Neruntarat",
                    Position = "Advisory Board",
                    Description = "Dean, Faculty of Medicine",
                    Phone = "(012) 345 - 6789",
                    Room="Room 129",
                    Email="edward.wallen@edu-hub.com"
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/tsm3.png",
                    Name = "Prof.Chairat Neruntarat",
                    Position = "Advisory Board",
                    Description = "Dean, Faculty of Medicine",
                    Phone = "(012) 345 - 6789",
                    Room="Room 129",
                    Email="edward.wallen@edu-hub.com"
                }
            };
        }
    }
}
