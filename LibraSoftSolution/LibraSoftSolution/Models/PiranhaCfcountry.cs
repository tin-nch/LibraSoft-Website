﻿using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaCfcountry
    {
        public PiranhaCfcountry()
        {
            PiranhaContactForms = new HashSet<PiranhaContactForm>();
        }

        public int CountryId { get; set; }
        public string? CountryName { get; set; }

        public virtual ICollection<PiranhaContactForm> PiranhaContactForms { get; set; }
    }
}
