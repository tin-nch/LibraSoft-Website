using System;
using System.Collections.Generic;
namespace Librasoft_API.Entities
{
    public partial class PiranhaUserClaim
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public Guid UserId { get; set; }

        public virtual PiranhaUser User { get; set; }
    }
}
