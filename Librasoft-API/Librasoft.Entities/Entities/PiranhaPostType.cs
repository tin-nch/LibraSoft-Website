using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_PostTypes")]
    public partial class PiranhaPostType
    {
        public PiranhaPostType()
        {
            PiranhaPosts = new HashSet<PiranhaPost>();
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

        [InverseProperty("PostType")]
        public virtual ICollection<PiranhaPost> PiranhaPosts { get; set; }
    }
}
