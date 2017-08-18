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
        public VideoController()
        {
        }
        [HttpGet, Route("all")]
        public List<VideoProxy> GetAll()
        {
            if (ModelState.IsValid)
            {
                return new List<VideoProxy> {
                    new VideoProxy {
                        ImageUrl="Content/images/campus/1.jpg",
                        VideoUrl="https://www.youtube.com/watch?v=hYEnh4LuruQ",
                        Title_EN="Details On Hover Title",
                        Title_TH="ทดสอบทดสอบทดสอบ"
                    },
                    new VideoProxy {
                        ImageUrl="Content/images/campus/1.jpg",
                        VideoUrl="https://www.youtube.com/watch?v=hYEnh4LuruQ",
                        Title_EN="Details On Hover Title",
                        Title_TH="ทดสอบทดสอบทดสอบ"
                    },
                    new VideoProxy {
                        ImageUrl="Content/images/campus/1.jpg",
                        VideoUrl="https://www.youtube.com/watch?v=hYEnh4LuruQ",
                        Title_EN="Details On Hover Title",
                        Title_TH="ทดสอบทดสอบทดสอบ"
                    },
                    new VideoProxy {
                        ImageUrl="Content/images/campus/1.jpg",
                        VideoUrl="https://www.youtube.com/watch?v=hYEnh4LuruQ",
                        Title_EN="Details On Hover Title",
                        Title_TH="ทดสอบทดสอบทดสอบ"
                    },
                };
            }
            return null;
        }
    }
}
