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
    [RoutePrefix("V1/video")]
    public class VideoController : ApiController
    {
        private readonly IDateTimeRepository _datetimeRepository;
        private readonly IRepository<Video> _videoRepository;
        public VideoController(IDateTimeRepository datetimeRepository, IRepository<Video> videoRepository)
        {
            this._datetimeRepository = datetimeRepository;
            this._videoRepository = videoRepository;
        }
        [HttpGet, Route("all")]
        public List<VideoProxy> GetAll()
        {
            return this._videoRepository.List.Select(i => new VideoProxy(i)).ToList();
        }
    }
}
