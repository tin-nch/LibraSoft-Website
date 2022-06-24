using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_CFIndustry")]
    public partial class PiranhaCfindustry
    {
        public PiranhaCfindustry()
        {
            PiranhaEventParticipants = new HashSet<PiranhaEventParticipant>();
        }

        [Key]
        public int IndustyId { get; set; }
        [StringLength(500)]
        public string IndustyName { get; set; }

        [InverseProperty("IndustryNavigation")]
        public virtual ICollection<PiranhaEventParticipant> PiranhaEventParticipants { get; set; }
    }
}
