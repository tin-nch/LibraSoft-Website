using AutoMapper;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft.Services.Constract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services
{
    public class SendEmailServices : ISendEmailServices
    {
        private readonly ISendEmailRepository sendEmailRepository;
        private readonly ICFReasonReachingRepository reasonReachingRepository;
        private readonly IMapper mapper;

        public SendEmailServices(ISendEmailRepository sendEmailRepository, 
            IMapper mapper,
            ICFReasonReachingRepository reasonReachingRepository)
        {
            this.sendEmailRepository = sendEmailRepository;
            this.mapper = mapper;
            this.reasonReachingRepository = reasonReachingRepository;
        }
        public async Task<IEnumerable<AdminAccount>> GetVirtualAccountAsync()
        {
            IReadOnlyList<AdminAccount> adminAccount = await sendEmailRepository.ListAsync();
            return mapper.Map<IEnumerable<AdminAccount>>(adminAccount);
        }

        public async Task<bool> SendEmail(PiranhaContactForm contactForm)
        {
            //get virtual Email
            var virtualMail = await this.GetVirtualAccountAsync();
            var _virtualMail = virtualMail.FirstOrDefault();

            // Create a message and set up the recipients.
            string virtualEmail = _virtualMail.Email;
            string password = _virtualMail.Password;


            string nameCorp = "Nghia.nd.librasoft@gmail.com";

            MailAddress _sender = new MailAddress(virtualEmail);
            MailAddress _receiver = new MailAddress(nameCorp);
            string subject = "Có một đơn ứng tuyển mới [LibraSoft]";
            string body = "<div> Name: " + contactForm.FullName.ToString() + "</div> <br>" +
                            "<h1> Email: " + contactForm.MessageContent.ToString() + "</h1> <br>" +
                                "<div> Phone Number: " + contactForm.Phone.ToString() + "</div>";
           //attach file
           // 

            MailMessage mail = new MailMessage(_sender, _receiver);

            mail.Body = body;
            mail.Subject = subject;
            mail.From = _sender;
            mail.To.Add(_receiver);

            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;

            // Add credentials if the SMTP server requires them.
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Credentials = new NetworkCredential(_sender.Address, password);
            client.Port = 587;
            client.EnableSsl = true;

            try
            {
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                    ex.ToString());
            }
            return false;
        }

        public async Task<bool> SendEmail(PiranhaContactForm contactForm, PiranhaEvent piranhaEvent)
        {
            //get virtual Email
            var virtualMail = await this.GetVirtualAccountAsync();
            var _virtualMail = virtualMail.FirstOrDefault();

            // Create a message and set up the recipients.
            string virtualEmail = _virtualMail.Email;
            string password = _virtualMail.Password;


            string nameCorp = "tan.ntm.libra@gmail.com";

            MailAddress _sender = new MailAddress(virtualEmail);
            MailAddress _receiver = new MailAddress(nameCorp);
            string subject = " ";
            string body = "<div> Name: " + contactForm.FullName.ToString() + "</div> <br>" +
                            "<h1> Email: " + contactForm.MessageContent.ToString() + "</h1> <br>" +
                                "<div> Phone Number: " + contactForm.Phone.ToString() + "</div>";
            //attach file
            // 

            MailMessage mail = new MailMessage(_sender, _receiver);

            mail.Body = body;
            mail.Subject = subject;
            mail.From = _sender;
            mail.To.Add(_receiver);

            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;

            // Add credentials if the SMTP server requires them.
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Credentials = new NetworkCredential(_sender.Address, password);
            client.Port = 587;
            client.EnableSsl = true;

            try
            {
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                    ex.ToString());
            }
            return false;
        }
    }
}
