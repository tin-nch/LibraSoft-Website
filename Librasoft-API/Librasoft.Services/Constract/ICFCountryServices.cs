using Librasoft.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services.Constract
{
    public interface ICFCountryServices
    {

        public Task<IEnumerable<PiranhaCfcountry>> GetCountrylistAsync();
    }
}
