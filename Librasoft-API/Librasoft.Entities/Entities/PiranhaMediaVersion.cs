﻿using System;
using System.Collections.Generic;
namespace Librasoft_API.Entities
{
    public partial class PiranhaMediaVersion
    {
        public Guid Id { get; set; }
        public int? Height { get; set; }
        public Guid MediaId { get; set; }
        public long Size { get; set; }
        public int Width { get; set; }
        public string FileExtension { get; set; }

        public virtual PiranhaMedium Media { get; set; }
    }
}
