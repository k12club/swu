
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
    [RoutePrefix("V1/shared")]
    public class SharedController : ApiController
    {
        public SharedController()
        {
        }
        [HttpGet, Route("commitments")]
        public List<CommitmentProxy> GetCommitment()
        {
            if (ModelState.IsValid)
            {
                return new List<CommitmentProxy> {
                    new CommitmentProxy {
                        Title_EN="More learning opportunity",
                        Description_EN="To enhance the learning opportunity of medical programme from both national and international schools in Thailand",
                        Title_TH="เพิ่มโอกาสการเรียนรู้",
                        Description_TH="เพื่อเพิ่มโอกาสทางการศึกษาหลักสูตรแพทยศาสตรบัณฑิตจากสถานศึกษาในประเทศไทย",
                        IconCss="flaticon-clothes"
                    },
                    new CommitmentProxy {
                        Title_EN="Knowledgeable medical",
                        Description_EN="To produce the knowledgeable medical graduates who can use the medical sciences knowledge from the UK and apply it to clinical practice in Thailand",
                        Title_TH="เพื่อผลิตบัณฑิตแพทย์ที่มีความรู้ความสามารถ",
                        Description_TH="เพื่อผลิตบัณฑิตแพทย์ที่มีความรู้ความสามารถ และนำความรู้ ประสบการณ์ทางการศึกษาด้านวิทยาศาสตร์การแพทย์จากสหราชอาณาจักร มาประยุกต์ใช้ควบคู่ไปกับความรู้ทางด้านคลินิกที่ศึกษาในประเทศไทย ในการดูแลผู้ป่วยแบบองค์รวม",
                        IconCss="flaticon-signs"
                    },
                    new CommitmentProxy {
                        Title_EN="To produce medical graduates",
                        Description_EN="To produce medical graduates who can provide the efficient health care services to the society both in government and private sectors",
                        Title_TH="เพื่อผลิตบัณฑิตแพทย์ที่ดี",
                        Description_TH="เพื่อผลิตบัณฑิตแพทย์ที่สามารถให้บริการทางด้านสาธารณสุขแก่สังคมได้อย่างมีประสิทธิภาพ ไม่ว่าจะปฏิบัติงานอยู่ในภาครัฐ หรือภาคเอกชน สามารถปฏิบัติงานร่วมกับผู้ร่วมงานได้อย่างมีประสิทธิภาพ มีคุณธรรม จริยธรรม มีความใฝ่รู้ มีความคิดริเริ่มสร้างสรรค์ รับผิดชอบ มีศีลธรรม มีความเสียสละ ทันต่อความก้าวหน้าทางวิชาการ สามารถวิเคราะห์ และแก้ไขปัญหาแบบวิทยาศาสตร์ และวิจัยปัญหาทางสุขภาพ เพื่อนำผลมาใช้ให้เกิดประโยชน์ด้านการพัฒนาการรักษาพยาบาลของสังคมไทย",
                        IconCss="flaticon-school"
                    }
                };
            }
            return null;
        }
    }
}
