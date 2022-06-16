using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace LibraSoftWeb.Models
{
    public partial class PiranhaContactForm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [DisplayName("PiranhaCfindustry")]
        public int? IndustyId { get; set; }
        [DisplayName("PiranhaCfcountry")]
        public int? CountryId { get; set; }
        [DisplayName("PiranhaCfrreasonReaching")]
        public int? ReasonReachingId { get; set; }
        public string MessageContent { get; set; }

        public virtual PiranhaCfcountry Country { get; set; }
        public virtual PiranhaCfindustry Industy { get; set; }
        public virtual PiranhaCfreasonReaching ReasonReaching { get; set; }
    }
}
