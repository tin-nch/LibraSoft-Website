using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_PageBlocks")]
    [Index("BlockId", Name = "IX_Piranha_PageBlocks_BlockId")]
    [Index("PageId", "SortOrder", Name = "IX_Piranha_PageBlocks_PageId_SortOrder", IsUnique = true)]
    public partial class PiranhaPageBlock
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BlockId { get; set; }
        public Guid PageId { get; set; }
        public int SortOrder { get; set; }
        public Guid? ParentId { get; set; }

        [ForeignKey("BlockId")]
        [InverseProperty("PiranhaPageBlocks")]
        public virtual PiranhaBlock Block { get; set; }
        [ForeignKey("PageId")]
        [InverseProperty("PiranhaPageBlocks")]
        public virtual PiranhaPage Page { get; set; }
    }
}
