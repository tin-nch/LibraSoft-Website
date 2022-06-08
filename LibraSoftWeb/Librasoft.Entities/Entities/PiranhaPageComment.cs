using System;
using System.Collections.Generic;
namespace Librasoft_API.Entities
{
    public partial class PiranhaPageComment
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public bool IsApproved { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public Guid PageId { get; set; }

        public virtual PiranhaPage Page { get; set; }
    }
}
