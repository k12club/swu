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
    [RoutePrefix("V1/News")]
    public class NewsController : ApiController
    {
        private readonly IDateTimeRepository _datetimeRepository;
        public NewsController(IDateTimeRepository datetimeRepository)
        {
            this._datetimeRepository = datetimeRepository;
        }
        [HttpGet, Route("all")]
        public List<NewsProxy> GetAll()
        {
            if (ModelState.IsValid)
            {
                return new List<NewsProxy>
                {
                    new NewsProxy {
                        Title_EN="Students recreate 5,000-year-old Chinese beer recipe",
                        Title_TH="ทดสอบทดสอบทดสอบทดสอบ",
                        ImageUrl="Content/images/blog/1.jpg",
                        CreatedBy="chansak kochasen",
                        StartDate=this._datetimeRepository.Now().AddDays(1)
                    },
                    new NewsProxy {
                        Title_EN="Students recreate 5,000-year-old Chinese beer recipe",
                        Title_TH="ทดสอบทดสอบทดสอบทดสอบ",
                        ImageUrl="Content/images/blog/1.jpg",
                        CreatedBy="chansak kochasen",
                        StartDate=this._datetimeRepository.Now().AddDays(1)
                    },
                    new NewsProxy {
                        Title_EN="Students recreate 5,000-year-old Chinese beer recipe",
                        Title_TH="ทดสอบทดสอบทดสอบทดสอบ",
                        ImageUrl="Content/images/blog/1.jpg",
                        CreatedBy="chansak kochasen",
                        StartDate=this._datetimeRepository.Now().AddDays(1)
                    },
                    new NewsProxy {
                        Title_EN="Students recreate 5,000-year-old Chinese beer recipe",
                        Title_TH="ทดสอบทดสอบทดสอบทดสอบ",
                        ImageUrl="Content/images/blog/1.jpg",
                        CreatedBy="chansak kochasen",
                        StartDate=this._datetimeRepository.Now().AddDays(1)
                    },
                };
            }
            return null;
        }
    }
}
