using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_PostBlocks")]
    [Index("BlockId", Name = "IX_Piranha_PostBlocks_BlockId")]
    [Index("PostId", "SortOrder", Name = "IX_Piranha_PostBlocks_PostId_SortOrder", IsUnique = true)]
    public partial class PiranhaPostBlock
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BlockId { get; set; }
        public Guid PostId { get; set; }
        public int SortOrder { get; set; }
        public Guid? ParentId { get; set; }

        [ForeignKey("BlockId")]
        [InverseProperty("PiranhaPostBlocks")]
        public virtual PiranhaBlock Block { get; set; }
        [ForeignKey("PostId")]
        [InverseProperty("PiranhaPostBlocks")]
        public virtual PiranhaPost Post { get; set; }
    }
}
