using System;
using System.Collections.Generic;

namespace Librasoft_API.Entities
{
    public partial class PiranhaContentType
    {
        public PiranhaContentType()
        {
            PiranhaContents = new HashSet<PiranhaContent>();
        }

        public string Id { get; set; }
        public string Group { get; set; }
        public string Clrtype { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<PiranhaContent> PiranhaContents { get; set; }
    }
}
