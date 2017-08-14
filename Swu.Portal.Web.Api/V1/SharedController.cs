
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
                        Title_EN="Four Year Graduation Guarantee",
                        Description_EN="By enrolling in the Four Bear Program, we guarantee you will graduate in four years with a bachelor’s degree.",
                        Title_TH="ทดสอบทดสอบทดสอบทดสอบทดสอบ",
                        Description_TH="ทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบ",
                        IconCss="flaticon-clothes"
                    },
                    new CommitmentProxy {
                        Title_EN="Best Value",
                        Description_EN="A top 100 university based on research, service and social mobility, according to Washington Monthly.",
                        Title_TH="ทดสอบทดสอบทดสอบทดสอบทดสอบ",
                        Description_TH="ทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบ",
                        IconCss="flaticon-signs"
                    },
                    new CommitmentProxy {
                        Title_EN="Small Class Sizes",
                        Description_EN="76% of all undergraduate classes have fewer than 30 students so there´s plenty of room for everyone.",
                        Title_TH="ทดสอบทดสอบทดสอบทดสอบทดสอบ",
                        Description_TH="ทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบ",
                        IconCss="flaticon-school"
                    },
                    new CommitmentProxy {
                        Title_EN="Extraordinary Faculty",
                        Description_EN="World-renowned researchers provide personal attention, with a 19:1 student-to-faculty ratio.",
                        Title_TH="ทดสอบทดสอบทดสอบทดสอบทดสอบ",
                        Description_TH="ทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบ",
                        IconCss="flaticon-art"
                    }
                };
            }
            return null;
        }
    }
}
