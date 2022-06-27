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
            PiranhaEventImages = new HashSet<PiranhaEventImage>();
            IdParticipants = new HashSet<PiranhaEventParticipant>();
        }

        [Key]
        public int Id { get; set; }
        public string EventTitle { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        public bool? Active { get; set; }
        [Column("ZoomID")]
        [StringLength(50)]
        public string ZoomId { get; set; }
        [StringLength(50)]
        public string ZoomPassword { get; set; }
        [Column("URL")]
        [StringLength(50)]
        public string Url { get; set; }
        public string Note { get; set; }
        [Column("IDIMG")]
        public int? Idimg { get; set; }

        [InverseProperty("IdNavigation")]
        public virtual ICollection<PiranhaEventImage> PiranhaEventImages { get; set; }

        [ForeignKey("IdEvent")]
        [InverseProperty("IdEvents")]
        public virtual ICollection<PiranhaEventParticipant> IdParticipants { get; set; }
    }
}
