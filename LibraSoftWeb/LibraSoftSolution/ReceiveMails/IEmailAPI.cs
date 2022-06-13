using LibraSoftSolution.ViewModels.ContactForm;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.ReceiveMails
{
    public interface IEmailAPI
    {
        public Task<bool> SendEmail(ContactVM contact);
    }
}
