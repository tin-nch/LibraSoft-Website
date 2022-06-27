using Librasoft.Entities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace Librasoft_API.Utils
{
    public static class BodyMailing
    {
        public static string EventConfirm(List<Attachment> att1) {

            string body =
                "<div align=\"center\" style=\"text-align:center\">"+
                "<div border=\"0\" cellpadding=\"0\" cellspacing=\"0\" height=\"100%\" width=\"100%\" style=\"border-collapse:collapse;height:1204.9px;margin:0px;padding:0px;max-width:600px\" align=\"center\" class=\"parent\">\r\n\t"
                + String.Format(@"<img width=""{0}"" height=""{1}"" style=""margin-right:{2}"" src=""cid:{3}"" />", 443, 125, "0px", att1[0].ContentId)

                + "\r\n\t<div style=\"text-align: left\">\r\n\t\t<p style='margin-top:0cm;margin-right:0cm;margin-bottom:0cm;margin-left:0cm;line-height:175%;font-size:15px;font-family:\"Calibri\",sans-serif;'><span style='font-size:12px;line-height:175%;font-family:\"Arial\",sans-serif;color:#202020;'>Thank you for signing up for our webinar." +
                "<br> <strong>Time | .. hours, Thursdays, days ..... via " 
                + "Zoom</strong><br>&nbsp;(Zoom ID and Password:&hellip;..)<br>&nbsp;" 
                + "Link:&hellip;.<br>&nbsp;Can&rsquo;t wait to see you on the event!<br> <em><u>" 
                + "Note:</u><br>&nbsp;Guests can prepare questions.<br>&nbsp;All questions about the solution will be answered during the duration of the event.</em></span></p>\r\n\t\t<p style='margin-top:0cm;margin-right:0cm;margin-bottom:0cm;margin-left:0cm;line-height:175%;font-size:15px;font-family:\"Calibri\",sans-serif;'><br></p>\r\n\t\t<p style='margin-top:0cm;margin-right:0cm;margin-bottom:0cm;margin-left:0cm;line-height:175%;font-size:15px;font-family:\"Calibri\",sans-serif;'><span style='font-size:12px;line-height:175%;font-family:\"Arial\",sans-serif;color:navy;'>Cảm ơn bạn đ&atilde; đăng k&iacute; tham gia hội thảo trực tuyến của ch&uacute;ng t&ocirc;i.<br> <strong>" +
                "Thời gian | .. giờ, Thứ Năm, ng&agrave;y &hellip;.. qua Zoom&nbsp;</strong><br>&nbsp;(" 
                +"Zoom ID v&agrave; Password:&hellip;..)<br>&nbsp;" +
                "Link:<a href=\"https://facebook.com\">https://facebook.com </a><br>&nbsp;Hẹn gặp lại c&aacute;c bạn tại buổi hội thảo!<br> <em><u>Ghi ch&uacute;:</u><br>&nbsp;Kh&aacute;ch mời c&oacute; thể chuẩn bị sẵn c&acirc;u hỏi.<br>&nbsp;Tất cả c&acirc;u hỏi về giải ph&aacute;p sẽ được ch&uacute;ng t&ocirc;i giải đ&aacute;p trong thời lượng của chương tr&igrave;nh.</em></span></p>\r\n\t</div>\r\n\t\r\n\t<div border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-collapse:collapse;min-width:100%\" align: \"center\" class=\"child\">\r\n\t\t"

            + String.Format(@"<img width=""{0}"" style=""{1}"" src=""cid:{2}"" />", 600, "max-height: 100%;", att1[1].ContentId)
                + "</br>"
                + "</br>"
                + String.Format(@"<img width=""{0}"" style=""{1}"" src=""cid:{2}"" />", 600, "max-height: 100%;", att1[2].ContentId)
                + "\r\n\t</div>\r\n</div>"
                + "</div>"
                ;
            return body;
        }
        public static string ContactForm(PiranhaContactForm contactForm)
        {
            //contactForm.Email = "NEmail";
            //contactForm.FullName = "Fullnameeee";
            //contactForm.Phone = "09234";

            string body = "<div> Name: " +  contactForm.FullName.ToString() + "</div> <br>" +
                            "<h1> Email: " + contactForm.MessageContent.ToString() + "</h1> <br>" +
                                "<div> Phone Number: " + contactForm.Phone.ToString() + "</div>"; ;

            return body;
        }
    }
}
