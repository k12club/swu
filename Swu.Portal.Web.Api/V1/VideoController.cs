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
                        Title_EN="Campus Life",
                        Title_TH="การใช้ชีวิต"
                    },
                    new VideoProxy {
                        ImageUrl="Content/images/campus/2.jpg",
                        VideoUrl="https://www.youtube.com/watch?v=PvXZKSumtk8",
                        Title_EN="Interview",
                        Title_TH="สัมภาษณ์"
                    },
                    new VideoProxy {
                        ImageUrl="Content/images/campus/3.jpg",
                        VideoUrl="https://www.youtube.com/watch?v=JxvrkpMRk4o",
                        Title_EN="Job fair",
                        Title_TH="หางาน"
                    },
                    new VideoProxy {
                        ImageUrl="Content/images/campus/4.jpg",
                        VideoUrl="https://www.youtube.com/watch?v=1GaMGdOQLvg",
                        Title_EN="Sport day",
                        Title_TH="กีฬาสี"
                    },
                };
            }
            return null;
        }
    }
}
