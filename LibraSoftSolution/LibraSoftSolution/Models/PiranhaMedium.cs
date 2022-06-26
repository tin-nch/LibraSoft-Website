using System;
using System.Collections.Generic;

namespace LibraSoftSolution.Models
{
    public partial class PiranhaMedium
    {
        public PiranhaMedium()
        {
            PiranhaMediaVersions = new HashSet<PiranhaMediaVersion>();
        }

        public Guid Id { get; set; }
        public string ContentType { get; set; } = null!;
        public DateTime Created { get; set; }
        public string Filename { get; set; } = null!;
        public Guid? FolderId { get; set; }
        public DateTime LastModified { get; set; }
        public string? PublicUrl { get; set; }
        public long Size { get; set; }
        public int Type { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public string? AltText { get; set; }
        public string? Description { get; set; }
        public string? Properties { get; set; }
        public string? Title { get; set; }

        public virtual PiranhaMediaFolder? Folder { get; set; }
        public virtual ICollection<PiranhaMediaVersion> PiranhaMediaVersions { get; set; }
    }
}
