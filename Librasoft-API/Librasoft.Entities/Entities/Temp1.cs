using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Keyless]
    [Table("Temp1")]
    public partial class Temp1
    {
        public Guid Id { get; set; }
        public Guid BlockId { get; set; }
        public int Number { get; set; }
        [StringLength(20)]
        public string NameType { get; set; }
    }
}
