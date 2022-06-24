using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Params")]
    [Index("Key", Name = "IX_Piranha_Params_Key", IsUnique = true)]
    public partial class PiranhaParam
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
        [Required]
        [StringLength(64)]
        public string Key { get; set; }
        public DateTime LastModified { get; set; }
        public string Value { get; set; }
    }
}
