using System;
using System.Collections.Generic;

namespace Librasoft.Entities.Entities
{
    public partial class PiranhaPostComment
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public bool IsApproved { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public Guid PostId { get; set; }

        public virtual PiranhaPost Post { get; set; }
    }
}
