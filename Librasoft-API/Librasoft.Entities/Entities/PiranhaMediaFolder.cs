using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_MediaFolders")]
    public partial class PiranhaMediaFolder
    {
        public PiranhaMediaFolder()
        {
            PiranhaMedia = new HashSet<PiranhaMedium>();
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        [StringLength(512)]
        public string Description { get; set; }

        [InverseProperty("Folder")]
        public virtual ICollection<PiranhaMedium> PiranhaMedia { get; set; }
    }
}
