using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_ContentGroups")]
    public partial class PiranhaContentGroup
    {
        [Key]
        [StringLength(64)]
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        [Required]
        [Column("CLRType")]
        [StringLength(255)]
        public string Clrtype { get; set; }
        [Required]
        [StringLength(128)]
        public string Title { get; set; }
        [StringLength(64)]
        public string Icon { get; set; }
        [Required]
        public bool? IsHidden { get; set; }
    }
}
