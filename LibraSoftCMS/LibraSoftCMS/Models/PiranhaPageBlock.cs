﻿using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class PiranhaPageBlock
    {
        public Guid Id { get; set; }
        public Guid BlockId { get; set; }
        public Guid PageId { get; set; }
        public int SortOrder { get; set; }
        public Guid? ParentId { get; set; }

        public virtual PiranhaBlock Block { get; set; }
        public virtual PiranhaPage Page { get; set; }
    }
}
