using System;
using System.Collections.Generic;

namespace Librasoft.Entities.Entities
{
    public partial class PiranhaPageType
    {
        public PiranhaPageType()
        {
            PiranhaPages = new HashSet<PiranhaPage>();
        }

        public string Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string Clrtype { get; set; }

        public virtual ICollection<PiranhaPage> PiranhaPages { get; set; }
    }
}
