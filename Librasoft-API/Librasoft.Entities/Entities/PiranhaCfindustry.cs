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
        [Key]
        public int IndustyId { get; set; }
        [StringLength(500)]
        public string IndustyName { get; set; }
    }
}
