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
                    ImageUrl = "Content/images/team/1.jpg",
                    Name_EN = "Prof.Pansiri Phunsuwan, PhD. (Vice President of Academic Affairs)",
                    Position_EN = "Advisory Board",
                    Description_EN = "",
                    Name_TH = "ศ. ดร.ปานสิริ พันธุ์สุวรรณ (รองอธิการบดีฝ่ายวิชาการ)",
                    Position_TH = "ที่ปรึกษา",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/2.jpg",
                    Name_EN = "Prof.Chairat Neruntarat MD. (Dean, Faculty of Medicine)",
                    Position_EN = "Advisory Board",
                    Description_EN = "",
                    Name_TH = "ศ.นพ.ชัยรัตน์ นิรันตรัตน์ (คณบดี คณะแพทยศาสตร์)",
                    Position_TH = "ที่ปรึกษา",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/3.jpg",
                    Name_EN = "Assoc.Prof.Yothin Benjawang, MD.",
                    Position_EN = "Advisory Board",
                    Description_EN = "",
                    Name_TH = "รศ.นพ.โยธิน เบญจวัง",
                    Position_TH = "ที่ปรึกษา",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/4.jpg",
                    Name_EN = "Dr.Nantana Chumchui, MD.",
                    Position_EN = "Vice Dean of Academic Affairs",
                    Description_EN = "",
                    Name_TH = "ผศ.พญ.นันทนา ชุมช่วย (รองคณบดีฝ่ายการศึกษา)",
                    Position_TH = "ที่ปรึกษา",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/5.jpg",
                    Name_EN = "Assoc.Prof.Watchareewan Thongsaard, PhD.",
                    Position_EN = "visory Board ",
                    Description_EN = "",
                    Name_TH = "รศ.ดร.วัชรีวรรณ ทองสะอาด",
                    Position_TH = "ที่ปรึกษา",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/6.jpg",
                    Name_EN = " Assoc.Prof.Ramida Wattanapokasin, PhD.",
                    Position_EN = "Programme Director",
                    Description_EN = "",
                    Name_TH = "รศ.ดร.รมิดา วัฒนโภคาสิน",
                    Position_TH = "ประธานหลักสูตรฯ ",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/7.jpg",
                    Name_EN = "Assist.Prof.Manapol Kulpraneet, MD.",
                    Position_EN = "Deputy Director ",
                    Description_EN = "",
                    Name_TH = "ผศ.นพ.มนะพล กุลปราณีต",
                    Position_TH = "รองประธานฯ",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/8.jpg",
                    Name_EN = "Assoc.Prof.Tawima Sirirassamee, MD.",
                    Position_EN = "Programme Commitee",
                    Description_EN = "",
                    Name_TH = "รศ.พญ.ทวิมา ศิริรัศมี",
                    Position_TH = "กรรมการ",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/9.jpg",
                    Name_EN = "Dr.Pichaya Petborom, MD.",
                    Position_EN = "Programme Commitee ",
                    Description_EN = "",
                    Name_TH = "พญ. พิชญา เพชรบรม",
                    Position_TH = "กรรมการ",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/10.jpg",
                    Name_EN = "Dr.Amarin Narkwichean",
                    Position_EN = "Programme Secretary and Commitee",
                    Description_EN = "",
                    Name_TH = "นพ.อมรินทร์ นาควิเชียร",
                    Position_TH = "กรรมการ และเลขานุการ",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                }
            };
        }

        [HttpGet, Route("allEn")]
        public List<CommitteeProxy> GetAllEn()
        {
            return new List<CommitteeProxy> {
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/1.jpg",
                    Name_EN = "Prof.Pansiri Phunsuwan, PhD. (Vice President of Academic Affairs)",
                    Position_EN = "Advisory Board",
                    Description_EN = "",
                    Name_TH = "ศ. ดร.ปานสิริ พันธุ์สุวรรณ (รองอธิการบดีฝ่ายวิชาการ)",
                    Position_TH = "ที่ปรึกษา",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/2.jpg",
                    Name_EN = "Prof.Chairat Neruntarat MD. (Dean, Faculty of Medicine)",
                    Position_EN = "Advisory Board",
                    Description_EN = "",
                    Name_TH = "ศ.นพ.ชัยรัตน์ นิรันตรัตน์ (คณบดี คณะแพทยศาสตร์)",
                    Position_TH = "ที่ปรึกษา",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/3.jpg",
                    Name_EN = "Assoc.Prof.Yothin Benjawang, MD.",
                    Position_EN = "Advisory Board",
                    Description_EN = "",
                    Name_TH = "รศ.นพ.โยธิน เบญจวัง",
                    Position_TH = "ที่ปรึกษา",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/4.jpg",
                    Name_EN = "Dr.Nantana Chumchui, MD.",
                    Position_EN = "Vice Dean of Academic Affairs",
                    Description_EN = "",
                    Name_TH = "ผศ.พญ.นันทนา ชุมช่วย (รองคณบดีฝ่ายการศึกษา)",
                    Position_TH = "ที่ปรึกษา",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/5.jpg",
                    Name_EN = "Assoc.Prof.Watchareewan Thongsaard, PhD.",
                    Position_EN = "visory Board ",
                    Description_EN = "",
                    Name_TH = "รศ.ดร.วัชรีวรรณ ทองสะอาด",
                    Position_TH = "ที่ปรึกษา",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/6.jpg",
                    Name_EN = " Assoc.Prof.Ramida Wattanapokasin, PhD.",
                    Position_EN = "Programme Director",
                    Description_EN = "",
                    Name_TH = "รศ.ดร.รมิดา วัฒนโภคาสิน",
                    Position_TH = "ประธานหลักสูตรฯ ",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/7.jpg",
                    Name_EN = "Assist.Prof.Manapol Kulpraneet, MD.",
                    Position_EN = "Deputy Director ",
                    Description_EN = "",
                    Name_TH = "ผศ.นพ.มนะพล กุลปราณีต",
                    Position_TH = "รองประธานฯ",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/8.jpg",
                    Name_EN = "Assoc.Prof.Tawima Sirirassamee, MD.",
                    Position_EN = "Programme Commitee",
                    Description_EN = "",
                    Name_TH = "รศ.พญ.ทวิมา ศิริรัศมี",
                    Position_TH = "กรรมการ",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/9.jpg",
                    Name_EN = "Dr.Pichaya Petborom, MD.",
                    Position_EN = "Programme Commitee ",
                    Description_EN = "",
                    Name_TH = "พญ. พิชญา เพชรบรม",
                    Position_TH = "กรรมการ",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/10.jpg",
                    Name_EN = "Dr.Amarin Narkwichean",
                    Position_EN = "Programme Secretary and Commitee",
                    Description_EN = "",
                    Name_TH = "นพ.อมรินทร์ นาควิเชียร",
                    Position_TH = "กรรมการ และเลขานุการ",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                }
            };
        }
    }
}
