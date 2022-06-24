using Librasoft.Entities.Entities;

namespace Librasoft_API.Utils
{
    public class BodyMailing
    {
        public static string EventConfirm() {
            PiranhaContactForm contactForm = new PiranhaContactForm
            {
                Email = "NEmail",
                FullName = "Fullnameeee",
                Phone = "09234"
            };
            string body = "<div> Name: " + contactForm.FullName.ToString() + "</div> <br>" +
                            "<h1> Email: " + contactForm.MessageContent.ToString() + "</h1> <br>" +
                                "<div> Phone Number: " + contactForm.Phone.ToString() + "</div>"; ;
            
            return body;
        }
    }
}
