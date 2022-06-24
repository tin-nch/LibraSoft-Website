using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_CFReasonReaching")]
    public partial class PiranhaCfreasonReaching
    {
        public PiranhaCfreasonReaching()
        {
            PiranhaContactForms = new HashSet<PiranhaContactForm>();
        }

        [Key]
        public int ReasonReachingId { get; set; }
        [StringLength(2000)]
        public string ReasonReachingContent { get; set; }

        [InverseProperty("ReasonReaching")]
        public virtual ICollection<PiranhaContactForm> PiranhaContactForms { get; set; }
    }
}
