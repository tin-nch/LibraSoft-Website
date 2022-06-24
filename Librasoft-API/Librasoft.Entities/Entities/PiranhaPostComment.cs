using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_PostComments")]
    [Index("PostId", Name = "IX_Piranha_PostComments_PostId")]
    public partial class PiranhaPostComment
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(128)]
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
        public Guid PostId { get; set; }

        [ForeignKey("PostId")]
        [InverseProperty("PiranhaPostComments")]
        public virtual PiranhaPost Post { get; set; }
    }
}
