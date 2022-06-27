using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_EventParticipants")]
    public partial class PiranhaEventParticipant
    {
        public PiranhaEventParticipant()
        {
            IdEvents = new HashSet<PiranhaEvent>();
        }

        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        [StringLength(10)]
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }

        [ForeignKey("IdParticipants")]
        [InverseProperty("IdParticipants")]
        public virtual ICollection<PiranhaEvent> IdEvents { get; set; }
    }
}
