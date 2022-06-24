using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_PostRevisions")]
    [Index("PostId", Name = "IX_Piranha_PostRevisions_PostId")]
    public partial class PiranhaPostRevision
    {
        [Key]
        public Guid Id { get; set; }
        public string Data { get; set; }
        public DateTime Created { get; set; }
        public Guid PostId { get; set; }

        [ForeignKey("PostId")]
        [InverseProperty("PiranhaPostRevisions")]
        public virtual PiranhaPost Post { get; set; }
    }
}
