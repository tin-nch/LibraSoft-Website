using System;
using System.Collections.Generic;

namespace Librasoft.Entities.Entities
{
    public partial class PiranhaSiteType
    {
        public string Id { get; set; }
        public string Body { get; set; }
        public string Clrtype { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
