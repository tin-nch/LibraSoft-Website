using AutoMapper;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using Librasoft.Services.Constract;
using Librasoft_API.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services
{
    public class SendEmailServices : ISendEmailServices
    {
        private readonly ISendEmailRepository sendEmailRepository;
        private readonly ICFReasonReachingRepository reasonReachingRepository;
        private readonly IMapper mapper;
        private readonly IEventRepository eventRepository;

        public SendEmailServices(ISendEmailRepository sendEmailRepository, 
            ICFReasonReachingRepository reachingRepository,
            IMapper mapper,
            IEventRepository eventRepository)
        {
            this.sendEmailRepository = sendEmailRepository;
            this.mapper = mapper;
            reasonReachingRepository = reachingRepository;
            this.eventRepository = eventRepository;
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


            string nameCorp = "tam.tln@librasoft.vn";
           
            MailAddress _sender = new MailAddress(virtualEmail);
            MailAddress _receiver = new MailAddress(nameCorp);
            
            //subject Email
            PiranhaCfreasonReaching cfreasonReaching = reasonReachingRepository.getRRbyId(contactForm.ReasonReachingId);
            string reasonReaching = cfreasonReaching.ReasonReachingContent;
            string subject = "NEW MAIL: New Contact Mail Is Arrived";

            string body = BodyMailing.ContactForm(contactForm, reasonReaching);
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
            // client.Host = "smtp.gmail.com";
            client.Host = "mail.librasoft.vn";
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_sender.Address, password);
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
        delegate (object s, X509Certificate certificate, X509Chain chain,
        SslPolicyErrors sslPolicyErrors) { return true; };
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

        public async Task<bool> SendConFirmEmail(EventParticipantDto  participant)
        {
            //get virtual Email va event 
            var virtualMail = await this.GetVirtualAccountAsync();
            var _virtualMail = virtualMail.FirstOrDefault();

            //var _event =

            // Create a message and set up the recipients.
            string virtualEmail = _virtualMail.Email;
            string password = _virtualMail.Password;

            //ten nguoi nhan //participant.Email
            string nameCorp = participant.Email;

            MailAddress _sender = new MailAddress(virtualEmail);
            MailAddress _receiver = new MailAddress(nameCorp);
            MailMessage mail = new MailMessage(_sender, _receiver);

            string subject = "CONFIRMATION OF REGISTRATION TO WEBINAR";
            
       

            // hinh` anh chuyen ve` dang Jpeg
            string filePath = Directory.GetCurrentDirectory() + "/wwwroot/images/logo.Jpeg";
            string filePath1 = Directory.GetCurrentDirectory() + "/wwwroot/images/pic1.Jpeg";
            string filePath2 = Directory.GetCurrentDirectory() + "/wwwroot/images/pic2.Jpeg";
            
            Attachment att = new Attachment(filePath);
            Attachment att1 = new Attachment(filePath1);
            Attachment att2 = new Attachment(filePath2);

            List<Attachment> listAtt = new List<Attachment>();
            listAtt.Add(att);   
            listAtt.Add(att1);
            listAtt.Add(att2);

            //body email  --- truyen thong tin event

            PiranhaEvent event1 =    eventRepository.GetPiranhaEventByID(participant.IDEvent);
         
            string body = BodyMailing.EventConfirm(listAtt,event1);
            //attach file ex : img, ...
            AlternateView view = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
            AlternateView view1 = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
            AlternateView view2 = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
            LinkedResource resource = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            LinkedResource resource1 = new LinkedResource(filePath1, MediaTypeNames.Image.Jpeg);
            LinkedResource resource2 = new LinkedResource(filePath2, MediaTypeNames.Image.Jpeg);
            att.ContentDisposition.Inline = true;
            att1.ContentDisposition.Inline = true;
            att2.ContentDisposition.Inline = true;
            resource.ContentId = "logo";
            resource1.ContentId = "pic1";
            resource2.ContentId = "pic2";


            
            mail.Body = body;
            mail.Subject = subject;
            mail.From = _sender;
            mail.To.Add(_receiver);
           // mail.AlternateViews.Add(view);
       //     mail.AlternateViews.Add(view1);
          //  mail.AlternateViews.Add(view2);
            mail.Attachments.Add(att);
            mail.Attachments.Add(att1);
            mail.Attachments.Add(att2);

            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;

            // Add credentials if the SMTP server requires them.
            SmtpClient client = new SmtpClient();
            client.Host = "mail.librasoft.vn";
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_sender.Address, password);
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
      delegate (object s, X509Certificate certificate, X509Chain chain,
      SslPolicyErrors sslPolicyErrors) { return true; };
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


        public async Task<bool> SendCVEmail(PiranhaApplicationForm applicationForm)
        {
            //get virtual Email va event 
            var virtualMail = await this.GetVirtualAccountAsync();
            var _virtualMail = virtualMail.FirstOrDefault();

            //var _event =

            // Create a message and set up the recipients.
            string virtualEmail = _virtualMail.Email;
            string password = _virtualMail.Password;

            //ten nguoi nhan //participant.Email
             string nameCorp = "htran5646@gmail.com";
           

            MailAddress _sender = new MailAddress(virtualEmail);
            MailAddress _receiver = new MailAddress(nameCorp);
            MailMessage mail = new MailMessage(_sender, _receiver);

            string subject = "NEW MAIL: New Application Form Is Arrived";


            // hinh` anh chuyen ve` dang Jpeg
            //string filePath = Directory.GetCurrentDirectory() + "/wwwroot/images/logo.Jpeg";
            //string filePath1 = Directory.GetCurrentDirectory() + "/wwwroot/images/pic1.Jpeg";
            //string filePath2 = Directory.GetCurrentDirectory() + "/wwwroot/images/pic2.Jpeg";

          

            Attachment att = new Attachment(applicationForm.FilePath);
            //Attachment att1 = new Attachment(filePath1);
            //Attachment att2 = new Attachment(filePath2);

      

            //body email  --- truyen thong tin event

     

            string body = BodyMailing.ApplicationForm(applicationForm);
            //attach file ex : img, ...
          //AlternateView view = AlternateView.CreateAlternateViewFromString("", null, MediaTypeNames.Text.Html);
   
          //LinkedResource resource = new LinkedResource(filePath, MediaTypeNames.Text.);
        
  
            att.ContentDisposition.Inline = true;

            //  resource.ContentId = "file";
            mail.Body = body;
            mail.Subject = subject;
            mail.From = _sender;
            mail.To.Add(_receiver);
         // mail.AlternateViews.Add(view);
            mail.Attachments.Add(att);
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;
            // Add credentials if the SMTP server requires them.
            SmtpClient client = new SmtpClient();
            client.Host = "mail.librasoft.vn";
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_sender.Address, password);
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
      delegate (object s, X509Certificate certificate, X509Chain chain,
      SslPolicyErrors sslPolicyErrors) { return true; };
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

        public PiranhaApplicationForm GetApplicationForm(PiranhaApplicationForm application)
        {
           return sendEmailRepository.GetPiranhaApplicationForm(application);
        }

        public async Task<int> SendOPT(string email)
        {
            var virtualMail = await this.GetVirtualAccountAsync();
            var _virtualMail = virtualMail.FirstOrDefault();

            // Create a message and set up the recipients.
            string virtualEmail = _virtualMail.Email;
            string password = _virtualMail.Password;


            string nameCorp = email;

            MailAddress _sender = new MailAddress(virtualEmail);
            MailAddress _receiver = new MailAddress(nameCorp);

            //subject Email
            int otp = sendEmailRepository.GenerateOPTCode();
            string subject = "Verify Your Email Submit Event";

            string body = BodyMailing.OTPMail(otp);
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
            client.Host = "mail.librasoft.vn";
            client.Credentials = new NetworkCredential(_sender.Address, password);
            client.Port = 587;
            client.EnableSsl = true;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
     delegate (object s, X509Certificate certificate, X509Chain chain,
     SslPolicyErrors sslPolicyErrors) { return true; };
                client.Send(mail);
                return otp;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                    ex.ToString());
            }
            return 0;
        }

        public async Task<bool> SendNotifyMail(EventParticipantDto participant)
        {
            var virtualMail = await this.GetVirtualAccountAsync();
            var _virtualMail = virtualMail.FirstOrDefault();

         
            // Create a message and set up the recipients.
            string virtualEmail = _virtualMail.Email;
            string password = _virtualMail.Password;

            
            string nameCorp = "tam.tln@librasoft.vn";

            MailAddress _sender = new MailAddress(virtualEmail);
            MailAddress _receiver = new MailAddress(nameCorp);

            //subject Email
          
            string subject = "NEW MAIL: New Participant";

            string body = BodyMailing.NotifyMail(participant);
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
            // client.Host = "smtp.gmail.com";
            client.Host = "mail.librasoft.vn";
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_sender.Address, password);
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
        delegate (object s, X509Certificate certificate, X509Chain chain,
        SslPolicyErrors sslPolicyErrors) { return true; };
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
