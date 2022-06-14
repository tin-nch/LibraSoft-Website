using Librasoft.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Services.Constract
{
    public interface ICFReasonReachingServices
    {
        public Task<IEnumerable<PiranhaCfreasonReaching>> GetReasonReachinglistAsync();
        public PiranhaCfreasonReaching GetRRById(int? id);
    }
}
