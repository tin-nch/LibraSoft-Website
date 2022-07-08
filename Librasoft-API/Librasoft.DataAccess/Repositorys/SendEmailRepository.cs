using Librasoft.DataAccess.EFs;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using Librasoft_API.Librasoft.DataAccess.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.DataAccess.Repositorys
{
    public class SendEmailRepository : GenericRepository<AdminAccount>, ISendEmailRepository
    {
        public SendEmailRepository(PiranhaCoreContext context) : base(context)
        {
        }

        public int GenerateOPTCode()
        {
            Random rnd = new Random();
            int otp = rnd.Next(1000, 9999);
            return otp;
        }

        public PiranhaApplicationForm GetPiranhaApplicationForm(PiranhaApplicationForm application)
        {
          return _context.PiranhaApplicationForms.FirstOrDefault(a => a.Id == application.Id);
            

        }

        public AdminAccount GetVirtualEmail()
        {
            return _context.AdminAccounts.FirstOrDefault(a => a.IsVirtualEmail == true && a.IsDelete == false);
        }
    }
}
