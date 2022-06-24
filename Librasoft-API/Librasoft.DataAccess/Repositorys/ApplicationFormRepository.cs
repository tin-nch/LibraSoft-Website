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
    public class ApplicationFormRepository : GenericRepository<PiranhaApplicationForm>, IApplicationFormRepository
    {
        public ApplicationFormRepository(PiranhaCoreContext context) : base(context)
        {


        }

        public bool CheckExistsEmail(ApplicationFormDto applicationForm)
        {
           PiranhaApplicationForm a = _context.PiranhaApplicationForms.FirstOrDefault(x=>x.Email.Trim().Equals(applicationForm.Email.Trim()));
            if (a != null)
                return true;
            return false;
        }
    }
}
