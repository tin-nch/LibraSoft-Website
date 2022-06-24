using Librasoft.Entities.Entities;
using Librasoft.Entities.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services.Constract
{
    public interface IApplicationFormServices
    {

        public Task<List<PiranhaApplicationForm>> GetApplicaitionFormlistAsync();
        public bool checkExistsEmail(ApplicationFormDto applicationForm);

        public Task<PiranhaApplicationForm> AddApplicationFormAsync(PiranhaApplicationForm applicationForm);
    }
}
