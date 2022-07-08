﻿using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class PiranhaMediaFolder
    {
        public PiranhaMediaFolder()
        {
            PiranhaMedia = new HashSet<PiranhaMedium>();
        }

        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PiranhaMedium> PiranhaMedia { get; set; }
    }
}
