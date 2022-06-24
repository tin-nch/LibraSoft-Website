using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_PageRevisions")]
    [Index("PageId", Name = "IX_Piranha_PageRevisions_PageId")]
    public partial class PiranhaPageRevision
    {
        [Key]
        public Guid Id { get; set; }
        public string Data { get; set; }
        public DateTime Created { get; set; }
        public Guid PageId { get; set; }

        [ForeignKey("PageId")]
        [InverseProperty("PiranhaPageRevisions")]
        public virtual PiranhaPage Page { get; set; }
    }
}
