using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Blocks")]
    public partial class PiranhaBlock
    {
        public PiranhaBlock()
        {
            PiranhaBlockFields = new HashSet<PiranhaBlockField>();
            PiranhaPageBlocks = new HashSet<PiranhaPageBlock>();
            PiranhaPostBlocks = new HashSet<PiranhaPostBlock>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column("CLRType")]
        [StringLength(256)]
        public string Clrtype { get; set; }
        public DateTime Created { get; set; }
        public bool IsReusable { get; set; }
        public DateTime LastModified { get; set; }
        [StringLength(128)]
        public string Title { get; set; }
        public Guid? ParentId { get; set; }

        [InverseProperty("Block")]
        public virtual ICollection<PiranhaBlockField> PiranhaBlockFields { get; set; }
        [InverseProperty("Block")]
        public virtual ICollection<PiranhaPageBlock> PiranhaPageBlocks { get; set; }
        [InverseProperty("Block")]
        public virtual ICollection<PiranhaPostBlock> PiranhaPostBlocks { get; set; }
    }
}
