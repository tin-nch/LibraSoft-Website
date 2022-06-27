﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_PageComments")]
    [Index("PageId", Name = "IX_Piranha_PageComments_PageId")]
    public partial class PiranhaPageComment
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        [Required]
        [StringLength(128)]
        public string Author { get; set; }
        [Required]
        [StringLength(128)]
        public string Email { get; set; }
        [StringLength(256)]
        public string Url { get; set; }
        public bool IsApproved { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public Guid PageId { get; set; }

        [ForeignKey("PageId")]
        [InverseProperty("PiranhaPageComments")]
        public virtual PiranhaPage Page { get; set; }
    }
}