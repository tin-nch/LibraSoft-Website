﻿using System;
using System.Collections.Generic;

#nullable disable

namespace LibraSoftWeb.Models
{
    public partial class PiranhaCfindustry
    {
        public PiranhaCfindustry()
        {
            PiranhaContactForms = new HashSet<PiranhaContactForm>();
        }

        public int IndustyId { get; set; }
        public string IndustyName { get; set; }

        public virtual ICollection<PiranhaContactForm> PiranhaContactForms { get; set; }
    }
}