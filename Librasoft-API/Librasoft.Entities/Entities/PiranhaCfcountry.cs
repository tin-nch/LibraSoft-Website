using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_CFCountry")]
    public partial class PiranhaCfcountry
    {
        public PiranhaCfcountry()
        {
            PiranhaEventParticipants = new HashSet<PiranhaEventParticipant>();
        }

        [Key]
        public int CountryId { get; set; }
        [StringLength(500)]
        public string CountryName { get; set; }

        [InverseProperty("ProvinceNavigation")]
        public virtual ICollection<PiranhaEventParticipant> PiranhaEventParticipants { get; set; }
    }
}
