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

 
    }
}
