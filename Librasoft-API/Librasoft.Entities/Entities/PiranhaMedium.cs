using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Media")]
    [Index("FolderId", Name = "IX_Piranha_Media_FolderId")]
    public partial class PiranhaMedium
    {
        public PiranhaMedium()
        {
            PiranhaMediaVersions = new HashSet<PiranhaMediaVersion>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(256)]
        public string ContentType { get; set; }
        public DateTime Created { get; set; }
        [Required]
        [StringLength(128)]
        public string Filename { get; set; }
        public Guid? FolderId { get; set; }
        public DateTime LastModified { get; set; }
        public string PublicUrl { get; set; }
        public long Size { get; set; }
        public int Type { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        [StringLength(128)]
        public string AltText { get; set; }
        [StringLength(512)]
        public string Description { get; set; }
        public string Properties { get; set; }
        [StringLength(128)]
        public string Title { get; set; }

        [ForeignKey("FolderId")]
        [InverseProperty("PiranhaMedia")]
        public virtual PiranhaMediaFolder Folder { get; set; }
        [InverseProperty("Media")]
        public virtual ICollection<PiranhaMediaVersion> PiranhaMediaVersions { get; set; }
    }
}
