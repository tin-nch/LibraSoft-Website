using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_CFPartnerImg")]
    public partial class PiranhaCfpartnerImg
    {
        [Key]
        public int PartnerImgId { get; set; }
        [StringLength(500)]
        public string PartnerName { get; set; }
        public string PartnerImgLink { get; set; }
    }
}
