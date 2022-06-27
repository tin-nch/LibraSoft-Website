﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Librasoft.Entities.Entities
{
    [Table("Piranha_CFCountry")]
    public partial class PiranhaCfcountry
    {
        [Key]
        public int CountryId { get; set; }
        [StringLength(500)]
        public string CountryName { get; set; }
    }
}