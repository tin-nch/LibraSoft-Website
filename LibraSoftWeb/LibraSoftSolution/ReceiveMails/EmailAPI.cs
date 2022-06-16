using LibraSoftSolution.ViewModels.ContactForm;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ReceiveMails
{
    public class EmailAPI: BaseApiClient, IEmailAPI
    {
        public EmailAPI(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public Task<bool> SendEmail(ContactVM contact)
        {
            // Create a message and set up the recipients.
            string virtualEmail = "duachuthoi25@gmail.com";
            string nameCorp = "tan.ntm.librasoft@gmail.com";
            MailAddress _sender = new MailAddress(virtualEmail);
            MailAddress _receiver = new MailAddress(nameCorp);
            string Subject = "this is subject";
            string Body = "<h1>Librasoft Corp. xin chào " + contact.Email.ToString() + "</h1>";

            MailMessage mail = new MailMessage(_sender, _receiver);

            mail.Body = Body;
            mail.Subject = Subject;
            mail.From = _sender;
            mail.To.Add(_receiver);
            
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;

            // Add credentials if the SMTP server requires them.
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            string password = "hlhbxsvikbkpkyey";
            client.Credentials = new NetworkCredential(_sender.Address, password);
            client.Port = 587;
            client.EnableSsl = true;

            try
            {
                client.Send(mail);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                    ex.ToString());
            }
            return Task.FromResult(false); 
        }
    }
}
