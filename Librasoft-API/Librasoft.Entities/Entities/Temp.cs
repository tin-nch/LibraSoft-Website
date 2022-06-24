using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Keyless]
    [Table("temp")]
    public partial class Temp
    {
        [Column("id")]
        public Guid Id { get; set; }
    }
}
