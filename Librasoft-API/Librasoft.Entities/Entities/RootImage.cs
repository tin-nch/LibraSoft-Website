using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Keyless]
    public partial class RootImage
    {
        [Column("root")]
        [StringLength(50)]
        public string Root { get; set; }
    }
}
