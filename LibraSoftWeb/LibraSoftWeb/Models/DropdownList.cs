using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraSoftWeb.Models
{
    public class DropdownList
    {
        public List<PiranhaCfcountry> piranha_CFCountries { get; set; }
        public List<PiranhaCfindustry> piranha_CFIndustries { get; set; }
        public List<PiranhaCfreasonReaching> piranha_CFReasonReachings { get; set; }
    }
    [Table("Piranha_CFCountry")]
    public class Piranha_CFCountry
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }

    }
    [Table("Piranha_CFIndustry")]
    public class Piranha_CFIndustry
    {
        [Key]
        public int IndustyId { get; set; }
        public string IndustyName { get; set; }

    }
    [Table("Piranha_CFReasonReaching")]

    public class Piranha_CfreasonReaching
    {
        [Key]
        public int ReasonReachingId { get; set; }
        public string ReasonReachingContent { get; set; }
    }
}
