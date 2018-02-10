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
                    Position_EN = "Deputy Director",
                    Description_EN = "",
                    Name_TH = "ผศ.นพ.มนะพล กุลปราณีต",
                    Position_TH = "รองประธานฯ",
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
                    Position_EN = "Programme Commitee",
                    Description_EN = "",
                    Name_TH = "พญ. พิชญา เพชรบรม",
                    Position_TH = "กรรมการ",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/11.jpg",
                    Name_EN = "ASSO.PROF. NARONGCHAI  YINGSAKMONGKOL, M.D.",
                    Position_EN = "Vice Dean of Academic Affairs",
                    Description_EN = "",
                    Name_TH = "ASSO.PROF. NARONGCHAI  YINGSAKMONGKOL, M.D.",
                    Position_TH = "Vice Dean of Academic Affairs",
                    Description_TH = "",
                    Phone = "",
                    Room="",
                    Email=""
                },
            };
        }

        [HttpGet, Route("allEn")]
        public List<CommitteeProxy> GetAllEn()
        {
            return new List<CommitteeProxy> {
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/William.jpg",
                    Name_EN = "Dr. William Dunn",
                    Position_EN = "Associate Professor",
                    Description_EN = "",
                    Name_TH = "Dr. William Dunn",
                    Position_TH = "Associate Professor",
                    Description_TH = "",
                    Phone = "0115 82 30188, 0115 82 30142",
                    Room="",
                    Email="william.dunn@nottingham.ac.uk"
                },
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/Vincent.jpg",
                    Name_EN = "Dr. Vincent Wilson",
                    Position_EN = "Associate Professor",
                    Description_EN = "",
                    Name_TH = "Dr. Vincent Wilson",
                    Position_TH = "Associate Professor",
                    Description_TH = "",
                    Phone = "0115 82 30189, 0115 82 30142",
                    Room="",
                    Email="vince.wilson@nottingham.ac.uk"
                },

                new CommitteeProxy {
                    ImageUrl = "Content/images/team/Susan.jpg",
                    Name_EN = "Dr. Susan Anderson",
                    Position_EN = "Associate Professor",
                    Description_EN = "",
                    Name_TH = "Dr. Susan Anderson",
                    Position_TH = "Associate Professor",
                    Description_TH = "",
                    Phone = "01332 724 609",
                    Room="",
                    Email="susan.anderson@nottingham.ac.uk"
                },
                
                new CommitteeProxy {
                    ImageUrl = "Content/images/team/Yvonne.jpg",
                    Name_EN = "Dr. Yvonne Mbaki",
                    Position_EN = "Associate Professor",
                    Description_EN = "",
                    Name_TH = "Dr. Yvonne Mbaki",
                    Position_TH = "Associate Professor",
                    Description_TH = "",
                    Phone = "0115 823 0160",
                    Room="",
                    Email="Yvonne.Mbaki@nottingham.ac.uk"
                },
            };
        }
    }
}
