using Librasoft.DataAccess.EFs;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
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

        public AdminAccount GetVirtualEmail()
        {
            return _context.AdminAccounts.FirstOrDefault(a => a.IsVirtualEmail == true && a.IsDelete == false);
        }
    }
}
