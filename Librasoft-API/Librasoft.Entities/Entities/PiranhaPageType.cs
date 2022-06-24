using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_PageTypes")]
    public partial class PiranhaPageType
    {
        public PiranhaPageType()
        {
            PiranhaPages = new HashSet<PiranhaPage>();
        }

        [Key]
        [StringLength(64)]
        public string Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        [Column("CLRType")]
        [StringLength(256)]
        public string Clrtype { get; set; }

        [InverseProperty("PageType")]
        public virtual ICollection<PiranhaPage> PiranhaPages { get; set; }
    }
}
