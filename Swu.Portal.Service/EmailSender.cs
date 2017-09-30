using Swu.Portal.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Swu.Portal.Service
{
    public interface IEmailSender {
        void Send(Email email);
    }
    public class EmailSender : IEmailSender
    {
        public void Send(Email email)
        {
            var fromAddress = new MailAddress(email.SenderEmail, email.SenderName);
            var toAddress = new MailAddress("chansakcsc@gmail.com", "website admin");
            const string fromPassword = "P@ssw0rd2107";
            string subject = "Message from contract us page";
            string body = email.Message;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
