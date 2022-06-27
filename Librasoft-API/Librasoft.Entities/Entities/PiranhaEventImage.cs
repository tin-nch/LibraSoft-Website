using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_EventImages")]
    public partial class PiranhaEventImage
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Key]
        [StringLength(50)]
        public string ImgPath { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("PiranhaEventImages")]
        public virtual PiranhaEvent IdNavigation { get; set; }
    }
}
