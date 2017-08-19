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
    [RoutePrefix("V1/exam")]
    public class ExamRegistrationController : ApiController
    {
        private readonly IDateTimeRepository _datetimeRepository;
        public ExamRegistrationController(IDateTimeRepository datetimeRepository)
        {
            this._datetimeRepository = datetimeRepository;
        }
        [HttpGet, Route("getExam")]
        public ExamRegistrationProxy GetExamRegistrationInfo()
        {
            var examDate = new DateTime(2017, 10, 14).ToUniversalTime();
            var remaining = (examDate - this._datetimeRepository.Now().ToUniversalTime()).TotalSeconds;
            return new ExamRegistrationProxy
            {
                ExamInfo = new Exam
                {
                    Title_EN = "DIRECT ADMISSION FOR 2017",
                    Description_EN = "Are you ready to be a studen at here? Let's join us by register right now !!",
                    Title_TH = "ลงทะเบียนสอบตรงประจำปี 2560",
                    Description_TH = "พร้อมจะเป็นส่วนหนึ่งของเราหรือยัง? ลงทะเบียนได้แล้ววันนี้",
                    ExamDate = examDate
                },
                RemainingTime = remaining
            };
        }
    }
}
