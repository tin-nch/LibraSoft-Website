using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_Event")]
    public partial class PiranhaEvent
    {
        public PiranhaEvent()
        {
            IdParticipants = new HashSet<PiranhaEventParticipant>();
        }

        [Key]
        public int Id { get; set; }
        [Column("Event Title")]
        public string EventTitle { get; set; }
        [Column("Start Date", TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column("End Date", TypeName = "date")]
        public DateTime? EndDate { get; set; }
        public bool? Active { get; set; }

        [ForeignKey("IdEvent")]
        [InverseProperty("IdEvents")]
        public virtual ICollection<PiranhaEventParticipant> IdParticipants { get; set; }
    }
}
