using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_ContactForm")]
    public partial class PiranhaContactForm
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string FullName { get; set; }
        [StringLength(500)]
        public string Email { get; set; }
        [StringLength(15)]
        [Unicode(false)]
        public string Phone { get; set; }
        public int? ReasonReachingId { get; set; }
        public string MessageContent { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Time { get; set; }

        [ForeignKey("ReasonReachingId")]
        [InverseProperty("PiranhaContactForms")]
        public virtual PiranhaCfreasonReaching ReasonReaching { get; set; }
    }
}
