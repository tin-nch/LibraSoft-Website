using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Keyless]
    [Table("Admin_Account")]
    public partial class AdminAccount
    {
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Column("isDelete")]
        public bool IsDelete { get; set; }
        [Column("isVirtualEmail")]
        public bool IsVirtualEmail { get; set; }
    }
}
