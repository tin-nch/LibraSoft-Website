using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_MediaVersions")]
    public partial class PiranhaMediaVersion
    {
        [Key]
        public Guid Id { get; set; }
        public int? Height { get; set; }
        public Guid MediaId { get; set; }
        public long Size { get; set; }
        public int Width { get; set; }
        [StringLength(8)]
        public string FileExtension { get; set; }

        [ForeignKey("MediaId")]
        [InverseProperty("PiranhaMediaVersions")]
        public virtual PiranhaMedium Media { get; set; }
    }
}
