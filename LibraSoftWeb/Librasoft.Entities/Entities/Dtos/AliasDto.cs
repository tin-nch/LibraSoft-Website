using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Entities.Entities.Dtos
{
    public class AliasDto 
    {
        public Guid Id { get; set; }
        public string AliasUrl { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string RedirectUrl { get; set; }
        public Guid SiteId { get; set; }
        public int Type { get; set; }
    }
}
