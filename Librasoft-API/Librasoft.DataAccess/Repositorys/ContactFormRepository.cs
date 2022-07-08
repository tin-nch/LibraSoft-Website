using Librasoft.DataAccess.EFs;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;

using Librasoft_API.Librasoft.DataAccess.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Librasoft.DataAccess.Repositorys
{
    public class ContactFormRepository : GenericRepository<PiranhaContactForm>, IContactFormRepository
    {
        public ContactFormRepository(PiranhaCoreContext context) : base(context)
        {
        }

        public bool ValidateContactForm(PiranhaContactForm contactForm)
        {
            // lấy danh sách contact form trong ngày hiện tại
            // lấy thông tin contact với email đưa vào
            // so sánh nội dung message với từng contact
            // nếu trùng trả về true
            List<PiranhaContactForm> lst = _context.PiranhaContactForms.Where(a => a.Time.Value.Date.Equals(DateTime.Now.Date)&& a.Email.Equals(contactForm.Email)).ToList();
            foreach(PiranhaContactForm x in lst)
            {
                if(x.MessageContent.Equals(contactForm.MessageContent))
                {
                    return true;
                }    
            }    

            return false;

        }
    }
}
