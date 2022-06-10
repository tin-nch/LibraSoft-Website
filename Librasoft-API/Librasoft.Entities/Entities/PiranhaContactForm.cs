using System;
using System.Collections.Generic;

namespace Librasoft.Entities.Entities
{
    public partial class PiranhaContactForm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? IndustyId { get; set; }
        public int? CountryId { get; set; }
        public int? ReasonReachingId { get; set; }
        public string MessageContent { get; set; }

        public virtual PiranhaCfcountry Country { get; set; }
        public virtual PiranhaCfindustry Industy { get; set; }
        public virtual PiranhaCfreasonReaching ReasonReaching { get; set; }
    }
}
