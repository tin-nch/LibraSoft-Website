using Librasoft.DataAccess.Repositorys;
using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace Librasoft_API.Utils
{
    public static class BodyMailing
    {
      
        public static string EventConfirm(List<Attachment> att1,PiranhaEvent  piranhaEvent) {

           

            string body =
                "<div align=\"center\" style=\"text-align:center\">"+
                "<div border=\"0\" cellpadding=\"0\" cellspacing=\"0\" height=\"100%\" width=\"100%\" style=\"border-collapse:collapse;height:1204.9px;margin:0px;padding:0px;max-width:600px\" align=\"center\" class=\"parent\">\r\n\t"
                + String.Format(@"<img width=""{0}"" height=""{1}"" style=""margin-right:{2}"" src=""cid:{3}"" />", 443, 125, "0px", att1[0].ContentId)

                + "\r\n\t<div style=\"text-align: left\">\r\n\t\t<p style='margin-top:0cm;margin-right:0cm;margin-bottom:0cm;margin-left:0cm;line-height:175%;font-size:15px;font-family:\"Calibri\",sans-serif;'><span style='font-size:12px;line-height:175%;font-family:\"Arial\",sans-serif;color:#202020;'>Thank you for signing up for our webinar." +
                "<br> <strong>Time | "+ piranhaEvent.StartDate.Value.TimeOfDay + ", "+ piranhaEvent.StartDate.Value.DayOfWeek + ", "+ piranhaEvent.StartDate.Value.ToShortDateString()+ " via " 
              
                + "Link:"+piranhaEvent.Url+"<br>&nbsp;Can&rsquo;t wait to see you on the event!<br> <em><u>" 
                + "Note:</u><br>&nbsp;"+piranhaEvent.NoteEng+ "</em></span></p>\r\n\t\t<p style='margin-top:0cm;margin-right:0cm;margin-bottom:0cm;margin-left:0cm;line-height:175%;font-size:15px;font-family:\"Calibri\",sans-serif;'><br></p>\r\n\t\t<p style='margin-top:0cm;margin-right:0cm;margin-bottom:0cm;margin-left:0cm;line-height:175%;font-size:15px;font-family:\"Calibri\",sans-serif;'><span style='font-size:12px;line-height:175%;font-family:\"Arial\",sans-serif;color:navy;'>Cảm ơn bạn đ&atilde; đăng k&iacute; tham gia hội thảo trực tuyến của ch&uacute;ng t&ocirc;i.<br> <strong>" +
                "Thời gian | "+piranhaEvent.StartDate.Value.TimeOfDay+", " + convertToVietNameseDay(piranhaEvent.StartDate.Value.DayOfWeek.ToString()) + " , " + piranhaEvent.StartDate.Value.ToShortDateString() 
                +
                "<br>Link:" + piranhaEvent.Url + " </a><br>&nbsp;Hẹn gặp lại c&aacute;c bạn tại buổi hội thảo!<br> <em><u>Ghi ch&uacute;:</u><br>"+piranhaEvent.NoteVn+"</em></span></p>\r\n\t</div>\r\n\t\r\n\t<div border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-collapse:collapse;min-width:100%\" align: \"center\" class=\"child\">\r\n\t\t"

            + String.Format(@"<img width=""{0}"" style=""{1}"" src=""cid:{2}"" />", 600, "max-height: 100%;", att1[1].ContentId)
                + "</br>"
                + "</br>"
                + String.Format(@"<img width=""{0}"" style=""{1}"" src=""cid:{2}"" />", 600, "max-height: 100%;", att1[2].ContentId)
                + "\r\n\t</div>\r\n</div>"
                + "</div>"
                ;
            return body;
        }
        public static string ContactForm(PiranhaContactForm contactForm,string reasonreaching)
        {


            string body = "<div> From: " + contactForm.Email.ToString() + "</div> <br>" +

                "<div> Name: " + contactForm.FullName.ToString() + "</div> <br>" +
                 "<div> Phone Number: " + contactForm.Phone.ToString() + "</div>" +
            "<div> Reason Reaching: " + reasonreaching + "</div> <br>" +

              "<div> Message Content: " + contactForm.MessageContent.ToString() + "</div> <br>";
                               

            return body;
        }

        public static string NotifyMail(EventParticipantDto eventParticipant)
        {


            string body = "<div> New participants: " + eventParticipant.Email.ToString() + "</div> <br>" +

                "<div> Name: " + eventParticipant.FullName.ToString() + "</div> <br>" +
                 "<div> Phone Number: " + eventParticipant.Phone.ToString() + "</div>" +
            "<div> Company Name: " + eventParticipant.CompanyName + "</div> <br>" +

              "<div> Position: " + eventParticipant.Position.ToString() + "</div> <br>";


            return body;
        }

        public static string ApplicationForm(PiranhaApplicationForm applicationForm)
        {
            //contactForm.Email = "NEmail";
            //contactForm.FullName = "Fullnameeee";
            //contactForm.Phone = "09234";

            string body = "<div> Name: " + applicationForm.FullName.ToString() + "</div> <br>" +
                            "<div> Email: " + applicationForm.Email.ToString() + "</div> <br>" +
                                "<div> Phone Number: " + applicationForm.Phone.ToString() + "</div>"; ;

            return body;
        }

        public static string convertToVietNameseDay(string dayname)
        {
            switch(dayname)
            {
                case "Monday":

                    return "Thứ hai";
                

                case "Tuesday":
                    return "Thứ ba";
                  
                case "Wednesday":
                    return "Thứ tư";
                case "Thursday":
                    return "Thứ năm";

                case "Friday":
                    return "Thứ sáu";

                case "Saturday":
                    return "Thứ bảy";

                case "Sunday":
                    return "Chủ nhật";

                default: return null;
                    
            }    
        }

        public static string OTPMail(int otp)
        {


            string body = "<div>To verify your email address, please use the following One Time Password (OTP):<br>" +
                "<h4>" + otp + "</h4></div> <br>";


              


            return body;
        }
    }
}
