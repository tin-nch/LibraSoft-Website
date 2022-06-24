using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_EventParticipant")]
    public partial class PiranhaEventParticipant
    {
        public PiranhaEventParticipant()
        {
            IdEvents = new HashSet<PiranhaEvent>();
        }

        [Key]
        public int Id { get; set; }
        [Column("Full Name")]
        public string FullName { get; set; }
        public string Email { get; set; }
        [StringLength(10)]
        public string Phone { get; set; }
        [Column("Company Name")]
        public string CompanyName { get; set; }
        [Column("Company Address")]
        public string CompanyAddress { get; set; }
        public int? Province { get; set; }
        public int? Industry { get; set; }
        public string Position { get; set; }

        [ForeignKey("Industry")]
        [InverseProperty("PiranhaEventParticipants")]
        public virtual PiranhaCfindustry IndustryNavigation { get; set; }
        [ForeignKey("Province")]
        [InverseProperty("PiranhaEventParticipants")]
        public virtual PiranhaCfcountry ProvinceNavigation { get; set; }

        [ForeignKey("IdParticipants")]
        [InverseProperty("IdParticipants")]
        public virtual ICollection<PiranhaEvent> IdEvents { get; set; }
    }
}
