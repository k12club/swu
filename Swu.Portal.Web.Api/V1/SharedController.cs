
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
                        Title_EN="Objective 1",
                        Description_EN="To enhance the learning opportunity of medical programme from both national and international schools in Thailand",
                        Title_TH="Objective 1",
                        Description_TH="To enhance the learning opportunity of medical programme from both national and international schools in Thailand",
                        IconCss="flaticon-clothes"
                    },
                    new CommitmentProxy {
                        Title_EN="Objective 2",
                        Description_EN="To produce the knowledgeable medical graduates who can use the medical sciences knowledge from the UK and apply it to clinical practice in Thailand",
                        Title_TH="Objective 2",
                        Description_TH="To produce the knowledgeable medical graduates who can use the medical sciences knowledge from the UK and apply it to clinical practice in Thailand",
                        IconCss="flaticon-signs"
                    },
                    new CommitmentProxy {
                        Title_EN="Objective 3",
                        Description_EN="To produce medical graduates who can provide the efficient health care services to the society both in government and private sectors",
                        Title_TH="Objective 3",
                        Description_TH="To produce medical graduates who can provide the efficient health care services to the society both in government and private sectors",
                        IconCss="flaticon-school"
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
