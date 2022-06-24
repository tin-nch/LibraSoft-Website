using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_ContentTypes")]
    public partial class PiranhaContentType
    {
        public PiranhaContentType()
        {
            PiranhaContents = new HashSet<PiranhaContent>();
        }

        [Key]
        [StringLength(64)]
        public string Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Group { get; set; }
        [Column("CLRType")]
        public string Clrtype { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        [InverseProperty("Type")]
        public virtual ICollection<PiranhaContent> PiranhaContents { get; set; }
    }
}
