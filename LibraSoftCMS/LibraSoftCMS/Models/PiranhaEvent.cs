using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class PiranhaEvent
    {
        public PiranhaEvent()
        {
            PiranhaEventImages = new HashSet<PiranhaEventImage>();
            IdParticipants = new HashSet<PiranhaEventParticipant>();
        }

        public int Id { get; set; }
        public string EventTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Active { get; set; }
        public string ZoomId { get; set; }
        public string ZoomPassword { get; set; }
        public string Url { get; set; }
        public string NoteEng { get; set; }
        public int? Idimg { get; set; }
        public string NoteVn { get; set; }

        public virtual ICollection<PiranhaEventImage> PiranhaEventImages { get; set; }

        public virtual ICollection<PiranhaEventParticipant> IdParticipants { get; set; }
    }
}
