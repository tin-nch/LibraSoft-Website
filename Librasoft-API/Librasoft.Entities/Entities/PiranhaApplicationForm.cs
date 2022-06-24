using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_ApplicationForm")]
    public partial class PiranhaApplicationForm
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("Full Name")]
        [StringLength(50)]
        public string FullName { get; set; }
        public string Email { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string Phone { get; set; }
        public string FilePath { get; set; }
    }
}
