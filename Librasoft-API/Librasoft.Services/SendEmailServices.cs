﻿using AutoMapper;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft.Services.Constract;
using Librasoft_API.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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
            ICFReasonReachingRepository reachingRepository,
            IMapper mapper)
        {
            this.sendEmailRepository = sendEmailRepository;
            this.mapper = mapper;
            reasonReachingRepository = reachingRepository;  
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


            string nameCorp = "tan.ntm.librasoft@gmail.com";

            MailAddress _sender = new MailAddress(virtualEmail);
            MailAddress _receiver = new MailAddress(nameCorp);
            
            //subject Email
            PiranhaCfreasonReaching cfreasonReaching = reasonReachingRepository.getRRbyId(contactForm.ReasonReachingId);
            string reasonReaching = cfreasonReaching.ReasonReachingContent;
            string subject = reasonReaching;

            string body = BodyMailing.ContactForm(contactForm);
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

        public async Task<bool> SendConFirmEmail(PiranhaEventParticipant participant)
        {
            //get virtual Email va event 
            var virtualMail = await this.GetVirtualAccountAsync();
            var _virtualMail = virtualMail.FirstOrDefault();

            //var _event =

            // Create a message and set up the recipients.
            string virtualEmail = _virtualMail.Email;
            string password = _virtualMail.Password;

            //ten nguoi nhan //participant.Email
            string nameCorp = "tan.ntm.librasoft@gmail.com";

            MailAddress _sender = new MailAddress(virtualEmail);
            MailAddress _receiver = new MailAddress(nameCorp);
            MailMessage mail = new MailMessage(_sender, _receiver);

            string subject = "Fwd:CONFIRMATION OF REGISTRATION TO WEBIBAR";
            
            //Info Event tao obj event de test
            //PiranhaEvent obj = new PiranhaEvent
            //{
            //    Active = true,
            //    EndDate = DateTime.Now,
            //    EventTitle = "This is even title",
            //    Id = 1,
            //    StartDate = DateTime.Now
            //};

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
            string body = BodyMailing.EventConfirm(listAtt);
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
            mail.AlternateViews.Add(view);
            mail.AlternateViews.Add(view1);
            mail.AlternateViews.Add(view2);
            mail.Attachments.Add(att);
            mail.Attachments.Add(att1);
            mail.Attachments.Add(att2);

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
