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
                    Title_TH="รับสมัคร",
                    Description_TH="",
                    Place_TH="http://admission.swu.acth",
                    ImageUrl="images/event/1.jpg",
                    StartDate= new DateTime(2017,8,14,9,0,0).ToUniversalTime()
                },
                new EventProxy {
                    Title_EN="War and Medicine- Lunchtime Talks Series",
                    Description_EN="On the last Friday of every month at lunchtime (13.00) there will be a series of talks examining the effect of the First World War on medicine.",
                    Place_EN="Venue: Hall B",
                    Title_TH="ประกาศรายชื่อผู้มีสิทธิ์สอบ",
                    Description_TH="",
                    Place_TH="http://admission.swu.acth",
                    ImageUrl="images/event/1.jpg",
                    StartDate=new DateTime(2017,8,24,9,30,0).ToUniversalTime()
                },
                new EventProxy {
                    Title_EN="War and Medicine- Lunchtime Talks Series",
                    Description_EN="On the last Friday of every month at lunchtime (13.00) there will be a series of talks examining the effect of the First World War on medicine.",
                    Place_EN="Venue: Hall B",
                    Title_TH="สอบคัดเลือก 1",
                    Description_TH=@"09.00-12.00 วิทยาศาสตร์พื้นฐาน
13.00-15.00 ความถนัดทางการเรียน
คณะแพทย์ศาตร์ มศว ประสานมิตร กรุงเทพฯ",
                    Place_TH="คณะแพทย์ศาตร์ มศว ประสานมิตร กรุงเทพฯ",
                    ImageUrl="images/event/1.jpg",
                    StartDate=new DateTime(2018,1,10,9,0,0).ToUniversalTime()
                },
                new EventProxy {
                    Title_EN="War and Medicine- Lunchtime Talks Series",
                    Description_EN="On the last Friday of every month at lunchtime (13.00) there will be a series of talks examining the effect of the First World War on medicine.",
                    Place_EN="Venue: Hall B",
                    Title_TH="ประกาศการสอบขั้นที่ 1",
                    Description_TH="",
                    Place_TH="คณะแพทย์ศาตร์ มศว ประสานมิตร กรุงเทพฯ",
                    ImageUrl="images/event/1.jpg",
                    StartDate = new DateTime(2018,1,21,9,0,0).ToUniversalTime()
                },
                new EventProxy {
                    Title_EN="War and Medicine- Lunchtime Talks Series",
                    Description_EN="On the last Friday of every month at lunchtime (13.00) there will be a series of talks examining the effect of the First World War on medicine.",
                    Place_EN="Venue: Hall B",
                    Title_TH="ทำแบบทดสอบทัศนคติ 1",
                    Description_TH=@"<ul><li>09.00-12.00 น. ผู้เข้าสอบทำแบบทดสอบทัศนคติ
13.00 น.เป็นต้นไป ตรวจร่างกาย</li>
<li>13.00-15.00 น. ผู้เข้าสอบและผู้ปกครองพบอาจารย์จากมหาวิทยาลัยนอตติงแฮม</li>
<em>-ค่าใช้จ่ายในการทดสอบทัศนคติทางการแพทย์ การตรวจปัสสาวะ จะแจ้งให้ทาบให้ภายหลัง
-ให้นำฟิล์มเอ๊กซเรย์ปอด ที่ถ่ายไม่เกิน 1 เดือนไปยื่นกับแพทย์ที่ตรวจร่างกายด้วย</em>",
                    Place_TH="คณะแพทย์ศาตร์ มศว ประสานมิตร กรุงเทพฯ",
                    ImageUrl="images/event/1.jpg",
                    StartDate = new DateTime(2018,1,26,9,0,0).ToUniversalTime()
                },
            };
        }
    }
}
