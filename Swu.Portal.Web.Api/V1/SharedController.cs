
using Swu.Portal.Service;
using Swu.Portal.Web.Api;
using Swu.Portal.Web.Api.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Swu.Portal.Web.Api
{
    [RoutePrefix("V1/shared")]
    public class SharedController : ApiController
    {
        private readonly IEmailSender _emailSender;
        public SharedController(IEmailSender emailSender)
        {
            this._emailSender = emailSender;
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
                        Title_TH="Four Year Graduation Guarantee",
                        Description_TH="By enrolling in the Four Bear Program, we guarantee you will graduate in four years with a bachelor’s degree.",
                        IconCss="flaticon-clothes"
                    },
                    new CommitmentProxy {
                        Title_EN="Best Value",
                        Description_EN="A top 100 university based on research, service and social mobility, according to Washington Monthly.",
                        Title_TH="Best Value",
                        Description_TH="A top 100 university based on research, service and social mobility, according to Washington Monthly.",
                        IconCss="flaticon-signs"
                    },
                    new CommitmentProxy {
                        Title_EN="Small Class Sizes",
                        Description_EN="76% of all undergraduate classes have fewer than 30 students so there´s plenty of room for everyone.",
                        Title_TH="Small Class Sizes",
                        Description_TH="76% of all undergraduate classes have fewer than 30 students so there´s plenty of room for everyone.",
                        IconCss="flaticon-school"
                    },
                    new CommitmentProxy {
                        Title_EN="Extraordinary Faculty",
                        Description_EN="World-renowned researchers provide personal attention, with a 19:1 student-to-faculty ratio.",
                        Title_TH="Extraordinary Faculty",
                        Description_TH="World-renowned researchers provide personal attention, with a 19:1 student-to-faculty ratio.",
                        IconCss="flaticon-art"
                    }
                };
            }
            return null;
        }
        [HttpPost, Route("sendMail")]
        public HttpResponseMessage SendMail(EmailProxy email)
        {
            try
            {
                this._emailSender.Send(new Service.Model.Email
                {
                    SenderName = email.Sender,
                    SenderEmail = email.Email,
                    Message = email.Message
                });
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
