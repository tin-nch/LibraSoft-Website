using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraSoftWeb.Models
{
    public class Piranha_ContactForm
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [DisplayName("Piranha_CFIndustry")]
        public int? IndustyId { get; set; }
        [DisplayName("Piranha_CFCountry")]

        public int? CountryId { get; set; }
        [DisplayName("Piranha_CFReasonReaching")]

        public int? ReasonReachingId { get; set; }
        public string MessageContent { get; set; }
        public virtual Piranha_CFCountry Country { get; set; }
        public virtual Piranha_CFIndustry Industy { get; set; }
        public virtual Piranha_CFReasonReaching ReasonReaching { get; set; }
    }
}
